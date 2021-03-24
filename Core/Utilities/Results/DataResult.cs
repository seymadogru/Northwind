using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>          //resulttan farkı, bunun datasının olması... DataReslt a diyoruz ki sen bir Result'sın
    {
        public DataResult(T data, bool success, string message):base(success,message)  //bu aynı zamanda data döndürüyor gördüğümüz üzere. base'leyerek, yazdığımız kodu bir daha yazmamamızı sağlıyor
        {
            Data = data;
        }
        public DataResult(T data, bool success):base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
