using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group5_Assignment1.Entities.Abstract;

namespace Group5_Assignment1.Entities
{
    internal class Microwave : Appliance
    {
        //private fields
        private float _capacity;
        private char _roomType;

        //room type constants

        public const char RoomTypeKitchen = 'K';
        public const char RoomTypeWorksite = 'W';

        //properties
        public float Capacity
        {
            get { return _capacity; }
        }

        public char RoomType
        {
            get { return _roomType; }
        }

        //returns a word for the display
        public string RoomTypeDisplay
        {
            get
            {
                switch (_roomType)
                {
                    case RoomTypeKitchen:
                        return "Kitchen";
                    case RoomTypeWorksite:
                        return "Work Site";
                    default:
                        return "(Unknown)";
                }
            }
        }

        //constructor
        public Microwave(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price, float capacity, char roomType) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this._capacity = capacity;
            this._roomType = roomType;
        }

        public override string FormatForFile()
        {
            return string.Join(';', base.FormatForFile(), this._capacity, this._roomType);
        }

        public override string ToString()
        {
            string s =

                $"Item Number: {ItemNumber}\n" +
                $"Brand: {Brand}\n" +
                $"Quantity: {Quantity}\n" +
                $"Wattage: {Wattage}\n" +
                $"Color: {Color}\n" +
                $"Price: {Price}\n" +
                $"Capacity: {_capacity}\n" +
                $"Room Type: {_roomType}\n";

            return s;

        }
    }
}
