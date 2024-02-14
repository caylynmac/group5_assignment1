using Group5_Assignment1.Entities.Abstract;
using Group5_Assignment1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Group5_Assignment1
{
    internal abstract class ModernAppliances
    {
            //constants

            //file path
            public const string APPLIANCES_TEXT_FILE = "..\\..\\..\\appliances.txt"; //bypasses debug folders to get to Group5_assignment1 folder
            public enum Options
            {
                None,
                Checkout = 1,
                FindBrand = 2,
                DisplayType = 3,
                RandomList = 4,
                SaveExit = 5,
            }

            //menu string

            public const string menu =
            $"Welcome to Modern Appliances!\n" +
            "How May We Assist You?\n" +
            "1 – Check out appliance\n" +
            "2 – Find appliances by brand\n" +
            "3 – Display appliances by type\n" +
            "4 – Produce random appliance list\n" +
            "5 – Save & exit";

        //private appliances list field
        private List<Appliance> appliances = new List<Appliance>();


            //appliance list get property
            public List<Appliance> Appliances
            {
                get
                {
                return appliances;
            }
            }

            //constructor
            public ModernAppliances()
            {
                //read data file, create appliance objects, add to appliances list
                this.appliances = this.ReadAppliances();
            }
            //abstract methods

            public abstract void Checkout();
            public abstract void Find();
            public abstract void DisplayRefrigerators();

            public abstract void DisplayVacuums();

            public abstract void DisplayMicrowaves();

            public abstract void DisplayDishwashers();

            public abstract void RandomList();


        //parse text file, fill list
        public List<Appliance> ReadAppliances()
        {
            //array of string lines from file

            string[] lines = File.ReadAllLines(APPLIANCES_TEXT_FILE);

            foreach (string line in lines)
            {
                Appliance? appliance = this.CreateApplianceFromLine(line);
                if (appliance != null)
                {
                    appliances.Add(appliance);
                    Console.WriteLine(appliance.Type);
                }

            }

            return appliances;
        }

        private Appliance? CreateApplianceFromLine(string line) //nullable ?
        {
            //looks at first digit of item number, then calls appropriate create function 

            //split line into string array to be passed to create function based on ; delimeter
            string[] parts = line.Split(';');

            //look at item number (index 0) first digit
            char firstDigitStr = line[0];
            Appliance? appliance;

            //subtract chars via unicode values ('0' = 48), get digits 0-9 as a corresponding int value
            int firstDigit = firstDigitStr - '0';

            if (firstDigit == 1) //refridgerator
            {
                appliance = CreateRefrigeratorFromParts(parts);
            }
            else if (firstDigit == 2)//vacuum
            {
                appliance = CreateVacuumFromParts(parts);
            }
            else if (firstDigit == 3) //microwave
            {
                appliance = CreateMicrowaveFromParts(parts);
            }
            else if (firstDigit == 4 || firstDigit == 5) //dishwasher
            {
                appliance = CreateDishwasherFromParts(parts); 
            }
            else
            {
                appliance = null; 
            }

            return appliance;
        }

        private Refrigerator? CreateRefrigeratorFromParts(string[] parts)
        {
            //convert indexes to correct types
            long itemNumber = long.Parse(parts[0]);
            string brand = parts[1];
            int quantity = int.Parse(parts[2]);
            decimal wattage = decimal.Parse(parts[3]);
            string color = parts[4];
            decimal price = decimal.Parse(parts[5]);
            short doors = short.Parse(parts[6]);
            int width = int.Parse(parts[7]);
            int height = int.Parse(parts[8]);

            //create refrigerator object
            Refrigerator refrigerator = new Refrigerator(itemNumber, brand, quantity, wattage, color, price, doors, width, height);

            return refrigerator;
        }

        private Vacuum CreateVacuumFromParts(string[] parts)
        {

            long itemNumber = long.Parse(parts[0]);
            string brand = parts[1];
            int quantity = int.Parse(parts[2]);
            decimal wattage = decimal.Parse(parts[3]);
            string color = parts[4];
            decimal price = decimal.Parse(parts[5]);
            string grade = parts[6];
            short batteryVoltage = short.Parse(parts[7]);

            Vacuum vacuum = new Vacuum(itemNumber, brand, quantity, wattage, color, price, grade, batteryVoltage);

            return vacuum;
        }

        private Microwave CreateMicrowaveFromParts(string[] parts)
        {
            long itemNumber = long.Parse(parts[0]);
            string brand = parts[1];
            int quantity = int.Parse(parts[2]);
            decimal wattage = decimal.Parse(parts[3]);
            string color = parts[4];
            decimal price = decimal.Parse(parts[5]);
            float capacity = float.Parse(parts[6]);
            char roomType = char.Parse(parts[7]);

            Microwave microwave = new Microwave(itemNumber, brand, quantity, wattage, color, price, capacity, roomType);

            return microwave;
        }

        private Dishwasher CreateDishwasherFromParts(string[] parts)
        {

            long itemNumber = long.Parse(parts[0]);
            string brand = parts[1];
            int quantity = int.Parse(parts[2]);
            decimal wattage = decimal.Parse(parts[3]);
            string color = parts[4];
            decimal price = decimal.Parse(parts[5]);
            string feature = parts[6];
            string soundRating = parts[7];

            Dishwasher dishwasher = new Dishwasher(itemNumber, brand, quantity, wattage, color, price, feature, soundRating);

            return dishwasher;
        }

        public void DisplayMenu()
        {
            Console.WriteLine(menu);
        }

        //display type method, option 3
        public void DisplayType()
            {
                Console.WriteLine("\nAppliance Types");
                Console.WriteLine("1 – Refrigerators");
                Console.WriteLine("2 – Vacuums");
                Console.WriteLine("3 – Microwaves");
                Console.WriteLine("4 – Dishwashers");

                Console.Write("\nEnter type of appliance:\n");
                
                //get input, convert to int, then check if it's in 1,2,3,4 array
                int.TryParse(Console.ReadLine(), out int applianceTypeNum);

                int[] typesNum = { 1,2,3,4};
                
                //if not in, print error and return null
                if (!typesNum.Contains(applianceTypeNum))
                {
                    Console.WriteLine("\nInvalid appliance type entered.");
                    return;
                }

                //display all based on type input
                if(applianceTypeNum == 1) {this.DisplayRefrigerators();}

                else if(applianceTypeNum == 2) {this.DisplayVacuums();}


                else if(applianceTypeNum == 3){this.DisplayMicrowaves();}

                else if(applianceTypeNum == 4 || applianceTypeNum == 5){ this.DisplayDishwashers(); }

                else{Console.WriteLine("\nInvalid appliance type entered.");}
                }


        //called my other methods after making sub-lists
        public void DisplayAppliancesFromList(List<Appliance> appliances)
            {
                if (appliances.Count() > 0)// if there is at least 1 appliance in the list
                {
                    // Display found appliances until either end of list is reached or number of appliances requested is shown.
                    foreach (var appliance in appliances)
                    {
                        //Appliance appliance = appliances[i];

                        Console.WriteLine(appliance);
                        Console.WriteLine();
                     }
                }
                else
                {
                    Console.WriteLine("No appliances found :(");
                }

                Console.WriteLine();
            }

        //option 5 save method
        public void Save()
        {

            using (StreamWriter file = File.CreateText(APPLIANCES_TEXT_FILE))
            {
                foreach (Appliance appliance in appliances)
                {
                    file.WriteLine(appliance.FormatForFile());
                    //writes ; delimited string to file
                }
            }

            Console.WriteLine("File saved!");
        }
    }
}


