﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AppShared.Library.DTOs
{
    public class Response<T> where T : class
    {
        public T Data { get; private set; }
        public int StatusCode { get; private set; }
        [JsonIgnore]//Json dataya serilize edilirken bu data ignore edilecek.
        public bool IsSuccessful { get; private set; }
        public ErrorDTO Error { get; private set; }

        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T>
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccessful = true
            };
        }

        public static Response<T> Success(int statusCode)
        {
            return new Response<T>
            {
                Data = default,
                StatusCode = statusCode,
                IsSuccessful = true

            };
        }

        public static Response<T> Fail(ErrorDTO errorDTO, int statusCode)
        {
            return new Response<T>
            {
                Error = errorDTO,
                StatusCode = statusCode,
                IsSuccessful = false

            };
        }

        public static Response<T> Fail(string errorMessage, int statusCode, bool isShow)
        {

            var errorDto = new ErrorDTO(errorMessage, isShow);

            return new Response<T>
            {
                Error = errorDto,
                StatusCode = statusCode,
                IsSuccessful = false

            };
        }
    }

}
