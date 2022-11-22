using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEADatabase
{
    internal class User
    {
        public string userName;

        public User(string Name)
        {
            this.userName = Name;
        }

        public string GetUserName()
        {
            return userName;
        }
    }
}
