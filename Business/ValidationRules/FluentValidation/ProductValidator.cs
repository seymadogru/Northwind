using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator: AbstractValidator<Product>   //doğrulama kurallarını nasıl yapacağını söyleyeceğiz
    {
        //kurallar bir constractor içine yazılır
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();  //ürün ismi boş olamaz
            RuleFor(p => p.ProductName).MinimumLength(2);  //ürün ismi minmum 2 karakter olmalı
            RuleFor(p => p.UnitPrice).NotEmpty(); //birim fiyatı boş olmamalı 
            RuleFor(p => p.UnitPrice).GreaterThan(0);  //birim fiyatı 0 dan büyük olmalı
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);  //categoryId si 1 olduğu zaman birim fiyatı 10 dan büyük yada eşit olmalı(mesela kola satıyoruz, onlar 10 liraveya fazla olsun diyoruz)
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı"); //ürün ismim A ile başlamalı demek -- must:uymalı



        }

        private bool StartWithA(string arg)   //true döndürürse kurala uygun, false döndürürse değil
        {
            return arg.StartsWith("A"); //A ile başlıyorsa true dönecek
        }
    }
}
