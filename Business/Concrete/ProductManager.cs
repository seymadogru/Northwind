using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        
        IProductDal _productDal;
        ICategoryService _categoryService;
        

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _categoryService = categoryService;
             _productDal = productDal;
        }

        
        [SecuredOperation("product.add,admin")]   //yetkilendirme
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
           IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName),   //aynı isimde ürün olmamalı
                                              CheckIfProductCountOfCategoryCorrect(product.CategoryId),//ürün limiti kurallara uyuyor mu
                                              CheckIfCategoryLimitExceded());      //category 15 i geçerse ürün ekleyemez
            
            //artık yukarda sadece virgülle yeni kural eklememiz yeterli. yeniden buraya kod yazmamıza gerek yok
           
            //result=kurala uymayan
            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
           
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları.    
            if (DateTime.Now.Hour == 03)  //ürünlerin listelenmesini 22 den 23 e kadar kapatmak istiyoruz diyelim
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);

            
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int Id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId==Id));
        }

        [CacheAspect]
       // [PerformanceAspect(5)]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }




        //Aynı kategoride 15 den fazla ürün eklenemez metodu;
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            //Select count(*) from products where categoryId=1 ---- bu kod çalışır arka planda
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);

            }
            return new SuccessResult();
        }


        //eklenen isimde aynı ürün var mı? varsa ekleme;
        private IResult CheckIfProductNameExists(string productName)
        {
            
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();  //any= var mı diye kontrol eder
            if (result)   //result==true demekle aynı
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);

            }
            return new SuccessResult();
        }


        private IResult CheckIfCategoryLimitExceded()
        {

            var result = _categoryService.GetAll(); 
            if (result.Data.Count>15)   
            {
                return new ErrorResult(Messages.CategoryLimitExceded);

            }
            return new SuccessResult();
        }

       // [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            
            Add(product);
            if(product.UnitPrice< 10)
            {
                throw new Exception("");
            }

            Add(product);
            return null;
        }
    }
}
