using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group5_Assignment1.Entities.Abstract;

namespace Group5_Assignment1 
{
    //randomize list using Icomparer system interface
    internal class RandomComparer : IComparer<Appliance>
    {
        private readonly Random _random = new Random();
        public int Compare(Appliance x, Appliance y)
        {
            if (x == y)
            {
                return 0;
            }

            return _random.Next(-1, 1);
        }
    }
}

