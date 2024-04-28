﻿namespace Fallout4Downgrader
{
    public class AppSettings
    {
        public bool UseQrCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Language { get; set; }
        public bool DownloadAllLanguages { get; set; }
        public bool KeepDepotFiles { get; set; }
        public bool DownloadCreationKit { get; set; }
        public static AppSettings FromParams(Params p)
        {
            return new AppSettings
            {
                UseQrCode = p.Contains("-qr"),
                KeepDepotFiles = p.Contains("-keep-depot"),
                DownloadCreationKit = p.Contains("-creation-kit") || p.Contains("-ck"),
                Username = p.Get<string>("-username") ?? p.Get<string>("-user"),
                Password = p.Get<string>("-password") ?? p.Get<string>("-pass"),
                DownloadAllLanguages = p.Contains("-all-languages"),
                Language = p.Get<string>("-language")
            };
        }
    }
}