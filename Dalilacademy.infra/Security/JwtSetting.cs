using System;
using System.Collections.Generic;
using System.Text;

namespace Dalilacademy.infra.Security
{
    public class JwtSetting
    {
        public string Key { get; set; }= string.Empty;
        public string Issuer { get; set; }= string.Empty;
        public string Audience { get; set; }= string.Empty;
        public double ExpirationInMinutes { get; set; }


    }
}
