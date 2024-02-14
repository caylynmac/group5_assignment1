using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Assignment1.Entities.Abstract
{
    internal abstract class Appliance
    {

        //private fields

        private readonly string _brand;
        private readonly string _color;
        private readonly long _itemNumber;
        private readonly decimal _price;
        private int _quantity;
        private readonly decimal _wattage;

        //properties
        public string Brand { get { return _brand; } }

        public string Color { get { return _color; } }

        public long ItemNumber { get { return _itemNumber; } }

        public decimal Price { get { return _price;} }

        public int Quantity { get { return _quantity;} }    

        public decimal Wattage { get { return _wattage;} }      

        public bool IsAvailable //returns tre if quantity greater than 0
        {  get 
            {
                bool isAvalaible = Quantity > 0; // returns true if quantity > 0
                return isAvalaible; 
            } 
        }

        public string Type
        {  get 
            {
                
                return DetermineAppliance(_itemNumber);
            } 
        }
        
        //constructors
        protected Appliance(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price)//order of values stored in text file
        {
            this._brand = brand;
            this._color = color;
            this._itemNumber = itemNumber;
            this._price = price;
            this._quantity = quantity;
            this._wattage = wattage;
        }
            
        //methods

        //checkout appliance, reduce quantity by 1, no return needed
        public void Checkout()
        {
            this._quantity = this._quantity - 1;
        }
        public string DetermineAppliance(long itemNumber) 
        {
            //convert item number to string, get first index
            char firstDigitStr = itemNumber.ToString()[0];
            int firstDigit = firstDigitStr - '0'; //returns int value between 1 and 9

            if (firstDigit == 1)
            {
                //refrigerator
                return "Refrigerator";
            }
            else if (firstDigit == 2)
            {
                //vacuum
                return "Vacuum";
            }
            else if (firstDigit == 3)
            {
                //microwave
                return "Microwave";
            }
            else if (firstDigit == 4 || firstDigit == 5)
            {
                //dishwasher
                return "Dishwasher";
            }
            else
            { return "Unknown"; }
        }
        public virtual string FormatForFile()
        {
            return string.Join(';', this._brand, this._color, this._itemNumber, this._quantity, this._wattage, this._price);
        }
    }
}
