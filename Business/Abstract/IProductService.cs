using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll(); //tüm ürünleri listeleyecek bir ortam oluşturacak.işlem sonucu ve mesajı da aynı zamanda döndürmek istediğim için IDataResult olarak tanımladık. hem tüm ürünler dönecek hemde mesajlar
        IDataResult<List<Product>> GetAllByCategoryId(int Id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product); //void di bu aslında. bunda data yok, bir şey dönmeyecek. o yüzden IResult
        IResult Update(Product product);

        IResult AddTransactionalTest(Product product);    //işlemlerin doğru ilerlemesi. mesela para yatırdın benden gitti karşı tarafın bakiyesinin artması gerek. artmazsa hata verirse o paranın bana geri dönmesi gerek
    }
}
