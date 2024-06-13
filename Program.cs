using atmOOP;

class Program
{
    class ATM
    {
        public ATM(double balance, string pin)
        {
            this.balance = balance;
            this.pin = pin;
        }

        public double balance { get; set; }
        public string pin { get; set; }
        public bool Withdraw(double amount)
        {
            try
            {
                if (balance < amount)
                {
                    throw new NotEnoughAmountException("Not enough balance to withdraw that much money");
                }else
                {
                    balance -= amount;
                    return true;
                }
            }catch (NotEnoughAmountException ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void Deposit(double amount)
        {
            balance += amount;
        }

        public bool ChangePin(string NewPin)
        {
            try
            {
                if(pin==NewPin) 
                {
                    throw new SamePinException("the new and old pins are same");
                }else
                {
                    pin = NewPin;
                    return true;
                }

            }catch(SamePinException ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public string ShowBalance()
        {
            return $"Balance: {balance} $";
        }

    }

    static void Main(string[] args)
    {
        ATM atm = new ATM(3000,"1234");
        
        string enteredPin;
        int option;
        int pinTry = 0;
        float withdrawAmount, depositAmount;
        bool exit = false;
        while (pinTry < 3 & exit != true)
        {
            Console.WriteLine("Enter the pin:");
            enteredPin = Console.ReadLine();
            if (enteredPin != atm.pin)
            {
                pinTry++;
                Console.WriteLine($"Wrong pin: tries {pinTry}/3");
                continue;
            }
            else
            {
                while (exit != true)
                {
                    Console.WriteLine(
@"1.Show balance
2. Withdraw money
3.Deposit money
4.Change pin
");
                    option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine(atm.ShowBalance());
                           

                            break;
                        case 2:
                            Console.WriteLine("How much would you like to withdraw?");
                            withdrawAmount = Convert.ToSingle(Console.ReadLine());
                            atm.Withdraw(withdrawAmount);
                            Console.WriteLine($"{atm.balance}$");

                            break;
                            
                            

                        case 3:
                            Console.WriteLine("How much would you like to deposit?");
                            depositAmount = Convert.ToSingle(Console.ReadLine());
                            atm.Deposit(depositAmount);
                            Console.WriteLine($"{atm.balance}$");
                            break;
                        case 4:
                            Console.WriteLine("What is going to be your new pin");
                            atm.ChangePin(Console.ReadLine());
                            if (atm.ChangePin(Console.ReadLine()))
                            {
                                Console.WriteLine("Pin Updated Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Pin Updated Unsuccessfully");
                            }
                           
                            break;
                        case 5:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Wrong option!");
                            break;
                    }
                }

            }
        }

    }
}