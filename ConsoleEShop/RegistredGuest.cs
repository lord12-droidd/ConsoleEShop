using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    class RegistredGuest : Guest, IRegistred
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

        public Order CreateOrder()
        {
            
            Order order = new Order(this);
            while (true)
            {
                ViewProductsList();
                Console.WriteLine("Выберите айди товара который хотите заказать:");
                string id = Console.ReadLine();
                for (int i = 0; i < ProductsLocalDB.GetProducts.Count; i++)
                {
                    if (id == Convert.ToString(ProductsLocalDB.GetProducts[i].ID))
                    {
                        order.AddProduct((ProductsLocalDB.GetProducts[i]));
                        Console.WriteLine("Товар успешно заказан");
                        break;
                    }
                    else if (i == ProductsLocalDB.GetProducts.Count - 1 && id != Convert.ToString(ProductsLocalDB.GetProducts[i].ID))
                    {
                        Console.WriteLine("Товара с таким айди не существует");
        
                    }
                }
                Console.WriteLine("Нажмите 0 чтобы выйти из создания заказа");
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
                Console.WriteLine("Подтвердить заказ - 0, Отменить заказ - 1");
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
                    Console.WriteLine("Выбрана неправильная операция, пересмотрите ваш заказ и выберите операцию");
                    OrderRegistration(login);
                }
            }
            else
            {
                return;
            }
        }

        public Order ShowOrder(string login)  // can be void
        {
            for (int i = 0; i < OrderLocalDB.GetOrders.Count; i++)
            {
                if (OrderLocalDB.GetOrders[i].Receiver.Login == login)
                {
                    return OrderLocalDB.GetOrders[i];
                }
            }
            Console.WriteLine("Немає замовлень");
            return null;
        }
        public void ShowAllUserOrders(User current)
        {
            Console.WriteLine("Всі замовлення:");
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
            Console.WriteLine("Ви успішно вийшли");
        }

        public override string ToString()
        {
            return $"{Name}, {Lastname}, {Email}, Login:{Login}";
        }
    }
}
