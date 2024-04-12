namespace Part1 {
    internal class Program {
        // global variables
        public static int numOfIngredients, numOfSteps;
        public static string line = "*******************************";
        public static string[,] ingredients;
        public static string[] steps;
        public static double scale = 1.0;
        public static bool exitMainLoop = false;

        static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to Part 1 of the recipe app");
            while (!exitMainLoop) {
                Console.WriteLine(line + "\nPlease select an action form the menu:");
                Console.WriteLine("Enter (1) to Enter the a new Recipe");
                Console.WriteLine("Enter (2) to Display the recipe ");
                Console.WriteLine("Enter (3) to Scale the quantities");
                Console.WriteLine("Enter (4) to Reset the quantities");
                Console.WriteLine("Enter (5) to Clear all Data");
                Console.WriteLine("Enter (6) Exit this application");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(line);
                Console.ForegroundColor = ConsoleColor.White;
                string responce = Console.ReadLine();

                if (responce.Equals("1"))
                {
                    GetRecipe();    
                } else if (responce.Equals("2"))
                {
                    DisplayRecipe();
                } else if (responce.Equals("3"))
                {
                    ScaleQuantity();
                } else if (responce.Equals("4"))
                {
                     ResetQuantities();
                } else if (responce.Equals("5"))
                {
                    ClearAllData();
                } else if (responce.Equals("6"))
                {
                    ExitApplication();
                }
            }

        }

        // Prompt for recipe
        public static void GetRecipe(){
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Please enter the number of ingredients: ");
            Console.ForegroundColor = ConsoleColor.White;
            numOfIngredients = Convert.ToInt32(Console.ReadLine());
            ingredients = new string[numOfIngredients, 3];  // define array size

            // Prompt ingredients
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(line);
            Console.WriteLine("Please enter the ingredients: ");
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < numOfIngredients; i++){
                Console.WriteLine("-> Ingredient " + (i + 1) + ": ");
                Console.Write("Name: ");
                ingredients[i,0] = Console.ReadLine();
                Console.Write("Quantity: ");
                ingredients[i,1] = Console.ReadLine();
                Console.Write("Unit Of Measurement: ");
                ingredients[i,2] = Console.ReadLine();
            }
            Console.WriteLine( "\n" + line + "\n");

            // Prompt Recipe Steps
            Console.WriteLine("Please enter the Number Of Steps in the recipe: ");
            numOfSteps = Convert.ToInt32(Console.ReadLine());
            steps = new string[numOfSteps];

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(line);
            Console.WriteLine("Please enter the steps for the recipe: ");
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < numOfSteps; i++)
            {
                Console.Write("Enter Step " + (i+1) + ": ");
                steps[i] = Console.ReadLine();
            }


        }

        public static void DisplayRecipe(){
            // Ingredients
            Console.WriteLine(line + "\nDispaying Ingredients\n" + line);
            for (int i = 0; i < numOfIngredients; i++){
                Console.WriteLine("Ingredient " + (i+1) + ":");
                Console.WriteLine("Name: " + ingredients[i,0]);
                Console.WriteLine("Quantity: " + (scale * Convert.ToDouble(ingredients[i,1])));
                Console.WriteLine("Unit Of Measurement: " + ingredients[i,2]);
                Console.WriteLine(line);
            }

            // Steps
            Console.WriteLine(line + "\nDispaying Steps For The Recipe\n" + line);
            for (int i = 0; i < numOfSteps; i++)
            {
                System.Console.WriteLine("Step " + (i+1) + ": " + steps[i]);
            }
        }

        public static void ScaleQuantity(){
            bool exitLoop = false;
            while (!exitLoop)
            {
                Console.WriteLine("Enter the scale factor (0,5 or 1,5 or 3)");
                double input = Convert.ToDouble(Console.ReadLine());
                if (input == 0.5 || input == 1.5 || input == 3){
                    scale = input;
                    exitLoop = true;
                } else {
                    Console.WriteLine("Input Invalid! Try again.");
                }
            }
        }

        public static void ResetQuantities(){
            scale = 1;
        }

        public static void ClearAllData(){
            ingredients = new string[0,0];
            numOfIngredients = 0;
            steps = Array.Empty<string>();
            numOfSteps = 0;
            ResetQuantities();
        }

        public static void ExitApplication(){
            Console.WriteLine("Thank You For Using The Application.");
            exitMainLoop = true;
        }

    }
}
