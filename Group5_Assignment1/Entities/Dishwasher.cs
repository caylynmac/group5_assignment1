using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Group5_Assignment1.Entities.Abstract;
namespace Group5_Assignment1.Entities
{
    internal class Dishwasher : Appliance
    {
        //sound rating constants

        public const string SoundRatingModerate = "M";
        public const string SoundRatingQuiet = "Qu";
        public const string SoundRatingQuieter = "Qr";
        public const string SoundRatingQuietest = "Qt";

        //private fields
        private string _feature;
        private string _soundRating;

        //properties
        public string Feature
        {
            get { return _feature; }
        }

        public string SoundRating
        {
            get { return _soundRating; }
        }

        //returns a word for the display
        public string SoundRatingDisplay
        {
            get
            {
                switch (_soundRating)
                {
                    case SoundRatingModerate:
                        return "Moderate";
                    case SoundRatingQuiet:
                        return "Quiet";
                    case SoundRatingQuieter:
                        return "Quieter";
                    case SoundRatingQuietest:
                        return "Quietest";
                    default:
                        return "(Unknown)";
                }
            }
        }

        //constructor
        //passes arguments to base class constructor
        public Dishwasher(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price, string feature, string soundRating) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this._feature = feature;
            this._soundRating = soundRating;
        }

        public override string FormatForFile()
        {
            return string.Join(';', base.FormatForFile(), this._feature, this._soundRating); 
            //concatenates additional dishwasher fields to common appliance fields formatted in appliance class
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
                $"Feature: {_feature}\n" +
                $"SoundRating: {_soundRating}\n";

            return s;
         
        }

}
}
