using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    class Program
    {
        static void Main(string[] args)
        {
            char choice;
            ATP atp = new ATP();
            atp.AddUser();
            if(atp.GetPin())
            {
                do
                {
                    atp.DisplayMenu();
                    Console.Write("Wybierz opcję: ");
                    choice = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    switch(choice)
                    {
                        case '1':
                            atp.ShowData();
                            break;
                        case '2':
                            atp.CashIn();
                            break;
                        case '3':
                            atp.CashOut();
                            break;
                        case '4':
                            atp.ShowSaldo();
                            break;
                        case '5':
                            Console.Write("\nWYCIĄGNIJ KARTĘ\n");
                            break;
                        default:
                            Console.WriteLine("Nie ma takiej opcji!");
                            break;
                    }
                }
                while (choice != '5');

                Console.WriteLine("Dziękujemy za skorzystanie z naszego bankomatu. Życzymy miłego dnia!");
                Console.Read();
                
            }
        }
    }
}
