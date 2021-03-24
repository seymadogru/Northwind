using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);    //kullanıcı isim ve şifre girip  logine basınca burası çalışacak. eğer girdikleri doğruysa veritabanına gidicek, claimlerini bulacak, jwt ları bulacak ve client a verecek
    }
}
