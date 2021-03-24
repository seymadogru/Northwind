using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //veritabanında yapacağım operasyonları yönetecek
    public interface IProductDal : IEntityRepository<Product> //senin çalışma tipin (T) product'tır diyoruz
    {
        List<ProductDetailDto> GetProductDetails();
    }
}
