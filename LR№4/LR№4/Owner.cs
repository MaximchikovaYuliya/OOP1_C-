using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_4
{
    public partial class Vector
    {
        public class Owner
        {
            public int ID;
            public string Name;
            public string Organization;
            public Owner(int id, string name, string organization)
            {
                ID = id;
                Name = name;
                Organization = organization;
            }
        }
        Owner owner = new Owner(7675981, "Yuliya", "BSTU");
    }
}
