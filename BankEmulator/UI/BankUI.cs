using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankEmulator.Models;

namespace BankEmulator.UI
{
    using BankEmulator.Services;

    public class BankUI
    {
        public void RunTerminal()
        {
            DbContexts.BankAccountsRepository bankAccountsRepository = new DbContexts.BankAccountsRepository();
            LoggedService loggedService = new LoggedService(ref bankAccountsRepository);
            UserAccount userAccount = loggedService.Autorization();

            if (userAccount == null)
            {
                throw new Exception("Wrong user credentials!");
            }

            UserAccountService userAccountService = new UserAccountService(userAccount);

            string input = "";
            while (input != "0")
            {
                Console.WriteLine("Choose command to proceed:");
                Console.WriteLine("1. See account debit.");
                Console.WriteLine("2. See account credit.");
                Console.WriteLine("3. Put money.");
                Console.WriteLine("4. Withdraw money.");
                Console.WriteLine("0. Exit");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("debit: " + userAccount.Debit.ToString());
                        continue;
                    case "2":
                        Console.WriteLine("credit: " + userAccount.Credit.ToString());
                        continue;
                    case "3":
                        Console.WriteLine("Set ammount to put:");
                        string moneyToPutInput = Console.ReadLine();
                        if (double.TryParse(moneyToPutInput, out double moneyToPut))
                        {
                            userAccountService.PutMoney(moneyToPut);
                        }
                        else
                        {
                            Console.WriteLine("Wrong format.");
                        }

                        continue;
                    case "4":
                        Console.WriteLine("Set ammount to withdraw:");
                        string moneyToWithdrawInput = Console.ReadLine();
                        if (double.TryParse(moneyToWithdrawInput, out double moneyToWithdraw))
                        {
                            userAccountService.WithdrawMoney(moneyToWithdraw);
                        }
                        else
                        {
                            Console.WriteLine("Wrong format.");
                        }

                        continue;
                    case "0":
                        continue;
                    default:
                        Console.WriteLine("Unknown command. Repeate please.");
                        continue;
                }
            }

            Console.WriteLine("Good bye!");
        }
    }
}
