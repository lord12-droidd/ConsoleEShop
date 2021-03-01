using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    class AdminCreator : Creator
    {
        public override User FactoryMethod() { return new Admin(Rights.Admin); }
    }
}
