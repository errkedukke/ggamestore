﻿namespace Gamestore.Domain.Model;

public class EmailMessage
{
    public string Reciever { get; set; } = string.Empty;

    public string Subject { get; set; } = string.Empty;

    public string Body { get; set; } = string.Empty;
}

