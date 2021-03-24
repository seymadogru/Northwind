using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }   //kullanıcıya vereceğimiz token (jeton)
        public DateTime Expiration { get; set; }  //bitiş zamanını verdiğimiz değer. yani verdiğimiz jetonu şu zamana kadar kullanabilirsin diyoruz
    }
}
