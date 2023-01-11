using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMBankingSystem
{
    public class cardHolder
    {
        String firstName;
        String lastName;
        String cardNumber;
        double balance;
        int pin;

        public cardHolder(string firstName, string lastName, int pin, string cardNumber, double balance)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.pin = pin;
            this.cardNumber = cardNumber;
            this.balance = balance;
        }

        public String getFirstName()
        {
            return firstName;
        }

        public String getLastName()
        {
            return lastName;
        }

        public String getNum()
        {
            return cardNumber;
        }

        public int getPin()
        {
            return pin;
        }

        public double getBalance()
        { 
            return balance; 
        }

        public void setFirstName(String newFirstName)
        {
            firstName = newFirstName;
        }

        public void setLastName(String newLastName)
        {
            lastName = newLastName;
        }
        public void setBalance(double newBalance)
        {
            balance = newBalance;
        }


        // MAIN OPERATION FOR PROGRAM TO RUN
        public static void Main(string[] args)
        { 
            void printOptions()
            {
                Console.WriteLine("Please select an option below");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdrawal");
                Console.WriteLine("3. View Balance");
                Console.WriteLine("4. Exit");
                Console.WriteLine("-------------------------------");
            }

            void deposit(cardHolder currentUser)
            {
                Console.WriteLine(" ");
                Console.WriteLine("How much would you like to deposit? ");
                double depositCash = Double.Parse(Console.ReadLine());
                currentUser.setBalance(currentUser.getBalance() + depositCash);
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Thank you, deposit succesful. Your new balance is: R" + currentUser.getBalance());
                Console.WriteLine(" ");
            }

            void withdrawal(cardHolder currentUser)
            {
                Console.WriteLine("How much would you like to withdraw? ");
                Console.WriteLine("--------------------------------------");
                double withdrawCash = Double.Parse(Console.ReadLine());

                if(currentUser.getBalance() < withdrawCash)
                {
                    Console.WriteLine("Sorry, you have insufficient funds for this transcation");
                    Console.WriteLine(" ");
                }

                else
                {           
                    currentUser.setBalance(currentUser.getBalance() - withdrawCash);
                    Console.WriteLine("Thank you, transcation succesful. Your new balance is :R" + currentUser.getBalance());
                    Console.WriteLine(" ");
                }      
            }

            void balance(cardHolder currentUser)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Current Balance: R " + currentUser.getBalance());
                Console.WriteLine("----------------------------");
            }

            // DATABASE FOR BANKING DETAILS
            List<cardHolder> cardHolders = new List<cardHolder>();
            cardHolders.Add(new cardHolder("Marcus", "Mahlatjie", 3432, "3943848348543", 54034.12 ));
            cardHolders.Add(new cardHolder("Phillip", "Mahlatjie", 4858, "857575767647", 49674.11));
            cardHolders.Add(new cardHolder("Charles", "Mahlatjie", 9767, "969869866774", 203454.00));
            cardHolders.Add(new cardHolder("Jackie", "Mahlatjie", 3455, "767767688709", 59548));
            cardHolders.Add(new cardHolder("Richard", "Mahlatjie", 8976, "8968786877858", 349495));
            cardHolders.Add(new cardHolder("Testing", "Developer", 1234, "123456789", 50000.00));

            Console.WriteLine("Welcome to Bank of Marcus");
            Console.WriteLine(" ");
            Console.WriteLine("Please enter your debit card number");
            Console.WriteLine("-----------------------------------");
            String debitCardNumber = " ";
            cardHolder currentUsers;

            // USER LOGIN DETAIL VALIDATION
            while (true)
            {
                try
                {
                    debitCardNumber = Console.ReadLine();

                    currentUsers = cardHolders.FirstOrDefault(a => a.cardNumber == debitCardNumber);
                    if (currentUsers != null)
                    { break; }

                    else
                    {
                        Console.WriteLine("Card not recognized. Please try again");
                        Console.WriteLine(" ");
                    }
                }

                catch
                {
                    Console.WriteLine("Card not recognized. Please try again");
                    Console.WriteLine(" ");
                }
            }

            // UPON SUCCESFUL CARDNUMBER, PIN VALIDATION
            Console.WriteLine("Please enter your pin");
            Console.WriteLine(" ");
            int userPin = 0;


            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());

                    if (currentUsers.getPin() == userPin)
                    {
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Incorect pin, please try again");
                        Console.WriteLine(" ");
                    }
                }

                catch
                {
                    Console.WriteLine("Incorect pin, please try again");
                    Console.WriteLine(" ");
                }      
        }

            // SUCCESFUL LOGIN AND DISPLAY MENU
            Console.WriteLine(" ");
            Console.WriteLine("Welcome back," + currentUsers.getFirstName());
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }

                catch
                {}

                if (option == 1)
                {
                    deposit(currentUsers);
                }

                else if (option == 2)
                {
                    withdrawal(currentUsers);
                }

                else if (option == 3)
                {
                    balance(currentUsers);
                }

                else if (option == 4)
                {
                    break;
                }
            }

            while (option != 4);
            Console.WriteLine("Thank you have a nice day");
            Console.WriteLine(" ");
        }
    }
}
