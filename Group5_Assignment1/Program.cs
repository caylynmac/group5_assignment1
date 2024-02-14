using Group5_Assignment1.Entities.Abstract;

namespace Group5_Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //creating the object of modern appliances
            ModernAppliances modernAppliances = new MyModernAppliances();
       

            //sets the base value to none for options

            //modernAppliances.Options option = option.ModernAppliances.None;
            //modernAppliances.Options saveExit = option.ModernAppliances.saveExit;

            int option = 0;

            //while option does not equal save exit repeat loop
            while (option != 5)
            {

                //display the menu of modern appliances
                modernAppliances.DisplayMenu();
                //read the line from display menu, and make option equal to whatever input they put in (options 1,2,3,4,5)

                Console.WriteLine("\nEnter option: ");

                int.TryParse(Console.ReadLine(), out option);

                //if option is equal to 1, it will access checkout from modernAppliances
                if (option == 1)
                {
                    modernAppliances.Checkout();
                }

                //if option equals 2, it will access find from modernAppliances to find all matching appliances with that brand
                else if (option == 2)
                {
                    modernAppliances.Find();
                }

                //if option equals 3, it will access displayType from modernAppliances to display all matching types of appliances
                else if (option == 3)
                {
                    modernAppliances.DisplayType();
                }
                //if option equals 4, it will access RandomList from modernAppliances
                else if (option == 4)
                {
                    modernAppliances.RandomList();

                }
                //if option equals 5, it will access SaveExit from modernAppliances
                else if (option == 5)
                {
                    modernAppliances.Save();
                }
                //if option equals none of the possible options it will display this text
                else
                {
                    Console.WriteLine("Invalid option entered. Please try again.");
                }
            }
        }
    }
}

