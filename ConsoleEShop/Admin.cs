using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    class Admin : RegistredGuest
    {
        private string _name;
        private string _lastname;
        private string _email;
        private string _login;
        private string _password;
        public Admin(string name, string lastname, string email, string login, string password) : base(name, lastname, email, login, password)
        {
            _name = name;
            _lastname = lastname;
            _email = email;
            _login = login;
            _password = password;
            rights = Rights.Admin;
        }
        public Admin(Rights rights) : base(Rights.Admin)
        {

        }
        public void AddNewProduct()
        {
            Checker cheker = new Checker();
            ProductCreater creater = new ProductCreater();
            Product newProduct = new Product(
                creater.InputId(),
                cheker.CheckIsNotEmpty(creater.InputName()),
                cheker.CheckIsNotEmpty(creater.InputCategory()),
                cheker.CheckIsNotEmpty(creater.InputDescription()),
                creater.InputCost()
                );
            ProductsLocalDB.Add(newProduct);
            MenuBacker.BackMessage();
        }
        public void ChangeProductInformation()
        {
            Checker checker = new Checker();
            Console.WriteLine("Введіть айди товару, який хочете змінити");
            string id = Console.ReadLine();
            ProductCreater changer = new ProductCreater();
            for (int i = 0; i < ProductsLocalDB.GetProducts.Count; i++)
            {
                if (Convert.ToString(ProductsLocalDB.GetProducts[i].ID) == id)
                {
                    ProductsLocalDB.GetProducts[i].Name = checker.CheckIsNotEmpty(changer.InputName());
                    ProductsLocalDB.GetProducts[i].Category = checker.CheckIsNotEmpty(changer.InputCategory());
                    ProductsLocalDB.GetProducts[i].Description = checker.CheckIsNotEmpty(changer.InputDescription());
                    ProductsLocalDB.GetProducts[i].Cost = changer.InputCost();
                }
                else if(Convert.ToString(ProductsLocalDB.GetProducts[i].ID) != id && i == ProductsLocalDB.GetProducts.Count-1)
                {
                    Console.WriteLine("Товара з таким айди немає");
                }
            }
            MenuBacker.BackMessage();
        }
        public void ChangeOrdersStatus()
        {
            Checker checker = new Checker();
            OrderLocalDB.ShowAllOrders();
            Console.WriteLine("Выберите id заказа:");
            string id = Console.ReadLine();
            if (checker.CheckOrderID(id))
            {
                Console.WriteLine("Выберите статус заказа: \nNew - 0\nAdminDeny - 1\nPayReceived - 2\nSent - 3\nCompleted - 4");
                int status;
                while (true)
                {
                    try
                    {
                        status = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Введите число");
                    }
                }
                if (checker.CheckStatus(status))
                {
                    for (int i = 0; i < OrderLocalDB.GetOrders.Count; i++)
                    {
                        if (id == Convert.ToString(OrderLocalDB.GetOrders[i].ID))
                        {
                            OrderLocalDB.GetOrders[i].Status = (OrderStatus)status;
                            break;
                        }
                    }
                    MenuBacker.BackMessage();
                }
                else
                {
                    Console.WriteLine("Нужно выбрать один из статусов");
                    ChangeOrdersStatus();
                }
            }
            else
            {
                Console.WriteLine("Товара с таким айди нет");
                return;
            }

        }
        public void EditUserProfile()
        {
            Checker checker = new Checker();
            Register register = new Register();
            for(int i = 0; i< UsersLocalDB.GetRegistredGuests.Count; i++)
            {
                UsersLocalDB.GetRegistredGuests[i].ToString();
            }
            Console.WriteLine("Введите логин юзера для редагирования:");
            string login = Console.ReadLine();
            for(int i = 0; i < UsersLocalDB.GetRegistredGuests.Count; i++)
            {
                if (checker.CheckLogin(login))
                {
                    UsersLocalDB.GetRegistredGuests[i].Name = register.InputName();
                    UsersLocalDB.GetRegistredGuests[i].Lastname = register.InputSurname();
                    MenuBacker.BackMessage();
                }
            }

            
        }
    }
}
