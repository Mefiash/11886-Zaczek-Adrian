using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraMonolitycznie
{
    class Program
    {
        

        static int Losowanie(int max = 100, int min =1)
        {
            if (min > max)
            {
                min = 1;
                max = 100;
            }
            Console.WriteLine($"Losuję liczbę od {min} do {max} \n odgadnij ją");
            return (new Random()).Next(min, max + 1);
        }
        
        static void Main(string[] args)
        {

                var counter = 0;
                for (int i = 0; i < 30; i++)
                {
                    Console.Clear();

                    switch (counter % 4)
                    {
                        case 0:
                            {
                                Console.WriteLine("╔════╤╤╤╤════╗");
                                Console.WriteLine("║    │││ \\   ║");
                                Console.WriteLine("║    │││  O  ║");
                                Console.WriteLine("║    OOO     ║");
                                break;
                            };
                        case 1:
                            {
                                Console.WriteLine("╔════╤╤╤╤════╗");
                                Console.WriteLine("║    ││││    ║");
                                Console.WriteLine("║    ││││    ║");
                                Console.WriteLine("║    OOOO    ║");
                                break;
                            };
                        case 2:
                            {
                                Console.WriteLine("╔════╤╤╤╤════╗");
                                Console.WriteLine("║   / │││    ║");
                                Console.WriteLine("║  O  │││    ║");
                                Console.WriteLine("║     OOO    ║");
                                break;
                            };
                        case 3:
                            {
                                Console.WriteLine("╔════╤╤╤╤════╗");
                                Console.WriteLine("║    ││││    ║");
                                Console.WriteLine("║    ││││    ║");
                                Console.WriteLine("║    OOOO    ║");
                                break;
                            };
                    }

                    counter++;
                    Thread.Sleep(200);
                }
            

            DateTime thisDay = DateTime.Today;
            Console.WriteLine("Witaj!");
            Console.Write("Podaj swoje imię: ");
            string nick = Console.ReadLine();
            Console.WriteLine($"Witaj, {nick}");

                // 1. Komputer losuje liczbę
          Random generator = new Random();
            int wylosowana = generator.Next(1, 101);
            Console.WriteLine("Wylosowałem liczbę od 1 do 100. \n Odgadnij ją");



#if (DEBUG)
        //Console.WriteLine(wylosowana);
#endif
        Stopwatch stoper = Stopwatch.StartNew();
            int licznik = 0;
            //wykonuj
            bool trafiono = false; //wartownik (zwany czasami flagą)
            do
            {
                #region Krok 2. Człowiek proponuje rozwiązanie
                Console.Write("Podaj swoją propozycję: ");
                string tekst = Console.ReadLine();
                if (tekst.ToLower() == "x")
                    break;

                int propozycja = 0;
                try
                {
                    propozycja = Convert.ToInt32(tekst);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Nie podano liczby!");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Liczba nie mieści się w rejestrze!");
                    continue;
                }

                Console.WriteLine($"Przyjąłem wartość {propozycja}");
                #endregion


                #region Krok 3. Komputer ocenia propozycję
                if (propozycja < wylosowana)
                    Console.WriteLine("za mało");
                else if (propozycja > wylosowana)
                    Console.WriteLine("za dużo");
                else
                {
                    Console.WriteLine("trafiono");
                    trafiono = true;

                    
                }
                licznik++;
                #endregion
            }
            while( !trafiono );
            
            stoper.Stop();
            //do momentu trafienia

            Console.WriteLine("Koniec gry! Gratulacje");
            Console.WriteLine($"Czas gry = {stoper.Elapsed}");
            Console.WriteLine($"wykonano {licznik} ruchów");

            FileStream fs = new FileStream("C:\\Wyniki.txt",
               FileMode.Append, FileAccess.Write);

            try
            {
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(thisDay.ToString("d"));
                sw.WriteLine($"Nick: {nick} - Czas gry = {stoper.Elapsed}, Ilośc ruchów = {licznik},  ");
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }





            System.Console.ReadKey();

        }

    }
}
