using classes;

namespace looping_assignment
{
    internal class Program
    {
        public static string enter = "Press [ENTER] to continue";
        public static int sleep;
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
                Thread.Sleep(sleep);
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

        public static double transactionFee = 0.75, tax = 1.13, cashBalance = 50, balance = 150, transCount = 0;
        public static double depositAmt = 0, withdrawAmt = 0, billsAmt = 0;

        public static void ATM()
        {
            bool done = false; // false for while loop
            double deposit, payBill, withdraw; // inputs
            int transMenu;
            balance = 150; cashBalance = 50;
            Console.WriteLine("-------------PLANET BLORB ATM-------------");
            while (!done)
            {
                if (balance < transactionFee)
                {
                    Console.WriteLine("You have ran out of money.");
                    Console.WriteLine("Your account will be closed.");
                    Console.WriteLine();
                    Console.WriteLine($"You are required to pay {transactionFee.ToString("C")} or more to open it again.");
                    Console.WriteLine();
                    Console.Write(enter);
                    Console.ReadLine();
                    Console.Clear();
                }
                sleep = 25;
                TypeText("Welcome to Bank of Blorb.");
                TypeText("1. Deposit");
                TypeText("2. Withdrawal");
                TypeText("3. Bill Payment");
                TypeText("4. Account Balance Update");
                TypeText("5. Quit");
                Console.WriteLine();
                Console.Write("Choose your transaction: ");
                while ((!Int32.TryParse(Console.ReadLine(), out transMenu)) || ((transMenu <= 0) || (transMenu > 5)))
                {
                    AccountBalance();
                }
                Console.WriteLine();
                Console.Write(enter);
                Console.ReadLine();
                Console.Clear();

                switch (transMenu)
                {
                    case 1: // deposit
                        Deposit();
                        break;
                    case 2: // withdrawal
                        Withdraw();
                        break;
                    case 3: // bill payments
                        Bills();
                        break;
                    case 4: // account balance
                        AccountBalance();
                        break;
                    case 5: // quit
                        done = true;
                        break;
                    default: // else
                        AccountBalance();
                        break;
                }
            }
        }

        public static void Deposit()
        {
            double deposit;
            transCount++;
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
            depositAmt += deposit;

            Console.WriteLine();
            Console.WriteLine("Click 'Account Balance Update' for your new balance.");
            Console.WriteLine();
            Console.Write(enter);
            Console.ReadLine();
            Console.Clear();
        }

        public static void Withdraw()
        {
            double withdraw;
            transCount++;
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
            withdrawAmt += withdraw;

            Console.WriteLine();
            Console.Write(enter);
            Console.ReadLine();
            Console.Clear();
        }

        public static void Bills()
        {
            double payBill = 0, total;
            int outBill = generator.Next(0, 6);
            string answer;
            transCount++;
            balance = balance - transactionFee;
            Console.WriteLine("-------------BILL PAYMENTS-------------");
            switch (outBill)
            {
                case 0:
                    payBill = 0;
                    Console.WriteLine("You have no bills to pay.");
                    Console.WriteLine("Please check back later.");
                    break;
                case 1:
                    payBill = 10;
                    if (balance < 10)
                    Console.WriteLine("You have a long distance call to pay.");
                    Console.WriteLine("You called someone from 100 lightyears away, which costs money.");
                    Console.WriteLine("It's $10 + tax.");
                    break;
                case 2:
                    payBill = 20;
                    Console.WriteLine("You have a hydro bill to pay.");
                    Console.WriteLine("Your roommate already paid for most of it.");
                    Console.WriteLine("It's $20 + tax.");
                    break;
                case 3:
                    payBill = 30;
                    Console.WriteLine("You have a mortgage to pay.");
                    Console.WriteLine("It's $30 + tax.");
                    break;
                case 4:
                    payBill = 40;
                    Console.WriteLine("You have a data plan bill to pay.");
                    Console.WriteLine("It's $40 + tax.");
                    break;
                case 5:
                    payBill = 50;
                    Console.WriteLine("You have a blorp blorp blorp bill to pay.");
                    Console.WriteLine("It's $50 + tax.");
                    break;
            }
            if (outBill == 0)
            {
                Console.WriteLine();
                Console.Write(enter);
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                total = payBill * tax;
                if ((balance < payBill) || (balance < total))
                {
                    Console.WriteLine();
                    Console.WriteLine("You are unable to pay this bill.");
                    Console.WriteLine("Please come back when you have more money.");
                    Console.WriteLine();
                    Console.Write(enter);
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    billsAmt += total;
                    Console.WriteLine();
                    Thread.Sleep(500);
                    Console.WriteLine("Please wait as your bill is paid for.");
                    sleep = 1000;
                    Console.Write("Calculatin");
                    TypeText("g...");
                    Console.WriteLine();
                    Console.WriteLine($"BILL: {payBill.ToString("C")}");
                    Console.WriteLine($"TAX: {tax.ToString("C")}");
                    Console.WriteLine($"TOTAL: {total.ToString("C")}.");
                    Console.WriteLine();
                    balance = balance - total;

                    Thread.Sleep(500);
                    Console.WriteLine("YOUR BILL HAS BEEN PAID FOR.");
                    Console.WriteLine("Check 'Account Balance Update' for your new balance.");
                    Console.Write(enter);
                    Console.ReadLine();
                    Console.Clear();
                }
                    
            }
            

        }

