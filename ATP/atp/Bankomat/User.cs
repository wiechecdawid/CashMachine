using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    class User
    {
        private string FirstName;
        private string LastName;
        internal int Password { get; }
        internal int Saldo;

        public User(string firstName, string lastName, int password, int saldo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Saldo = saldo;
        }

        public void PersonalData()
        {
            Console.WriteLine($"Imię: {this.FirstName}  |  Nazwisko: {this.LastName}");
            Console.WriteLine();
        }

        public void SayHello()
        {
            Console.WriteLine($"Witaj, {this.FirstName} {this.LastName}");
        }

        
    }
}
