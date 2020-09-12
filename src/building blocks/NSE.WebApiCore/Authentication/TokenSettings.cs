﻿namespace NSE.WebApiCore.Authentication
{
    public class TokenSettings
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public int ExpirationTime { get; set; }
        public string ValidUri { get; set; }
    }
}