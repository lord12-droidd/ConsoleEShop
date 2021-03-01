using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    class GuestCreator : Creator
    {
        public override User FactoryMethod() { return new Guest(Rights.Guest); }
    }
}
