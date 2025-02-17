using System.Security.Cryptography;
using AutoMapper;
using Ingresso.Application.Authentication.Interfaces;
using Ingresso.Application.Caching.Interfaces;
using Ingresso.Application.DTOs;
using Ingresso.Application.DTOs.Validations;
using Ingresso.Application.Services.Interfaces;
using Ingresso.Domain.Entities;
using Ingresso.Domain.Repository;

namespace Ingresso.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly ITokenGenerator _tokenGenerator;
        //private readonly ICachingService _caching;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper, IEmailService emailService, ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _emailService = emailService;
            _tokenGenerator = tokenGenerator;
            //_caching = caching;
        }

        public async Task<ResultService<string>> LoginUserAsync(UserLoginDTO userLoginDTO)
        {
            if (userLoginDTO == null)
                return ResultService.Fail<string>("Objeto vazio");

            User user = null;

            if (!string.IsNullOrEmpty(userLoginDTO.Email))
                user = await _userRepository.GetByEmailAsync(userLoginDTO.Email);
            else if (!string.IsNullOrEmpty(userLoginDTO.CPF))
                user = await _userRepository.GetByCPFAsync(userLoginDTO.CPF);

            if (user == null)
                return ResultService.Fail<string>("Usuario não encontrado");

            if (!user.UserValid)
                return ResultService.Fail<string>("Usuario não confirmado");

            bool isValid = user.VerifyPassword(userLoginDTO.Password);

            if (!isValid)
                return ResultService.Fail<string>("Senha errada");

            //string code = RandomNumberGenerator.GetInt32(100000, 999999).ToString();

            //await _caching.PostAsync(user.Email, code);

            //await _emailService.SendVerificationCodeAsync(user.Email, code);

            return ResultService.Ok<string>(user.Email);
        }

        public async Task<ResultService<string>> LoginViaGoogleAsync(string email)
        {
            User user = await _userRepository.GetByEmailAsync(email);

            if (user == null)
                return ResultService.Fail<string>("Usuario não encontrado");

            if (user.UserValid == false)
                return ResultService.Fail<string>("Usuario não confirmado");

            string token = _tokenGenerator.GenerateLoginToken(user);

            return ResultService.Ok<string>(token);
        }

        public async Task<ResultService<AuthenticatedUserDTO>> AuthUserAsync(string token)
        {
            if (string.IsNullOrEmpty(token))
                return ResultService.Fail<AuthenticatedUserDTO>("Token vazio");

            ClaimsDTO claims = _tokenGenerator.DecodToken(token);

            if (claims == null)
                return ResultService.Fail<AuthenticatedUserDTO>("Token invalido");

            User user = await _userRepository.GetByIdAsync(claims.Id);

            if (user == null)
                return ResultService.Fail<AuthenticatedUserDTO>("Usuario não encontrado");

            if (!user.UserValid)
                return ResultService.Fail<AuthenticatedUserDTO>("Usuario não confirmado");

            AuthenticatedUserDTO authenticated = _mapper.Map<AuthenticatedUserDTO>(user);

            return ResultService.Ok<AuthenticatedUserDTO>(authenticated);
        }

        public async Task<ResultService<UserDTO>> GetUserProfileAsync(string token)
        {
            if (string.IsNullOrEmpty(token))
                return ResultService.Fail<UserDTO>("Token vazio");

            ClaimsDTO claims = _tokenGenerator.DecodToken(token);

            User user = await _userRepository.GetByIdAsync(claims.Id);

            if (user == null)
                return ResultService.Fail<UserDTO>("Usuario não encontrado");

            if (!user.UserValid)
                return ResultService.Fail<UserDTO>("Usuario não confirmado");

            UserDTO userDTO = _mapper.Map<UserDTO>(user);

            return ResultService.Ok<UserDTO>(userDTO);
        }

        public async Task<ResultService> CreateUserAsync(UserDTO userDTO)
        {
            if (userDTO == null)
                return ResultService.Fail("Objeto vazio");

            var valid = new UserDTOValidator().Validate(userDTO);
            if (!valid.IsValid)
                return ResultService.RequestError("Um ou mais campos invalidos", valid);

            User user = _mapper.Map<User>(userDTO);

            var userExist = await _userRepository.GetByCPFOrEmailAsync(user.CPF, user.Email);
            if (userExist != null)
            {
                if (userExist.Email == user.Email && userExist.CPF == user.CPF)
                    return ResultService.Fail("Cpf e email já cadastrado");
                else if (userExist.Email == user.Email)
                    return ResultService.Fail("Email já cadastrado");
                else if (userExist.CPF == user.CPF)
                    return ResultService.Fail("Cpf já cadastrado");
            }

            user.HasingPassword();

            await _userRepository.CreateAsync(user);

            string token = _tokenGenerator.GenerateConfirmationToken(user);

            await _emailService.SendConfirmEmailAsync(user.Email, token);

            return ResultService.Ok("Usuario cadastrado");
        }

        public async Task<ResultService> UpdateProfileAsync(UserDTO userDTO)
        {
            if (userDTO == null)
                return ResultService.Fail("Objeto vazio");

            var valid = new UserUpdateDTOValidator().Validate(userDTO);
            if (!valid.IsValid)
                return ResultService.RequestError("Um ou mais campos invalidos", valid);

            User user = await _userRepository.GetByCPFAsync(userDTO.CPF);

            if (user == null)
                return ResultService.Fail("Usuario não existe");

            if (!user.UserValid)
                return ResultService.Fail("Usuario não confirmado");

            bool validPassword = user.VerifyPassword(userDTO.Password);

            if (!validPassword)
                return ResultService.Fail("Senha inválida");

            User userUpdated = _mapper.Map(userDTO, user);

            await _userRepository.UpdateUserAsync(userUpdated);

            return ResultService.Ok("Ok");
        }

        public async Task<ResultService> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO)
        {
            if (changePasswordDTO == null)
                return ResultService.Fail("Objeto vazio");

            User user = await _userRepository.GetByEmailAsync(changePasswordDTO.Email);

            if(user == null)
                return ResultService.Fail("Usuario não encontrado");

            if(!user.UserValid)
                return ResultService.Fail("Usuario não confirmado");

            bool validPassword = user.VerifyPassword(changePasswordDTO.OldPassword);

            if (!validPassword)
                return ResultService.Fail("Senha inválida");

            user.ChangePassword(changePasswordDTO.NewPassword);

            user.HasingPassword();

            await _userRepository.UpdateUserAsync(user);

            return ResultService.Ok("Ok");
        }

        public async Task<ResultService<string>> VerifyCodeAsync(VerifyCodeDTO verifyCodeDTO)
        {
            if (string.IsNullOrEmpty(verifyCodeDTO.Email))
                return ResultService.Fail<string>("Campo vazio");

            //string value = await _caching.GetAsync(verifyCodeDTO.Email);
            //if (verifyCodeDTO.Code != value)
            //    return ResultService.Fail<string>("Codigo invalido");

            //await _caching.DeleteAsync(verifyCodeDTO.Email);

            User user = await _userRepository.GetByEmailAsync(verifyCodeDTO.Email);

            if (user == null)
                return ResultService.Fail<string>("Usuario não encontrado");

            string token = _tokenGenerator.GenerateLoginToken(user);

            return ResultService.Ok<string>(token);
        }

        public async Task<ResultService> ConfirmEmailUserAsync(string token)
        {
            if (string.IsNullOrEmpty(token))
                return ResultService.Fail("Token vazio");

            ClaimsDTO claims = _tokenGenerator.DecodToken(token);

            if (claims == null)
                return ResultService.Fail("Token invalido");

            User user = await _userRepository.GetByIdAsync(claims.Id);

            if (user == null)
                return ResultService.Fail("Usuario não encontrado");

            if (user.UserValid)
                return ResultService.Fail("Usuario já confirmado");

            user.ChangeUserValid();

            bool done = await _userRepository.UpdateUserAsync(user);

            if (!done)
                return ResultService.Fail("Não foi possivel validar essa conta");

            return ResultService.Ok("Usuario confirmado");
        }

        public async Task<ResultService> ResendCodeToEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                return ResultService.Fail("Email vazio");

            //string code = RandomNumberGenerator.GetInt32(100000, 999999).ToString();

            //await _caching.PostAsync(email, code);

            //await _emailService.SendVerificationCodeAsync(email, code);

            return ResultService.Ok("Código enviado");
        }

    }
}
