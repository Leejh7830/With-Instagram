using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace With_Instagram
{
    public class User
    {
        public string ID { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return ID;
        }
    }
}
