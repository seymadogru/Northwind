using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //temel void'ler için başlangıç  //içide bir tane işlem sonucu, bir tane de işlem mesajı olsun
    public interface IResult
    {
        bool Success { get; }      //get demek sadece okunabilir demek   //set; yazmak için
        string Message { get; }
    }
}
