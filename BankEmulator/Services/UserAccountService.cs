using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BankEmulator.DbContexts;
using BankEmulator.Models;

namespace BankEmulator.Services
{
    public class UserAccountService
    {
        private UserAccount userAccount;

        public UserAccountService(UserAccount userAccount)
        {
            this.userAccount = userAccount;
        }

        public void PutMoney(double money)
        {
            if (money < 0)
            {
                Console.WriteLine("Сумма начисления должна быть положительной.");
            }
            else
            {
                this.userAccount.Put(money);
                if (this.userAccount.Credit < this.userAccount.Debit && this.userAccount.blocked)
                {
                    // unblock account in this case
                    this.userAccount.BlockAccount(false);
                }
            }
        }

        public void WithdrawMoney(double money)
        {
            if (money < 0)
            {
                Console.WriteLine("Вы не можете снять со счета отрицательную сумму.");
                return;
            }

            if (!userAccount.blocked)
            {
                this.userAccount.Withdraw(money);
            }

            if(this.userAccount.Credit > this.userAccount.Debit && !this.userAccount.blocked)
            {
                this.userAccount.BlockAccount(true);
            }
        }
    }
}
