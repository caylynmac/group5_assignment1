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
        public enum ApplianceTypes
        {
            Unknown,
            Refrigerator = 1,
            Vacuum = 2,
            Microwave = 3,
            Dishwasher = 4 //or 5??
        }

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
                bool isAvalaible = Quantity > 0; //???
                return isAvalaible; 
            } 
        }

        public string Type
        {  get 
            {
                return "type";
            } 
        }
        
        //constructors
        protected Appliance(string brand, string color, long itemNumber, decimal price, int quantity, decimal wattage)
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
        public static ApplianceTypes DetermineAppliance(long itemNumber) //return string static item from enumeration?
        {
            //convert item number to string, get first index
            char firstDigitStr = itemNumber.ToString()[0];
            int firstDigit = firstDigitStr - '0'; //returns int value between 1 and 9

            if (firstDigit == 1)
            {
                //refrigerator
                return ApplianceTypes.Refrigerator;
            }
            else if (firstDigit == 2)
            {
                //vacuum
                return ApplianceTypes.Vacuum;
            }
            else if (firstDigit == 3)
            {
                //microwave
                return ApplianceTypes.Microwave;
            }
            else if (firstDigit == 4 || firstDigit == 5)
            {
                //dishwasher
                return ApplianceTypes.Dishwasher;
            }
            else
            { return ApplianceTypes.Unknown; }
        }
        public virtual string FormatForFile()
        {
            return string.Join(';', this._brand, this._color, this._itemNumber, this._quantity, this._wattage, this._price);
        }
    }
}
