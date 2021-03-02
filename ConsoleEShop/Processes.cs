using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    class Processes
    {
        public void Start()
        {
            User current = new Guest(Rights.Guest);
            while (true)
            {
                Console.WriteLine();
                ShowMenu(current);
                string choice = Console.ReadLine();
                Console.WriteLine();

                if (current.rights == Rights.Guest)
                {
                    switch (choice)
                    {
                        case "0":
                            (current as Guest).ViewProductsList();
                            break;
                        case "1":
                            (current as Guest).SearchProduct();
                            break;
                        case "2":
                            (current as Guest).Registration();
                            break;
                        case "3":
                            if ((current as Guest).Enter(ref current))
                            {
                               // current = new RegistredGuest(Rights.RegistredUser);
                                //current.rights = Rights.RegistredUser;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        case "4":
                            if((current as Guest).EnterAsAdmin(ref current))
                            {
                                //current = new Admin(Rights.Admin);
                                current.rights = Rights.Admin;
                                break;
                            }
                            break;
                    }
                }
                else if (current.rights == Rights.RegistredUser)
                {
                    switch (choice)
                    {
                        case "0":
                            (current as RegistredGuest).ViewProductsList();
                            Console.WriteLine();
                            break;
                        case "1":
                            (current as RegistredGuest).SearchProduct();
                            Console.WriteLine();
                            break;
                        case "2":
                            (current as RegistredGuest).CreateOrder();
                            Console.WriteLine();
                            break;
                        case "3":
                            (current as RegistredGuest).OrderRegistration((current as RegistredGuest).Login);
                            Console.WriteLine();
                            break;
                        case "4":
                            (current as RegistredGuest).ShowAllUserOrders(current); // історію замовлень доробити
                            Console.WriteLine();
                            break;
                        case "5":
                            (current as RegistredGuest).ChangeOrderStatus((current as RegistredGuest).Login);
                            Console.WriteLine();
                            break;
                        case "6":
                            (current as RegistredGuest).ChangePersonalInformation();
                            Console.WriteLine();
                            break;
                        case "7":
                            (current as RegistredGuest).Exit();
                            Console.WriteLine();
                            current = new Guest(Rights.Guest);
                            break;
                    }
                }
                else if (current.rights == Rights.Admin)
                {
                    switch (choice)
                    {
                        case "0":
                            (current as Admin).ViewProductsList();
                            Console.WriteLine();
                            break;
                        case "1":
                            (current as Admin).SearchProduct();
                            Console.WriteLine();
                            break;
                        case "2":
                            (current as Admin).CreateOrder();
                            Console.WriteLine();
                            break;
                        case "3":
                            (current as Admin).OrderRegistration((current as Admin).Login);
                            Console.WriteLine();
                            break;
                        case "4":
                            (current as Admin).EditUserProfile();
                            Console.WriteLine();
                            break;
                        case "5":
                            (current as Admin).AddNewProduct();
                            Console.WriteLine();
                            break;
                        case "6":
                            (current as Admin).ViewProductsList();
                            Console.WriteLine();
                            (current as Admin).ChangeProductInformation();
                            Console.WriteLine();
                            break;
                        case "7":
                            (current as Admin).ChangeOrdersStatus();
                            Console.WriteLine();
                            break;
                        case "8":
                            (current as Admin).Exit();
                            Console.WriteLine();
                            current = new Guest(Rights.Guest);
                            break;

                    }
                }

                
                
                
            }
        }
        public void ShowMenu(User current)
        {
            if(current.rights == Rights.Guest)
            {
                Console.WriteLine("Перегляд переліку товарів - 0");
                Console.WriteLine("Пошук товару за назвою - 1");
                Console.WriteLine("Реєстрація опікового запису користувача - 2");
                Console.WriteLine("Вхід до інтернет-магазину - 3");
                Console.WriteLine("Вхід до інтернет-магазину як адмін - 4");
            }
            else if (current.rights == Rights.RegistredUser)
            {
                Console.WriteLine("Перегляд переліку товарів - 0");
                Console.WriteLine("Пошук товару за назвою - 1");
                Console.WriteLine("Cтворення нового замовлення - 2");
                Console.WriteLine("Оформлення замовлення або відміна - 3");
                Console.WriteLine("Перегляд історії замовлень та статусу їх доставки - 4");
                Console.WriteLine("Встановлення статусу замовлення «Отримано» - 5");
                Console.WriteLine("Зміна персональної інформації - 6");
                Console.WriteLine("Вихід з облікового запису - 7");
            }
            else if (current.rights == Rights.Admin)
            {
                Console.WriteLine("Перегляд переліку товарів - 0");
                Console.WriteLine("Пошук товару за назвою - 1");
                Console.WriteLine("Cтворення нового замовлення - 2");
                Console.WriteLine("Оформлення замовлення або відміна - 3");
                Console.WriteLine("Перегляд та зміна персональної інформації користувачів; - 4");
                Console.WriteLine("Додавання нового товару - 5");
                Console.WriteLine("Зміна інформації про товар - 6");
                Console.WriteLine("Зміна статусу заломлення - 7");
                Console.WriteLine("Вихід з облікового запису - 8");
            }
            
        }

    }
}
