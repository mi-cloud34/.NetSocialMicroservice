﻿using Social.AuthApi.Models.Dto;

namespace Social.AuthApi.Services
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        //Task<bool> AssignRole(string email, string roleName);
    }
}