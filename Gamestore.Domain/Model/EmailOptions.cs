﻿namespace Gamestore.Domain.Model;

public sealed class EmailOptions
{
    public string ApiKey { get; set; } = string.Empty;

    public string SenderAddress { get; set; } = string.Empty;

    public string Sendername { get; set; } = string.Empty;
}

