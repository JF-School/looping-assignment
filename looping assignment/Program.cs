namespace looping_assignment
{
    internal class Program
    {
        public static string enter = "Press [ENTER] to continue";
        public static Random generator = new Random();

        static void Main(string[] args)
        {
            while ((!Menu()));
        }

        public static bool Menu()
        {
            int choice;
            Console.WriteLine("       Which fun activity would you like to do?       ");
            Console.WriteLine("  1. Prompter     2. Planet Blorb ATM     3. Doubles  ");
            Console.WriteLine("                       4. Quit                        ");
            Console.WriteLine();
            Console.Write("Which activity? ");
            while ((!Int32.TryParse(Console.ReadLine(), out choice)) || (choice <= 0) || (choice > 4))
            {
                Console.WriteLine("Invalid input.");
                Console.WriteLine();
                Console.Write("Which activity? ");
            }
            Console.WriteLine();
            Console.Write(enter);
            Console.ReadLine();
            Console.Clear();
            
            // choices
            switch (choice)
            {
                case 1: // prompter game
                    Prompter();
                    break;
                case 2: // atm game
                    ATM();
                    break;
                case 3: // doubles game
                    Doubles();
                    break;
                case 4: // quit
                    return true;
            }
            return false;
        }

        private static void Prompter()
        {

        }

        private static void ATM()
        {

        }

        private static void Doubles()
        {

        }
    }
}
