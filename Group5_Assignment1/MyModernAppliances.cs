using Group5_Assignment1.Entities.Abstract;
using Group5_Assignment1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Group5_Assignment1
{

    internal class MyModernAppliances : ModernAppliances
    {
        public MyModernAppliances() :base() { }

        //option 1, check out appliance
        public override void Checkout()
        {
            //get item number from user
            Console.Write("\nEnter the item number of an Appliance: \n");
            long itemNumber = long.Parse(Console.ReadLine());

            Appliance foundAppliance = null;

            //iterate through list, find matching item number
            foreach (Appliance appliance in Appliances)
            {
                if (appliance.ItemNumber == itemNumber)
                {
                    foundAppliance = appliance;
                    break; // Exit loop once the appliance is found
                }
            }

            //state if found and then check if available
            //call checkout method from object to mark as unavailable
            if (foundAppliance == null)
            {
                Console.WriteLine("\nNo appliances found with that item number.\n");
            }
            else
            {
                if (foundAppliance.IsAvailable)
                {
                    foundAppliance.Checkout();
                    Console.WriteLine($"\nAppliance '{foundAppliance.ItemNumber}' has been checked out.\n");
                }
                else
                {
                    Console.WriteLine("\nThe appliance is not available to be checked out.\n");
                }
            }
        }

        //option 2, find appliances by brand
        public override void Find()
        {
            //ask for brand name
            Console.WriteLine("\nEnter brand to search for: \n");
            string brandToSearch = Console.ReadLine();

            //list to store found appliances
            List<Appliance> foundAppliances = new List<Appliance>();

            //iterate through list, add matching objects to found list
            foreach (Appliance appliance in Appliances)
            {
                if (appliance.Brand == brandToSearch)
                {
                    foundAppliances.Add(appliance);
                }
            }
            Console.WriteLine("\nMatching Appliances:\n");
            //call function to display list
            DisplayAppliancesFromList(foundAppliances);
        }

        //option 3 - 1 display refridgerators
        public override void DisplayRefrigerators()
        {
            //get number of doors
            Console.Write("\nEnter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):\n");
            int numberOfDoors = int.Parse(Console.ReadLine());

            //list for found refrigerator objects
            List<Appliance> foundRefrigerators = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if ((appliance.Type == "Refrigerator"))
                {
                    Refrigerator refrigerator = (Refrigerator)appliance; //cast appliance to refrigerator to access doors

                    if (refrigerator.Doors == numberOfDoors)
                    {
                        foundRefrigerators.Add(refrigerator);
                    }
                }
            }

            Console.WriteLine("\nMatching refrigerators:\n");
            DisplayAppliancesFromList(foundRefrigerators);

        }

        //option 3 - 2 display vacuums
        public override void DisplayVacuums()
        {
            //display 

            Console.Write("\nEnter battery voltage value. 18 V (low) or 24 V (high)\n");
            int voltage = int.Parse(Console.ReadLine());

            List<Appliance> foundVacuums = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if ((appliance.Type == "Vacuum"))
                {
                    Vacuum vacuum = (Vacuum)appliance; //cast appliance to vacuum to access voltage

                    if (vacuum.BatteryVoltage == voltage)
                    {
                        foundVacuums.Add(vacuum);
                    }
                }
            }

            Console.WriteLine("\nMatching Vacuums:\n");
            DisplayAppliancesFromList(foundVacuums);
        }

        //option 3- 3 display microwaves
        public override void DisplayMicrowaves()
        {
            //ask for room type

            Console.Write("\nRoom where the microwave will be installed: K (kitchen) or W (work site): \n");
            char roomType = char.ToUpper(Console.ReadLine()[0]);

            //empty list for found microwaves
            List<Appliance> foundMicrowaves = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if ((appliance.Type == "Microwave"))
                {
                    Microwave microwave = (Microwave)appliance; 

                    if (microwave.RoomType == roomType)
                    {
                        foundMicrowaves.Add(microwave);
                    }
                }
            }
            Console.WriteLine("\nMatching microwaves:\n");
            DisplayAppliancesFromList(foundMicrowaves);
        }

        //option 3 - 4 display dishwashers
        public override void DisplayDishwashers()
        {

            //ask for sound rating

            Console.Write("\nEnter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):\n");
            string soundRating = Console.ReadLine();

            //empty list for found dishwasher
            List<Appliance> foundDishwashers = new List<Appliance>();

            //iterate through appliance list, find matches
            foreach (Appliance appliance in Appliances)
            {
                if ((appliance.Type == "Dishwasher"))
                {
                    Dishwasher dishwasher = (Dishwasher)appliance; //cast appliance to vacuum to access voltage

                    if (dishwasher.SoundRating == soundRating)
                    {
                        Console.WriteLine(dishwasher);
                        foundDishwashers.Add(dishwasher);
                    }
                }
            }
            Console.WriteLine("\nMatching Dishwashers:\n");
            DisplayAppliancesFromList(foundDishwashers);
        }

        //option 4
        public override void RandomList()
        {
            //get number of appliances for list
            Console.Write("\nEnter number of appliances: \n");
            int numberOfAppliances = int.Parse(Console.ReadLine());

            //length of Appliances list
            int length = Appliances.Count;

            int randIndex;
            var rand = new Random();

            //empty list for found appliances
            List<Appliance> foundAppliances = new List<Appliance>();

            //generate random numbers between 0 and length of appliances up to user requested number of appliances
            for (int i = 0; i <= (numberOfAppliances-1); i++)
            {
                randIndex = rand.Next((length));

                //add indexed appliance to new random list
                foundAppliances.Add(Appliances[randIndex]);
            }

            Console.WriteLine("\nRandom appliances:\n");
            DisplayAppliancesFromList(foundAppliances);
        }
    }
}
