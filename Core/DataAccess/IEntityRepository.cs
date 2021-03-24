using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //class ; referans tip. uygulamamız sadece bizim nesnelerimiz ile çalışacak demek.yani bu T yerine sadece benim ürünlerimi(category,product,customer) koyabilsin demek
    //IEntity; IEntity olabilir ya da IEntity implemente eden bir nesne olabilir demek 
    //new() ; new'lenebilir olmalı
    public interface IEntityRepository<T> where T:class,IEntity,new() 
    {
        //AYNI YAPIYI tüm ...DAL larda KULLANMAK YERİNE BURADA BİR İNTERFACE YAPARIZ VE DİĞER SINIFLARA BURADAN ÇEKERİZ
        List<T> GetAll(Expression<Func<T, bool>> filter =null); //bize bir şey vermesini sağlar expression. istediğimiz şeye göre getirme yapar
        T Get(Expression<Func<T, bool>> filter); //filtreler yazabilmemizi sağlıyor -- şu fiyatta olanları filtrele gibi
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        List<T> GetAllByCategory(int categoryId);
    }
}
