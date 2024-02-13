namespace Group5_Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //creating the object of modern appliances
            ModernAppliances modernAppliances = new MyModernAppliances();
            //sets the base value to none for options

            modernAppliances.Options option = option.modernAppliances.None;
            modernAppliances.Options saveExit = option.ModernAppliances.saveExit;
            //while option does not equal save exit repeat loop
            while(option != saveExit) {
            
            //display the menu of modern appliances
            ModernAppliances.DisplayMenu();
            //read the line from display menu, and make option equal to whatever input they put in (options 1,2,3,4,5)
            option = Enum.Parse<ModernAppliances.Options>(Console.ReadLine());

            //if option is equal to 1, it will access checkout from modernAppliances
            if (option = 1) {

                modernAppliances.checkout();

            } 
            //if option equals 2, it will access find from modernAppliances
            else if (option = 2) {

                modernAppliances.Find();
            } 
            //if option equals 3, it will access displayType from modernAppliances
            else if (option = 3) {
                modernAppliances.DisplayType();
            } 
            //if option equals 4, it will access RandomList from modernAppliances
            else if (option = 4) {
                modernAppliances.RandomList();
            } 
            //if option equals 5, it will access SaveExit from modernAppliances
            else if (option = 5) {
                modernAppliances.SaveExit();
            } 
            //if option equals none of the possible options it will display this text
            else {
                Console.WriteLine("Invalid option entered. Please try again.");
            }
        }
    }
}
