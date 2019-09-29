using System;
using System.Runtime.CompilerServices;

namespace BankEmulator.Models
{
    public abstract class UserAccount
    {
        public readonly int id;
        public readonly string userName;
        public double Credit;
        public double Debit; 
        public bool blocked = false;
        private int counter = 0;

        public UserAccount(string userName)
        {
            id = ++counter;
            this.userName = userName;
        }

        public UserAccount(double debit, string userName)
        {
            id = ++counter;
            this.userName = userName;
            Debit = debit;
        }

        // simple account can't have Credit> Debit
        public virtual void Put(double moneyToDebit)
        {
            this.Debit += moneyToDebit;
        }

        public virtual void Withdraw(double moneyToCredit)
        {
            this.Credit += moneyToCredit;
        }

        public virtual void BlockAccount(bool blocked)
        {
            this.blocked = blocked;
        }
    }
}