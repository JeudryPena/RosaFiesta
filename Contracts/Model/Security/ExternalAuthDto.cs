﻿namespace Contracts.Model.Security;
public class ExternalAuthDto
{
	public string? Provider { get; set; }
	public string? IdToken { get; set; }
}
