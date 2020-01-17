using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    partial class User
    {
        public bool IsNotType(params UserType[] types )
        {
            foreach(UserType t in types){
                if (t != type)
                    return true;
            }
            return false;
        }
    }
}
