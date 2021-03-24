using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult  //çıplak class kalmayacak!
    {
        

        public Result(bool success, string message):this(success)  //this diyerek otomatik olarak bir alttaki success'in de aynı anda çalışmasını sağladık
        {
            Message = message;
            
        }
        public Result(bool success)
        {
             Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
