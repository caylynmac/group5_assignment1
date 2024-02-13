using Group5_Assignment1.Entities.Abstract;
using Group5_Assignment1.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Assignment1.Entities
{
    internal class Refrigerator : Appliance
    {
        //Fields
        private readonly short _doors;
        private readonly int _width;
        private readonly int _height;

        // Properties
        public short Doors { get { return _doors; } }
        public int Width { get { return _width; } }
        public int Height { get { return _height; } }

        // Constructor
        public Refrigerator(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price, short doors, int width, int height)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this._doors = doors;
            this._width = width;
            this._height = height;
        }

        // Method
        public override string FormatForFile()
        {
            return $"{base.FormatForFile()};{_doors};{_width};{_height}";
        }

        public override string ToString()
        {
            return $"Item Number: {ItemNumber}\n" +
                   $"Brand: {Brand}\n" +
                   $"Quantity: {Quantity}\n" +
                   $"Color: {Color}\n" +
                   $"Price: {Price}\n" +
                   $"Doors: {Doors}\n" +
                   $"Width: {Width}\n" +
                   $"Height: {Height}\n";
        }
    }
}
