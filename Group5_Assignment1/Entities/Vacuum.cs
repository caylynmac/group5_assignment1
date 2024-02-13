using Group5_Assignment1.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Assignment1.Entities
{
    internal class Vacuum : Appliance
    {
        // Fields
        private readonly string _grade;
        private readonly short _batteryVoltage;

        // Properties
        public string Grade { get { return _grade; } }
        public short BatteryVoltage { get { return _batteryVoltage; } }

        // Constructor
        public Vacuum(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price, string grade, short batteryVoltage)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            _grade = grade;
            _batteryVoltage = batteryVoltage;
        }

        // Method
        public override string FormatForFile()
        {
            return $"{base.FormatForFile()};{_grade};{_batteryVoltage}";
        }

        public override string ToString()
        {
            return $"Item Number: {ItemNumber}\n" +
                   $"Brand: {Brand}\n" +
                   $"Quantity: {Quantity}\n" +
                   $"Color: {Color}\n" +
                   $"Price: {Price}\n" +
                   $"Grade: {_grade}\n" +
                   $"Battery Voltage: {_batteryVoltage}\n";
        }
    }
}
