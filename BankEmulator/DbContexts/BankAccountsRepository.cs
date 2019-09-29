using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankEmulator.Models;

namespace BankEmulator.DbContexts
{
    public class BankAccountsRepository
    {
        private List<UserAccount> usersAccountsSource = new List<UserAccount>();

        public BankAccountsRepository()
        {
            usersAccountsSource.Add(new GoldUserAccount("admin"));
            usersAccountsSource.Add(new GoldUserAccount(20, "user"));
        }
        
        public UserAccount GetAccount()
        {
            return usersAccountsSource.First();//?
        }

        public UserAccount GetAccount(string login)
        {
            foreach (var user in usersAccountsSource)
            {
                if (user.userName == login)
                {
                    return user;
                }
            }

            return null;
        }

        public void OpenUserAccount(UserAccount userAccount)
        {
            this.usersAccountsSource.Add(userAccount);
        }
    }
}
