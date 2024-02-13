using Group5_Assignment1.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Assignment1.Entities
{
    internal class Microwave : Appliance
    {
        public const char RoomTypeKitchen = 'K';
        public const char RoomTypeWorkSite = 'W';
        private readonly float _capacity;
        private readonly char _roomType;

        public float Capacity { get { return _capacity; } }
        public char RoomType { get { return _roomType; } }

        public string RoomTypeDisplay
        {
            get
            {
                if (_roomType == RoomTypeKitchen)
                    return "Kitchen";
                else if (_roomType == RoomTypeWorkSite)
                    return "Work Site";
                else
                    return "Unknown";
            }
        }

        public Microwave(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price, float capacity, char roomType)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this._capacity = capacity;
            this._roomType = roomType;
        }

        public override string FormatForFile()
        {
            return $"{base.FormatForFile()};{_capacity};{_roomType}";
        }

        public override string ToString()
        {
            return $"Item Number: {ItemNumber}\n" +
                   $"Brand: {Brand}\n" +
                   $"Quantity: {Quantity}\n" +
                   $"Color: {Color}\n" +
                   $"Price: {Price}\n" +
                   $"Capacity: {Capacity}\n" +
                   $"Room Type: {RoomTypeDisplay}\n";
        }
    }
}
