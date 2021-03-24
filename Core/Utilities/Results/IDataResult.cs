using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult    //Hangi tipi döndüreceğini bana söyle demek T.
    {
        T Data { get; }      // T türünde datalarımız olacak
    }
}
