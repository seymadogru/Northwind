using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash , out byte[] passwordSalt)  //out:dışarıya verilecek değer
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())  //HMAC BİR CRİPTOGRAFİ ALGORİTMASI
            {
                passwordSalt = hmac.Key;   //kullandığımız algoritmaın key'ini kullanıyoruz
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));   //password'ü byte a çevirerek aldı
            }
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) //kullanıcıdan gelen şifrenin hash'iyle veritabanındaki hash karşılkaştırması doğru mu diye bakacak burası ona göre true döndürecek. buradaki parola , kullanıcının tekrar girerken girdiği parola
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) 
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])  //şifre eşleşmiyorsa
                    {
                        return false;
                    }
                }
                return true;
            }

            
        }

    }
}
