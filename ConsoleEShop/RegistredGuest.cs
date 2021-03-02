using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    public class RegistredGuest : Guest, IRegistred
    {
        private string _name;
        private string _lastname;
        private string _email;
        private string _login;
        private string _password;
        public string Name
        {
            get { return (_name); }
            set { _name = value; }
        }
        public string Lastname
        {
            get { return (_lastname); }
            set { _lastname = value; }
        }
        public string Email
        {
            get { return (_email); }
            private set { _email = value; }
        }
        public string Login
        {
            get { return (_login); }
            set { _login = value; }
        }
        public string Password
        {
            get { return (_password); }
            private set { _password = value; }
        }
        public RegistredGuest(string name, string lastname, string email, string login, string password) : base(Rights.RegistredUser)
        {
            
            _name = name;
            _lastname = lastname;
            _email = email;
            _login = login;
            _password = password;
            rights = Rights.RegistredUser;
        }
        public RegistredGuest(Rights rights) : base(Rights.RegistredUser)
        {
            
        }

        public RegistredGuest()
        {

        }

        public Order CreateOrder()
        {
            
            Order order = new Order(this);
            while (true)
            {
                ViewProductsList();
                Console.WriteLine("Select the ID of the product you want to order:");
                string id = Console.ReadLine();
                for (int i = 0; i < ProductsLocalDB.GetProducts.Count; i++)
                {
                    if (id == Convert.ToString(ProductsLocalDB.GetProducts[i].ID))
                    {
                        order.AddProduct((ProductsLocalDB.GetProducts[i]));
                        Console.WriteLine("Product ordered successfully");
                        break;
                    }
                    else if (i == ProductsLocalDB.GetProducts.Count - 1 && id != Convert.ToString(ProductsLocalDB.GetProducts[i].ID))
                    {
                        Console.WriteLine("There is no product with this ID");
        
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Press 0 to exit order creation");
                if (Console.ReadLine() == "0")
                {
                    OrderLocalDB.Add(order,OrderLocalDB.GetOrders.Count+1);
                    break;
                }
            }
            return order;
        }
        public void OrderRegistration(string login)
        {
            if(ShowOrder(login) != null)
            {
                Console.WriteLine("Confirm order - 0, Cancel order - 1");
                string choice = Console.ReadLine();
                if (choice == "0")
                {
                    if(ShowOrder(login).Status == OrderStatus.New)
                    {
                        MenuBacker.BackMessage();
                    }
                }
                else if (choice == "1")
                {
                    OrderLocalDB.GetOrders.Remove(ShowOrder(login));
                    MenuBacker.BackMessage();
                }
                else
                {
                    Console.WriteLine("Wrong operation selected, revise your order and select operation");
                    OrderRegistration(login);
                }
            }
            else
            {
                return;
            }
        }

        public Order ShowOrder(string login)
        {
            for (int i = 0; i < OrderLocalDB.GetOrders.Count; i++)
            {
                if (OrderLocalDB.GetOrders[i].Receiver.Login == login)
                {
                    return OrderLocalDB.GetOrders[i];
                }
            }
            Console.WriteLine("No orders");
            return null;
        }
        public void ShowAllUserOrders(User current)
        {
            Console.WriteLine("All orders:");
            for (int i = 0; i < OrderLocalDB.GetOrders.Count; i++)
            {
                if (OrderLocalDB.GetOrders[i].Receiver.Login == (current as RegistredGuest).Login)
                {
                    foreach (var product in OrderLocalDB.GetOrders[i].GetOrder())
                    {
                        Console.WriteLine(product);
                    }
                    Console.WriteLine($"{ShowOrder((current as RegistredGuest).Login).Status}");
                }
            }
        }
        public void ChangeOrderStatus(string login)
        {
            Checker checker = new Checker();
            if(!checker.OrderisNull(ShowOrder(login)))
            {
                ShowOrder(login).Status = OrderStatus.Received;
                MenuBacker.BackMessage();
            }

        }
        public void ChangePersonalInformation()
        {
            Register changer = new Register();
            Checker checker = new Checker();
            Name = checker.CheckIsNotEmpty(changer.InputName());
            Lastname = checker.CheckIsNotEmpty(changer.InputSurname());
            Email = checker.CheckIsNotEmpty(changer.InputEmail());
            MenuBacker.BackMessage();
        }
        public void Exit()
        {
            rights = Rights.Guest;
            Console.WriteLine("You have successfully logged out");
        }

        public override string ToString()
        {
            return $"{Name}, {Lastname}, {Email}, Login:{Login}";
        }
    }
}
