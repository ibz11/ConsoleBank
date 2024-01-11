using System;
using System.Collections.Generic;


class BankApp
{

    private Dictionary<string, string> userCredentials = new Dictionary<string, string>();
    private Dictionary<string, int> Account = new Dictionary<string, int>();

    public void Register(string username, string password,int amount) 
    {
       
        userCredentials[username] = password;
        Account[username] = amount;
        Console.WriteLine($"User '{username}' registered successfully.");


    }

    public bool Login(string username, string password)
    {
        if(userCredentials.ContainsKey(username) && userCredentials[username]==password) {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Deposit(string username, int amount)
    {
      /* int oldAmt= Account[username];
       int newAmt=oldAmt + amount;
       Account[username] = newAmt;

        Console.WriteLine($"This is the current balance in your account $ {Account[username]}");*/

        if (Account.ContainsKey(username))
        {
            int oldAmt = Account[username];
            int newAmt = oldAmt + amount;
            Account[username] = newAmt;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"This is the current balance in your account $ {Account[username]}");
        }
        else
        {
            Console.WriteLine($"Username '{username}' not found.");
        }

    }

    

    public void CheckBalance(string username)
    {
        var balance = Account[username];
        Console.WriteLine($"Your balance is $ {balance}");
    }
    public void WithdrawCash(string username,int withdrawal)
    {
        if (Account.ContainsKey(username))
        {
            if (Account[username] > 0 && Account[username] < withdrawal)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error.Insufficient funds to undergo action.Current balance in your account:${Account[username]}");
            }
            else
            {
                int currentBalance = Account[username];
                int newAmt = currentBalance - withdrawal;
                Account[username] = newAmt;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Withdrawal successful!! Amount withdrawn: ${withdrawal}");
                Console.WriteLine($"This is the current balance in your account ${Account[username]}");
            }
        }
        else
        {
            Console.WriteLine($"Username '{username}' not found.");
        }

    }

}

class Program
{
    static void Main()
    {
        BankApp app = new BankApp();
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Ibz Limited bank ");
            Console.WriteLine("----------------\n\n");

            Console.WriteLine("Choose a service: \n");
            Console.WriteLine("1.Create account");
            Console.WriteLine("2.Login to your account\n");
           


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Type your choice:");
            var choice=Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.Green; 
                    Console.WriteLine("Add your username and password");
                    Console.WriteLine("Username:");
                    var username=Console.ReadLine();
                    Console.WriteLine("Password:");
                    var password=Console.ReadLine();
                    Console.WriteLine("Deposit amount to activate account:");
                    var amount = Console.ReadLine();
                    int.TryParse(amount, out int result);

                    app.Register(username, password,result);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Password is created...");
                    break;



                case "2":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Please Login to your Account");
                    Console.WriteLine("Username:");
                    var uname = Console.ReadLine();
                    Console.WriteLine("Password:");
                    var pass = Console.ReadLine();
                    bool isAuthenticated = app.Login(uname, pass);
                    if (isAuthenticated)
                    {

                      while (true) { 
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("--------------------");
                        Console.WriteLine($"Welcome back {uname}");
                        Console.WriteLine("--------------------");
                        Console.WriteLine("1.Deposit to your account");
                        Console.WriteLine("2.Check balance");
                        Console.WriteLine("3.Withdraw Amount\n");
                        /*Console.WriteLine("3.Logout\n");*/

                            Console.WriteLine("Choose a service:");
                        var service = Console.ReadLine();

                        switch (service)
                        {
                            case "1":
                                    Console.WriteLine("Add amount to your account");
                               
                                    
                                    var depAmt = Console.ReadLine();
                                    int.TryParse(depAmt, out int depositAmt);
                                    /*int depositAmt=int.Parse(depAmt);*/
                                    app.Deposit(uname, depositAmt);
                                  /*  Console.WriteLine($"This is the Amount added in your account:${depositAmt}");*/
                                    break;
                            case "2":
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    app.CheckBalance(uname);
                                break;
                            case "3":
                                Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("Type the amount to be withdrawn:");
                                    dynamic withdrawal=Console.ReadLine();
                                    int.TryParse(withdrawal,out int withdrawalAmt);
                                    app.WithdrawCash(uname, withdrawalAmt);

                                   /* Console.WriteLine("So sad to see you go");*/

                                break;

                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong Input !! please try again");
                                Console.WriteLine("\n");
                                break;
                        }
                    }














                        
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error.Wrong password or account username.");
                    }
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong Input !! please try again");
                    Console.WriteLine("\n");
                    break;

            }
           

            
            


            
        }

    }
}