using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    public static class UsersLocalDB
    {
        static private List<RegistredGuest> registredGuests = new List<RegistredGuest>() {
        new RegistredGuest("Dima","Melnyk","sfsdf@.com","Admin","Admin")};
        static public List<RegistredGuest> GetRegistredGuests
        {
            get
            {
                return registredGuests;
            }
        }
        static public string GetAdminlogin()
        {
            return registredGuests[0].Login;
        }
        static public string GetUserlogin(string login)
        {
            for(int i = 0; i < registredGuests.Count; i++)
            {
                if(login == registredGuests[i].Login)
                {
                    return registredGuests[i].Login;
                }
            }
            return null;
        }
        static public void Add(RegistredGuest guest)
        {
            registredGuests.Add(guest);
        }

    }
}
