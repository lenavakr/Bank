using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankEmulator.Models;
using BankEmulator.DbContexts;

namespace BankEmulator.Services
{
    public class LoggedService
    {
        BankAccountsRepository _bankAccountsRepository;

        private string Login { get; set; }

        public LoggedService() { }

        public LoggedService(ref BankAccountsRepository bankAccountsRepository)
        {
            _bankAccountsRepository = bankAccountsRepository;
        }

        public UserAccount Autorization()
        {
            Console.WriteLine("Enter login: ");
            Login = Console.ReadLine();

            return _bankAccountsRepository.GetAccount(Login);
        }
    }
}