        public static void AccountBalance()
        {
            transCount++;
            balance = balance - transactionFee;
            Console.WriteLine("--------ACCOUNT BALANCE UPDATE--------");
            Console.WriteLine($"Your current balance is {balance.ToString("C")}.");
            Console.WriteLine($"You've been charged a total of {(transCount * transactionFee).ToString("C")} in transactions.");
            Console.WriteLine($"You deposited a total of {depositAmt.ToString("C")}.");
            Console.WriteLine($"You withdrew a total of {withdrawAmt.ToString("C")}.");
            Console.WriteLine($"You paid bills worth a total of {billsAmt.ToString("C")}. [includes tax]");
            Console.WriteLine();
            Thread.Sleep(100);
            Console.Write(enter);
            Console.ReadLine();
            Console.Clear();
        }

        public static void Doubles()
        {
            bool done, input = false;
            int diceInput, rollUntil, rollAmt = 0;
            Die dice1 = new Die(ConsoleColor.Red);
            Die dice2 = new Die(ConsoleColor.Blue);

            Console.WriteLine("------------DOUBLES-------------");
            Console.WriteLine("Let's start with the settings first.");
            Console.WriteLine("Should dice roll freely or require input?");
            Console.WriteLine("1. Dice roll freely");
            Console.WriteLine("2. Require Input");
            Console.Write("Choose: ");
            while ((!Int32.TryParse(Console.ReadLine(), out diceInput)) || ((diceInput < 1) || (diceInput > 2)))
            {
                Console.WriteLine("Invalid Input.");
                Console.Write("Choose: ");
            }
            switch (diceInput)
            {
                case 1:
                    input = false;
                    break;
                case 2:
                    input = true;
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("What should we roll until?");
            Console.WriteLine("1. Doubles");
            Console.WriteLine("2. Snake Eyes");
            Console.WriteLine("3. Sequential Dice");
            Console.WriteLine("4. Sum of 7");
            Console.Write("Roll until? ");
            while ((!Int32.TryParse(Console.ReadLine(), out rollUntil)) || ((rollUntil < 1) || (rollUntil > 4)))
            {
                Console.WriteLine("Invalid Input.");
                Console.Write("Roll until? ");
            }
            Console.WriteLine();
            Console.Write(enter);
            Console.ReadLine();
            Console.Clear();
            done = false;
            while (!done)
            {
                rollAmt += 1;
                Console.WriteLine($"ROLL {rollAmt}");
                Console.WriteLine();
                Console.WriteLine("Dice 1");
                dice1.RollDie();
                dice1.DrawRoll();
                Console.WriteLine();
                Console.WriteLine("Dice 2");
                dice2.RollDie();
                dice2.DrawRoll();
                Console.WriteLine("--------------------------");

                if ((dice1.Roll == dice2.Roll) && (rollUntil == 1))
                {
                    done = true;
                    Console.WriteLine($"It took {rollAmt} tries to get doubles.");
                }
                else if (((dice1.Roll == 1) && (dice2.Roll == 1)) && (rollUntil == 2))
                {
                    done = true;
                    Console.WriteLine($"It took {rollAmt} tries to get snake eyes.");
                }
                else if ((dice2.Roll == (dice1.Roll + 1)) && (rollUntil == 3))
                {
                    done = true;
                    Console.WriteLine($"It took {rollAmt} tries to get sequential dice.");
                }
                else if (dice1.Roll + dice2.Roll == 7 && rollUntil == 4)
                {
                    done = true;
                    Console.WriteLine($"It took {rollAmt} tries to get a sum of 7.");
                }

                if (input)
                {
                    Console.WriteLine();
                    Console.Write(enter);
                    Console.ReadLine();
                    Console.WriteLine();
                }
                else
                {
                    //Thread.Sleep(1000);
                    Console.WriteLine();
                }
            }

            Thread.Sleep(1000);
            Console.WriteLine();
            Console.Write(enter);
            Console.ReadLine();
            Console.Clear();
        }
    }
}
