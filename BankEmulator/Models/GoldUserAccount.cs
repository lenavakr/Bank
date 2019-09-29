namespace BankEmulator.Models
{
    using System;

    public class GoldUserAccount : UserAccount
    {
        public GoldUserAccount(string userName) : base(userName)
        {
        }

        public GoldUserAccount(double debit, string userName) : base(debit, userName) { }

        public override void BlockAccount(bool blocked)
        {
            this.blocked = blocked;
            Console.WriteLine("GoldUserAccountCantBeBlocked");
        }
    }
}
