using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleEShop
{
    public enum Rights
    {
        Guest,
        RegistredUser,
        Admin,
    }
    public enum OrderStatus
    {
        New,
        AdminDeny,
        PayReceived,
        Sent,
        Completed,
        Received,
        UserDeny,
    }
    interface ICheck
    {
        bool CheckProductId(int id);
        bool CheckField(ref string field);
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
        bool Enter(ref User user);
    }
    interface IRegistred : IGuest
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            Processes processes = new Processes();
            processes.Start();
            Console.ReadKey();
        }
    }
    
}
