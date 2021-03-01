using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    static class ProductsLocalDB
    {
        static private List<Product> productsDB = new List<Product>() {
            new Product(1,"Lenovo Legion","Laptop","Оч крутой сам, юзаю",1000),
            new Product(2,"Asus Gaming","Laptop","Тоже крутой",1200),
            new Product(3,"Acer","Laptop","Крутой, но чуть хуже",900),
            new Product(4,"Xiaomi","Smartphone","Топ за свої гроші",100)
        };

        static public List<Product> GetProducts
        {
            get
            {
                return productsDB;
            }
        }
        static public void Add(Product product)
        {
            productsDB.Add(product);
        }

    }
}
