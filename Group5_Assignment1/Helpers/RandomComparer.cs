using Group5_Assignment1.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Group5_Assignment1.Helpers
{
    internal class RandomComparer : IComparer<Appliance>
    {
        private readonly Random _random = new Random();

        public int Compare(Appliance x, Appliance y) => _random.Next(-1, 2);
    }
}
