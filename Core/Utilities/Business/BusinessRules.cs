using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)    //params sayesinde IResult içerisine istediğimiz kadar parametre verebiliyoruzz () içerisine virgül ile. logic iş kuralı demek
        {
            foreach (var logic in logics)   //herbir iş kuralını gez
            {
                if (!logic.Success)
                {
                    return logic;    //hatalı olan iş kuralını direkt olarak logice gönderiyoruz ve döndürütoruz.
                }
            }
            return null;
        }
    }
}
