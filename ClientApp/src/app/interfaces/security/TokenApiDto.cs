﻿namespace Contracts.Model.Security;

public class TokenApiDto
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}