using AutoMapper;
using Ingresso.Application.DTOs.MovieDTOs;
using Ingresso.Application.DTOs.Validations.MovieValidations;
using Ingresso.Application.Services.Interfaces;
using Ingresso.Domain.Entities;
using Ingresso.Domain.Integrations;
using Ingresso.Domain.Repository;
using Microsoft.AspNetCore.Http;

namespace Ingresso.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ISaveCloudinary _saveCloudinary;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository, ISaveCloudinary saveCloudinary, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _saveCloudinary = saveCloudinary;
            _mapper = mapper;
        }

        public async Task<ResultService<MovieDTO>> GetBySlugAsync(string slug)
        {
            if (string.IsNullOrEmpty(slug))
                return ResultService.Fail<MovieDTO>("Slug deve ser informado");

            Movie movie = await _movieRepository.GetBySlugAsync(slug);

            if (movie == null)
                return ResultService.Fail<MovieDTO>("Filme não encontrado");

            return ResultService.Ok(_mapper.Map<MovieDTO>(movie));
        }

        public async Task<ResultService<MovieDTO>> GetBySlugWithDescriptionAsync(string slug)
        {
            if (string.IsNullOrEmpty(slug))
                return ResultService.Fail<MovieDTO>("Slug deve ser informado");

            Movie movie = await _movieRepository.GetBySlugWithDescriptionAsync(slug);

            if (movie == null)
                return ResultService.Fail<MovieDTO>("Filme não encontrado");

            return ResultService.Ok(_mapper.Map<MovieDTO>(movie));
        }

        public async Task<ResultService> CreateAsync(MovieDTO movieDTO, IFormFile PosterImage, IFormFile BannerImage)
        {
            if (movieDTO == null)
                return ResultService.Fail("Filme não encontrado");

            if (movieDTO.MovieDescriptionDTO == null)
                return ResultService.Fail("Conteudo da descrição do filme deve ser informado");

            var valid = new MovieDTOValidator().Validate(movieDTO);
            if (!valid.IsValid)
                return ResultService.RequestError("Filme com campos invalidos", valid);

            bool movieExist = await _movieRepository.MovieExistAsync(movieDTO.Name, movieDTO.Slug);

            if (movieExist)
                return ResultService.Fail("Filme já cadastrado");

            string posterPublicId = $"ingresso/movie/poster/{movieDTO.Slug}-{Guid.NewGuid()}";
            string bannerPublicId = $"ingresso/movie/banner/{movieDTO.Slug}-{Guid.NewGuid()}";

            movieDTO.PublicIdPosterImage = posterPublicId;
            movieDTO.PublicIdBannerImage = bannerPublicId;
            movieDTO.PosterImage = await _saveCloudinary.SaveImageAsync(movieDTO.Slug, posterPublicId, PosterImage);
            movieDTO.BannerImage = await _saveCloudinary.SaveImageAsync(movieDTO.Slug, bannerPublicId, BannerImage);

            Movie movie = _mapper.Map<Movie>(movieDTO);

            await _movieRepository.CreateAsync(movie);

            return ResultService.Ok(_mapper.Map<MovieDTO>(movie));
        }

        public async Task<ResultService> DeleteAsync(int movieId)
        {
            if (movieId <= 0)
                return ResultService.Fail("Id do filme precisa ser informado");

            Movie movie = await _movieRepository.GetByIdAsync(movieId);

            if (movie == null)
                return ResultService.Fail("Filme não encontrado");

            await _movieRepository.DeleteAsync(movie);

            await _saveCloudinary.DeleteMovieImageAsync([movie.PublicIdPosterImage, movie.PublicIdBannerImage]);

            return ResultService.Ok("Filme deletado");
        }
    }
}
