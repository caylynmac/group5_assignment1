using System;
using System.Collections.Generic;
using ModernAppliances.Entities;

namespace ModernAppliances
{
    internal class MyModernAppliances : ModernAppliances
    {
        public override void Checkout()
        {
            Console.Write("Enter the item number of an appliance: ");
            long itemNumber = long.Parse(Console.ReadLine());

            Appliance foundAppliance = null;

            foreach (Appliance appliance in Appliances)
            {
                if (appliance.ItemNumber == itemNumber)
                {
                    foundAppliance = appliance;
                    break; // Exit loop once the appliance is found
                }
            }

            if (foundAppliance == null)
            {
                Console.WriteLine("No appliances found with that item number.");
            }
            else
            {
                if (foundAppliance.IsAvailable)
                {
                    foundAppliance.Checkout();
                    Console.WriteLine("Appliance has been checked out.");
                }
                else
                {
                    Console.WriteLine("The appliance is not available to be checked out.");
                }
            }
        }

        public override void Find()
        {
            Console.Write("Enter brand to search for: ");
            string brandToSearch = Console.ReadLine();

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if (appliance.Brand == brandToSearch)
                {
                    foundAppliances.Add(appliance);
                }
            }

            DisplayAppliancesFromList(foundAppliances);
        }

        public override void DisplayRefrigerators()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("2 - Double doors");
            Console.WriteLine("3 - Three doors");
            Console.WriteLine("4 - Four doors");

            Console.Write("Enter number of doors: ");
            int numberOfDoors = int.Parse(Console.ReadLine());

            List<Appliance> foundRefrigerators = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Refrigerator refrigerator && (numberOfDoors == 0 || refrigerator.NumberOfDoors == numberOfDoors))
                {
                    foundRefrigerators.Add(appliance);
                }
            }

            DisplayAppliancesFromList(foundRefrigerators);
        }

        public override void DisplayVacuums()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Residential");
            Console.WriteLine("2 - Commercial");

            Console.Write("Enter grade: ");
            int grade = int.Parse(Console.ReadLine());

            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - 18 Volt");
            Console.WriteLine("2 - 24 Volt");

            Console.Write("Enter voltage: ");
            int voltage = int.Parse(Console.ReadLine());

            List<Appliance> foundVacuums = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Vacuum vacuum &&
                    (grade == 0 || (int)vacuum.Grade == grade) &&
                    (voltage == 0 || vacuum.Voltage == voltage))
                {
                    foundVacuums.Add(appliance);
                }
            }

            DisplayAppliancesFromList(foundVacuums);
        }

        public override void DisplayMicrowaves()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Kitchen");
            Console.WriteLine("2 - Work site");

            Console.Write("Enter room type: ");
            char roomType = char.ToUpper(Console.ReadLine()[0]);

            List<Appliance> foundMicrowaves = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Microwave microwave && (roomType == 'A' || microwave.RoomType == roomType))
                {
                    foundMicrowaves.Add(appliance);
                }
            }

            DisplayAppliancesFromList(foundMicrowaves);
        }

        public override void DisplayDishwashers()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Quietest");
            Console.WriteLine("2 - Quieter");
            Console.WriteLine("3 - Quiet");
            Console.WriteLine("4 - Moderate");

            Console.Write("Enter sound rating: ");
            string soundRating = Console.ReadLine();

            List<Appliance> foundDishwashers = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Dishwasher dishwasher && (soundRating == "0" || dishwasher.SoundRating == soundRating))
                {
                    foundDishwashers.Add(appliance);
                }
            }

            DisplayAppliancesFromList(foundDishwashers);
        }

        public override void RandomList()
        {
            Console.WriteLine("Appliance Types");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 – Refrigerators");
            Console.WriteLine("2 – Vacuums");
            Console.WriteLine("3 – Microwaves");
            Console.WriteLine("4 – Dishwashers");

            Console.Write("Enter type of appliance: ");
            int applianceType = int.Parse(Console.ReadLine());

            Console.Write("Enter number of appliances: ");
            int numberOfAppliances = int.Parse(Console.ReadLine());

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if ((applianceType == 0 || (applianceType == 1 && appliance is Refrigerator) ||
                    (applianceType == 2 && appliance is Vacuum) || (applianceType == 3 && appliance is Microwave) ||
                    (applianceType == 4 && appliance is Dishwasher)))
                {
                    foundAppliances.Add(appliance);
                }
            }

            foundAppliances.Sort(new RandomComparer());
            DisplayAppliancesFromList(foundAppliances, numberOfAppliances);
        }

        private void DisplayAppliancesFromList(List<Appliance> appliances, int maxItems = 0)
        {
            int count = 0;
            foreach (var appliance in appliances)
            {
                Console.WriteLine(appliance);
                count++;
                if (maxItems != 0 && count == maxItems)
                    break;
            }
        }
    }
}
