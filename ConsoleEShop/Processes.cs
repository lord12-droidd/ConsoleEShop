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
                ShowMenu(current);
                string choice = Console.ReadLine();

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
                            if ((current as Guest).Enter())
                            {
                                current = new RegistredGuest(Rights.RegistredUser);
                                current.rights = Rights.RegistredUser;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        case "4":
                            if((current as Guest).EnterAsAdmin(current))
                            {
                                current = new Admin(Rights.Admin);
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
                            break;
                        case "1":
                            (current as RegistredGuest).SearchProduct();
                            break;
                        case "2":
                            (current as RegistredGuest).CreateOrder();
                            break;
                        case "3":
                            (current as RegistredGuest).OrderRegistration();
                            break;
                        case "4":
                            (current as RegistredGuest).OrderRegistration(); // історію замовлень доробити
                            break;
                        case "5":
                            (current as RegistredGuest).ChangeOrderStatus();
                            break;
                        case "6":
                            (current as RegistredGuest).ChangePersonalInformation();
                            break;
                        case "7":
                            (current as RegistredGuest).Exit();
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
                            break;
                        case "1":
                            (current as Admin).SearchProduct();
                            break;
                        case "2":
                            (current as Admin).CreateOrder();
                            break;
                        case "3":
                            (current as Admin).OrderRegistration();
                            break;
                        case "4":
                            (current as Admin).EditUserProfile();
                            break;
                        case "5":
                            (current as Admin).AddNewProduct();
                            break;
                        case "6":
                            (current as Admin).ViewProductsList();
                            (current as Admin).ChangeProductInformation();
                            break;
                        case "7":
                            (current as Admin).Exit();
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
