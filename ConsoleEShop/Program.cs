using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleEShop
{
    enum Rights
    {
        Guest,
        RegistredUser,
        Admin,
    }
    enum OrderStatus
    {
        New,
        AdminDeny,
        PayReceived,
        Sent,
        Received,
        Completed,
        UserDeny,
    }
    interface ICheck
    {
        bool CheckProductId(int id);  //Коли адмін буде створювати товар, потрібно перевірити чи він створює товар з унікальним айді
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
        bool Enter();
    }
    interface IRegistred : IGuest
    {

    }
    class Program
    {
        public static User currentUser;
        static void Main(string[] args)
        {
            while (true)
            {

            }
        }
    }
    // зробити юзера який має статус, тому що ми повинні якось переходити з стану гостя в стан зареєстрованного користувача, при виконані методу Ентер, ми будемо міняти статус юзера з гостя на зарєганого чи адміна
    //тоді для цього нам потрібно додати поле із статусом в нашого юзера, можливо створити якийсь енам
    
}
