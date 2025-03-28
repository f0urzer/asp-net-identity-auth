﻿namespace Auth.API.Configs
{
    public sealed class SmtpConfig
    {
        public string From { get; set; } = null!;
        public string Host { get; set; } = null!;
        public int Port { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsSSL { get; set; }
    }
}
