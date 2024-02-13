using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group5_Assignment1.Entities.Abstract;

namespace Group5_Assignment1.Entities
{
    internal class Dishwasher : Appliance
    {
        public const string Quietest = "Qt";
        public const string Quieter = "Qr";
        public const string Quiet = "Q";
        public const string Moderate = "M";

        private readonly string _feature;
        private readonly string _soundRating;

        public string Feature { get { return _feature; } }
        public string SoundRating { get { return _soundRating; } }

        public string SoundRatingDisplay
        {
            get
            {
                if (_soundRating == Quietest)
                    return "Quietest";
                else if (_soundRating == Quieter)
                    return "Quieter";
                else if (_soundRating == Quiet)
                    return "Quiet";
                else if (_soundRating == Moderate)
                    return "Moderate";
                else
                    return "Unknown";
            }
        }

        public Dishwasher(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price, string feature, string soundRating)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this._feature = feature;
            this._soundRating = soundRating;
        }

        public override string FormatForFile()
        {
            return $"{base.FormatForFile()};{_feature};{_soundRating}";
        }

        public override string ToString()
        {
            return $"Item Number: {ItemNumber}\n" +
                   $"Brand: {Brand}\n" +
                   $"Quantity: {Quantity}\n" +
                   $"Color: {Color}\n" +
                   $"Price: {Price}\n" +
                   $"Feature: {Feature}\n" +
                   $"Sound Rating: {SoundRatingDisplay}\n";
        }
    }
}
