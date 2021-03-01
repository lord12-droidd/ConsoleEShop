using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    class RegisterUserCreator : Creator
    {
        public override User FactoryMethod() { return new RegistredGuest(Rights.RegistredUser); }
    }
}
