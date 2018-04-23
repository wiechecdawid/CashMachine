using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    class ATP
    {
        private int currentIndex;
        public User[] UserArr = new User[3];
        public void AddUser()
        {
            UserArr[0] = new User("Dawid", "Wiecheć", 4306, 3500);
            UserArr[1] = new User("Jakub", "Pawluś", 1234, 8500);
            UserArr[2] = new User("Asia", "Sermak", 4321, 7500); 
        }

        public bool GetPin()
        {
            int counter = 1;
            do
            {
                if (CheckUser())
                    return true;
                else
                    Console.WriteLine("Kod niepoprawny!");
                counter++;
            }
            while (counter <= 3);
            Console.WriteLine("Trzykrotne błędne wpisanie PIN. Karta zablokowana \nNaciśnij ENTER, aby wyjść.");
            Console.ReadLine();
            return false;
        }
        public bool CheckUser()
        {
            Console.WriteLine("Podaj kod PIN: ");
            int Pin = int.Parse(Console.ReadLine());
            for (int i = 0; i < UserArr.Length; i++)
            {
                if (Pin == UserArr[i].Password)
                {
                    UserArr[i].SayHello();
                    currentIndex = i;
                    return true;
                }
            }
            return false;
        }

        public void DisplayMenu()
        {
            Console.WriteLine("----MENU----");
            Console.WriteLine("1. Dane");
            Console.WriteLine("2. Wpłata");
            Console.WriteLine("3. Wypłata");
            Console.WriteLine("4. Stan konta");
            Console.WriteLine("5. Wyjście");
        }

        public void ShowData()
        {
            UserArr[currentIndex].PersonalData();
            Console.WriteLine();
        }
        public void CashIn()
        {
            Console.WriteLine("Podaj sumę, którą chcesz wpłacić: ");
            int wplata = int.Parse(Console.ReadLine());
            UserArr[currentIndex].Saldo += wplata;
            Console.WriteLine($"Wpłaciłeś {wplata} zł.");
            ShowSaldo();
        }
        public void CashOut()
        {
            int payout = 0;
            if (UserArr[currentIndex].Saldo > 20)
            {
                Console.WriteLine("Podaj sumę, którą chcesz wypłacić: ");
                do
                {

                    try
                    {
                        payout = int.Parse(Console.ReadLine());
                        if (payout % 20 != 0 && payout % 50 != 0 && payout % 100 != 0)
                        {
                            Console.WriteLine("Bankomat wydaje jedynie sumę, będącą wielokrotnością 20, 50 lub 100 zł. Spróbuj jeszcze raz: ");
                        }
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("Nie wprowadziłeś sumy. Spróbuj jeszcze raz!");
                    }

                }
                while (payout % 20 != 0 && payout % 50 != 0 && payout % 100 != 0);
                if (payout<=UserArr[currentIndex].Saldo)
                {
                    UserArr[currentIndex].Saldo -= payout;
                    Console.WriteLine($"Pobrano {payout} zł");
                }

            }
            else
                Console.WriteLine("Nie masz wystarczających środków na koncie, by wypłacić pieniądze.");
            ShowSaldo();
        }
        
        public void ShowSaldo()
        {
            Console.WriteLine($"Twoje saldo wynosi: {UserArr[currentIndex].Saldo} zł");
        }
        
        
    }
}
