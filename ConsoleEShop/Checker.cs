﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    class Checker : ICheck
    {
        public bool CheckStatus(int status)
        {
            switch (status)
            {
                case 0:
                    return true;
                case 1:
                    return true;
                case 2:
                    return true;
                case 3:
                    return true;
                case 4:
                    return true;
            }
            return false;
        }
        public bool CheckField(ref string field)
        {
            while (true)
            {
                if (field != "")
                {
                    return true;
                }
                Console.WriteLine("Field can`t be an empty");
                field = Console.ReadLine();
            }
        }
        public string CheckIsNotEmpty(string field)
        {
            while (true)
            {
                if (field != "")
                {
                    return field;
                }
                Console.WriteLine("Field can`t be an empty");
                field = Console.ReadLine();
            }
        }
        public bool CheckEmail(string email)
        {

            for (int i = 0; i < UsersLocalDB.GetRegistredGuests.Count; i++)
            {
                if (UsersLocalDB.GetRegistredGuests[i].Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckEnter(string login, string password)
        {
            for (int i = 0; i < UsersLocalDB.GetRegistredGuests.Count; i++)
            {
                if (UsersLocalDB.GetRegistredGuests[i].Login == login && UsersLocalDB.GetRegistredGuests[i].Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckAdminEnter(string login, string password)
        {
            if (UsersLocalDB.GetRegistredGuests[0].Login == login && UsersLocalDB.GetRegistredGuests[0].Password == password)
            {
                return true;
            }
            return false;
        }
        public bool CheckLogin(string login)
        {
            for (int i = 0; i < UsersLocalDB.GetRegistredGuests.Count; i++)
            {
                if (UsersLocalDB.GetRegistredGuests[i].Login == login)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckProductId(int id)
        {
            for (int i = 0; i < ProductsLocalDB.GetProducts.Count; i++)
            {
                if (ProductsLocalDB.GetProducts[i].ID == id)
                {
                    return true;
                }
            }
            return false;
        }
        public bool OrderisNull(Order order)
        {
            if(order == null)
            {
                return true;
            }
            return false;
        }
        public bool CheckOrderID(string id)
        {
            for(int i = 0; i < OrderLocalDB.GetOrders.Count; i++)
            {
                if(Convert.ToString(OrderLocalDB.GetOrders[i].ID) == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
