using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    static class UsersLocalDB
    {
        static private List<RegistredGuest> registredGuests = new List<RegistredGuest>();
        static public List<RegistredGuest> GetRegistredGuests
        {
            get
            {
                return registredGuests;
            }
        }
        static public void Add(RegistredGuest guest)
        {
            registredGuests.Add(guest);
        }
    }
}
