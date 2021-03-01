using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    static class UsersLocalDB
    {
        static private List<RegistredGuest> registredGuests = new List<RegistredGuest>() {
        new RegistredGuest("Dima","Melnyk","sfsdf@.com","lord_12","English55")};
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
        static public void Add(RegistredGuest guest)
        {
            registredGuests.Add(guest);
        }
    }
}
