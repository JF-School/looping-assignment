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

        public static void TypeText(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(25);
            }
            Console.WriteLine();

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

        public static void Prompter()
        {
            double minValue, maxValue, num;
            Console.WriteLine("-------------PROMPTER-------------");
            Console.Write("Enter a minimum value: ");
            while ((!Double.TryParse(Console.ReadLine(), out minValue)) || (minValue < 0))
            {
                Console.WriteLine("Invalid Input.");
                Console.Write("Enter a minimum value: ");
            }
            Console.Write("Enter a maximum value: ");
            while ((!Double.TryParse(Console.ReadLine(), out maxValue)) || (maxValue < minValue))
            {
                Console.WriteLine("Invalid Input.");
                Console.Write("Enter a maximum value: ");
            }
            Console.WriteLine();
            Console.Write($"Enter a number between {minValue} and {maxValue}: ");
            while ((!Double.TryParse(Console.ReadLine(), out num)) || (num < minValue) || (num > maxValue))
            {
                Console.WriteLine("Invalid Input.");
                Console.Write($"Enter a number between {minValue} and {maxValue}: ");
            }
            Console.WriteLine("Congrats on passing the test.");
            Console.WriteLine();
            Console.Write(enter);
            Console.ReadLine();
            Console.Clear();
        }

        public static void ATM()
        {
            bool done = false; // false for while loop
            double transactionFee = 0.75, tax = 1.13, cashBalance = 75, balance = 150; // given numerical values
            double deposit, payBill, withdraw; // inputs
            int transMenu;

            Console.WriteLine("-------------PLANET BLORB ATM-------------");
            while (!done)
            {
                TypeText("Welcome to Bank of Blorb.");
                TypeText("1. Deposit");
                TypeText("2. Withdrawal");
                TypeText("3. Bill Payment");
                TypeText("4. Account Balance Update");
                TypeText("5. Quit");
                Console.WriteLine();
                Console.Write("Choose your transaction: ");
                while ((!Int32.TryParse(Console.ReadLine(), out transMenu)))
                {
                    balance = balance - transactionFee;
                    Console.WriteLine();
                    Console.WriteLine("Invalid Input.");
                    Console.WriteLine("You have been charged $0.75.");
                    Console.WriteLine($"Your balance is now {balance.ToString("C")}.");
                    Console.WriteLine();
                    Console.Write("Choose your transaction: ");
                }
                Console.WriteLine();
                Console.Write(enter);
                Console.ReadLine();
                Console.Clear();

                switch (transMenu)
                {
                    case 1: // deposit
                        balance = balance - transactionFee;
                        Console.WriteLine("-------------DEPOSIT-------------");
                        Console.WriteLine($"You only have {cashBalance.ToString("C")} to deposit.");
                        Console.Write("How much are you depositing into your bank? ");
                        while ((!Double.TryParse(Console.ReadLine(), out deposit)) || ((deposit > cashBalance) || (deposit < 0)))
                        {
                            Console.WriteLine("Invalid Input.");
                            Console.Write("How much are you depositing into your bank? ");
                        }

                        cashBalance = cashBalance - deposit;
                        balance = balance + deposit;

                        Console.WriteLine();
                        Console.WriteLine("Click 'Account Balance Update' for your new balance.");
                        Console.WriteLine();
                        Console.Write(enter);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2: // withdrawal
                        balance = balance - transactionFee;
                        Console.WriteLine("-------------WITHDRAWAL-------------");
                        Console.WriteLine("You must do an 'Account Balance Update' to check your balance.");
                        Console.Write("How much are you withdrawing from your bank? ");
                        while ((!Double.TryParse(Console.ReadLine(), out withdraw)) || ((withdraw > balance) || (withdraw < 0)))
                        {
                            Console.WriteLine("Invalid Input.");
                            Console.Write("How much are you withdrawing from your bank? ");
                        }

                        balance = balance - withdraw;
                        cashBalance = cashBalance + withdraw;

                        Console.WriteLine();
                        Console.Write(enter);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3: // bill payments
                        int outBill = generator.Next(0, 4);
                        balance = balance - transactionFee;
                        Console.WriteLine("-------------BILL PAYMENTS-------------");
                        switch (outBill)
                        {
                            case 0:
                                Console.WriteLine("You have no bills to pay.");
                                Console.WriteLine("Please check back later.");
                                break;
                            case 1:
                                Console.WriteLine("You have a mortgage to pay.");
                                Console.WriteLine("It's $30 + tax.");
                                break;
                            case 2:
                                Console.WriteLine("You have a hydro bill to pay.");
                                Console.WriteLine("Your roommate already paid for most of it.");
                                Console.WriteLine("It's $20 + tax.");
                                break;
                            case 3:
                                Console.WriteLine("You have a data plan bill to pay.");
                                Console.WriteLine("It's $40 + tax.");
                                break;
                        }
                        break;
                    case 4: // account balance
                        break;
                    case 5: // quit

                        done = true;
                        break;
                    default: // else

                        Console.WriteLine("Invalid Input.");
                        Console.WriteLine("You have been charged $0.75.");
                        Console.WriteLine($"Your balance is now {balance.ToString("C")}.");
                        Console.WriteLine();
                        Console.Write(enter);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }

        public static void Doubles()
        {

        }
    }
}
