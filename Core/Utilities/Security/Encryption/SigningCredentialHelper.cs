using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)  //kullanıcı adı parola bir credential dır.
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);  //hangi anahtarı ve hangi algoritmayı kullanacağını verdik encription yaparken
        }
    }
}
