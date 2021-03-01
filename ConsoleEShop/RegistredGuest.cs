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
            private set { _login = value; }
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

        protected Order CreateOrder()
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
                        MenuBacker.BackMessage();
                    }
                    if (i == ProductsLocalDB.GetProducts.Count - 1 && id != Convert.ToString(ProductsLocalDB.GetProducts[i].ID))
                    {
                        Console.WriteLine("Товара с таким айди не существует");
        
                    }
                }
                Console.WriteLine("Нажмите 1 чтобы выйти из создания заказа");
                if (Console.ReadLine() == "1")
                {
                    break;
                }
            }
            return order;
        }
        public void OrderRegistration()
        {
            ShowOrder();
            Console.WriteLine("Подтвердить заказ - 0, Отменить заказ - 1");
            string choice = Console.ReadLine();
            if (choice == "0")
            {
                OrderLocalDB.GetOrders.Add(ShowOrder());
                MenuBacker.BackMessage();
            }
            else if (choice == "1")
            {
                OrderLocalDB.GetOrders.Remove(ShowOrder());
                MenuBacker.BackMessage();
            }
            else
            {
                Console.WriteLine("Выбрана неправильная операция, пересмотрите ваш заказ и выберите операцию");
                OrderRegistration();
            }
        }

        public Order ShowOrder()  // can be void
        {
            for (int i = 0; i < OrderLocalDB.GetOrders.Count; i++)
            {
                if (OrderLocalDB.GetOrders[i].Receiver == this)
                {
                    OrderLocalDB.GetOrders[i].GetOrder().ToString();
                    return OrderLocalDB.GetOrders[i];
                }
            }
            return null;
        }
        //TODO: перегляд історії замовлень та статусу їх доставки
        public void ChangeOrderStatus()
        {
            ShowOrder().Status = OrderStatus.Received;
            MenuBacker.BackMessage();
        }
        public void ChangePersonalInformation(RegistredGuest guest)  // можно убрать параметр так как он будет меня гостя которого передали, а не себя самого
        {
            Register changer = new Register();
            guest.Name = changer.InputName();
            guest.Lastname = changer.InputSurname();
            guest.Email = changer.InputEmail();
            MenuBacker.BackMessage();
        }
        public int Exit()
        {
            rights = Rights.Guest;
            return (int)rights;
        }

        public override string ToString()
        {
            return $"{Name}, {Lastname}, {Email}, Login:{Login}";
        }
    }
}
