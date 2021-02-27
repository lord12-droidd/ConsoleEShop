using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleEShop
{
    interface ICheck
    {
        bool CheckEmail(string email);
        bool CheckLogin(string login);
        bool CheckEnter(string login, string password);
    }
    interface IUser
    {
        void SearchProduct();
        void ViewProductsList();
    }
    interface IGuest : IUser
    {
        void Registration();
        bool Enter();
    }

    class Register
    {
        Checker checker = new Checker();
        public string InputName()
        {
            Console.WriteLine("Введіть своє ім'я:");
            return Console.ReadLine();
        }

        public string InputSurname()
        {
            Console.WriteLine("Введіть своє прізвище:");
            return Console.ReadLine();
        }

        public string InputEmail()
        {
            string email;
            while (true)
            {
                Console.WriteLine("Введіть свій email:");
                email = Console.ReadLine();
                if (checker.CheckEmail(email))
                {
                    Console.WriteLine("Введений email вже використовується");
                }
                break;
            }
            return email;
        }

        public string InputLogin()
        {
            string login;
            while (true)
            {
                Console.WriteLine("Введіть свій login:");
                login = Console.ReadLine();
                if (checker.CheckLogin(login))
                {
                    Console.WriteLine("Введений login вже використовується");
                }
                break;
            }
            return login;
        }

        public string InputPassword()
        {
            Console.WriteLine("Вигадайте свій пароль:");
            return Console.ReadLine();
        }
    }
    class Checker : ICheck
    {
        UsersLocalDB dB = new UsersLocalDB();
        public bool CheckEmail(string email)
        {
            for (int i = 0; i < dB.GetRegistredGuests.Count; i++)
            {
                if (dB.GetRegistredGuests[i].Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckEnter(string login, string password)
        {
            for (int i = 0; i < dB.GetRegistredGuests.Count; i++)
            {
                if (dB.GetRegistredGuests[i].Login == login && dB.GetRegistredGuests[i].Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckLogin(string login)
        {
            for (int i = 0; i < dB.GetRegistredGuests.Count; i++)
            {
                if (dB.GetRegistredGuests[i].Login == login)
                {
                    return true;
                }
            }
            return false;
        }
    }
    class UsersLocalDB
    {
        private List<RegistredGuest> registredGuests = new List<RegistredGuest>();
        public List<RegistredGuest> GetRegistredGuests
        {
            get
            {
                return registredGuests;
            }
        }
        public int Lenght
        {
            get
            {
                return registredGuests.Count;
            }
        }
        public void Add(RegistredGuest guest)
        {
            registredGuests.Add(guest);
        }
    }

    class ProductsLocalDB
    {
        List<Product> productsDB = new List<Product>();
        public List<Product> GetProducts
        {
            get
            {
                return productsDB;
            }
        }
        public void Add(Product product)
        {
            productsDB.Add(product);
        }

    }

    class Product
    {
        public string Name { set; get; }
        public string Category { set; get; }
        public string Description { set; get; }
        public decimal Cost { set; get; }

        public Product(string name, string category, string description, decimal cost)
        {
            Name = name;
            Category = category;
            Description = description;
            Cost = cost;
        }
        public override string ToString()
        {
            return $"{Name},{Category},{Cost}\n{Description}";
        }
    }

    class Guest : IGuest
    {
        UsersLocalDB dB = new UsersLocalDB();
        ProductsLocalDB productsDB = new ProductsLocalDB();
        Checker checker = new Checker();
        Register register = new Register();
        public void Registration()
        {
            RegistredGuest registredGuest = new RegistredGuest(
                register.InputName(),
                register.InputSurname(),
                register.InputEmail(),
                register.InputLogin(),
                register.InputPassword());
            dB.Add(registredGuest);
        }
        public bool Enter()
        {
            Console.WriteLine("Вхід у систему, введіть логін:");
            string login = Console.ReadLine();  // додати перевірку на пустоту поля
            Console.WriteLine("Вхід у систему, введіть пароль:");
            string password = Console.ReadLine(); // додати перевірку на пустоту поля
            if (checker.CheckEnter(login, password))
            {
                Console.WriteLine($"Ви увійшли на сайт як {login}");
                return true;
            }
            return false;
        }

        public void ViewProductsList()
        {
            for(int i = 0; i < productsDB.GetProducts.Count; i++)
            {
                Console.WriteLine($"{i}){productsDB.GetProducts[i]}");
            }
        }
        public void SearchProduct()
        {
            string searched = Console.ReadLine();
            for (int i = 0; i < productsDB.GetProducts.Count; i++)
            {
                if(searched == productsDB.GetProducts[i].Name)
                {
                    Console.WriteLine($"{i}){productsDB.GetProducts[i]}");
                }
            }
        }
    }
    class RegistredGuest
    {
        public string Name { set; get; }
        public string Lastname { set; get; }
        public string Email { set; get; }
        public string Login { set; get; }
        public string Password { set; get; }
        public RegistredGuest(string name, string lastname, string email, string login, string password)
        {
            Name = name;
            Lastname = lastname;
            Email = email;
            Login = login;
            Password = password;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
