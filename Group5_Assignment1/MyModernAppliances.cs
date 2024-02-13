using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Assignment1
{
    internal abstract class ModernAppliances
    {
            //constants

            //file path
            public const string APPLIANCES_TEXT_FILE = "C:\\cprg211\\assignments\\assignment-1\\Group5_Assignment1\\appliances.txt";
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
            private List<Appliance> appliances; //make readonly?


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

        //parse text file, fill list
        private List<Appliance> ReadAppliances()
        {
            //List<Appliance> appliances = new List<Appliance>();
            string[] lines = File.ReadAllLines(APPLIANCES_TEXT_FILE);

            foreach (string line in lines)
            {
                Appliance appliance = this.CreateApplianceFromLine(line);

                if (appliance != null)
                {
                    appliances.Add(appliance);
                }
            }

            return appliances;
        }

        private Appliance CreateApplianceFromLine(string line)
        {
            //looks at first digit of item number, then calls appropriate create function 

            //split line into string array to be passed to create function based on ; delimeter
            string[] parts = line.Split(';');

            //look at item number (index 0) first digit
            char firstDigitStr = line[0];

            //subtract chars via unicode values ('0' = 48), get digits 0-9 as a corresponding int value
            int firstDigit = firstDigitStr - '0';

            if (firstDigit == 1) //refridgerator
            {
                Appliance appliance = CreateRefrigeratorFromParts(parts);
            }
            else if (firstDigit == 2)//vacuum
            {
                Appliance appliance = CreateVacuumFromParts(parts);
            }
            else if (firstDigit == 3) //microwave
            {
                Appliance appliance = CreateMicrowaveFromParts(parts);
            }
            else if (firstDigit == 4 || firstDigit == 5) //dishwasher
            {
                Appliance appliance = (Dishwasher)CreateDishwasherFromParts(parts); //should cast??
            }
            else
            {
                Appliance appliance = null; 
            }

            return appliance;
        }

        private Refrigerator CreateRefrigeratorFromParts(string[] parts)
        {
            //if (parts.Length != 9)
            //    return null;

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
            //if (parts.Length != 8)
            //    return null;

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
            //if (parts.Length != 8)
            //    return null;

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
            //if (parts.Length != 8)
            //    return null;

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

    //abstract methods
        public abstract void DisplayRefrigerators();

        public abstract void DisplayVacuums();

        public abstract void DisplayMicrowaves();

        public abstract void DisplayDishwashers();

        public abstract void RandomList();

        public abstract void Checkout();

        public abstract void Find();

        public void DisplayMenu()
        {
            Console.WriteLine(menu);
        }

        //display type method, option 3
        public void DisplayType()
            {
                Console.WriteLine("Appliance Types");
                Console.WriteLine("1 – Refrigerators");
                Console.WriteLine("2 – Vacuums");
                Console.WriteLine("3 – Microwaves");
                Console.WriteLine("4 – Dishwashers");

                Console.Write("Enter type of appliance:");

                int applianceTypeNum;
                bool parsedApplianceType = int.TryParse(Console.ReadLine(), out applianceTypeNum);

                if (!parsedApplianceType || applianceTypeNum < 0 || applianceTypeNum > 4)
                {
                    Console.WriteLine("Invalid appliance type entered.");
                    return;
                }

                switch (applianceTypeNum)
                {
                    case 1:
                        {
                            this.DisplayRefrigerators();

                            break;
                        }

                    case 2:
                        {
                            this.DisplayVacuums();

                            break;
                        }

                    case 3:
                        {
                            this.DisplayMicrowaves();

                            break;
                        }

                    case 4:
                        {
                            this.DisplayDishwashers();

                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Invalid appliance type entered.");

                            break;
                        }
                }
            }

            public void Save()
            {
                Console.Write("Saving... ");

                StreamWriter fileStream = File.CreateText(APPLIANCES_TEXT_FILE);

                foreach (var appliance in appliances)
                {
                    fileStream.WriteLine(appliance.FormatForFile());
                }

                fileStream.Close();

                Console.WriteLine("DONE!");
            }

 

            public void DisplayAppliancesFromList(List<Appliance> appliances, int max)
            {
                if (appliances.Count > 0)
                {
                    Console.WriteLine("Found appliances:");
                    Console.WriteLine();

                    // Display found appliances until either end of list is reached or number of appliances requested is shown.
                    for (int i = 0; i < appliances.Count && (max == 0 || i < max); i++)
                    {
                        Appliance appliance = appliances[i];
                        Console.WriteLine(appliance);
                        Console.WriteLine();
                    }

                }
                else
                {
                    Console.WriteLine("No appliances found.");
                }

                Console.WriteLine();
            }
        }
    }
