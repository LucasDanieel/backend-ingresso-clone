﻿using FluentValidation.Results;

namespace Ingresso.Application.Services
{
    public class ResultService
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ICollection<ErrorValidation> Errors { get; set; }

        public static ResultService RequestError(string message, ValidationResult result)
        {
            return new ResultService
            {
                IsSuccess = false,
                Message = message,
                Errors = result.Errors.Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };
        }

        public static ResultService<T> RequestError<T>(string message, ValidationResult result)
        {
            return new ResultService<T>
            {
                IsSuccess = false,
                Message = message,
                Errors = result.Errors.Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };
        }

        public static ResultService Fail(string message) => new ResultService { IsSuccess = false, Message = message };
        public static ResultService<T> Fail<T>(string message) => new ResultService<T> { IsSuccess = false, Message = message };

        public static ResultService Ok(string message) => new ResultService { IsSuccess = true, Message = message };
        public static ResultService<T> Ok<T>(T data) => new ResultService<T> { IsSuccess = true, Data = data};
    }

    public class ResultService<T> : ResultService
    {
        public T Data { get; set; }
    }
}
