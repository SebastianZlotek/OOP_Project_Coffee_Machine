using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt___maszyna_do_kawy //wspolna przestrzen nazw 
{
    class Program // utworzenie klasy glownej
    {
        public static Klient klient = new(); // utworzenie obiektow
        public static bool start = true;

        static void Main(string[] args)
        {
            Console.WriteLine("Podaj kwote wplaty"); // wplacanie okreslonej ilosci pieniedzy
            Klient.kwota = Convert.ToInt32(Console.ReadLine()); // konwersja wpisanego string (kwoty) na int

            Console.WriteLine("Nacisnij 'N' aby wybrac napoje oraz 'P' aby wybrac przekaski. 'K' aby przejsc do koszyka. Nacisnij inny przycisk aby wyjsc: "); // menu glowne, wybranie pozycji z automatu
            char pozycja = Console.ReadKey().KeyChar; // wczytanie przycisku z klawiatury
            Console.WriteLine();

            while (pozycja != 'q') // warunki
            {

                switch (pozycja) //wybrany przycisk automatu
                {
                    case 'n':
                        Console.WriteLine("\nWybierz produkt z listy. Nacisnij inny przycisk aby wrocic do strony glownej.");
                        foreach (Napoj napoje in Napoj.ListaNapoi) // wyswietlaj liste napoi z id (wybrany przycisk), nazwa i cena
                        {
                            Console.WriteLine($"{napoje.ID}: {napoje.Nazwa} ({napoje.Cena:c})");
                        }
                        char wybranaPozycja = Console.ReadKey().KeyChar; // wczytaj napoj z klawiatury

                        switch (wybranaPozycja) // wybranie napoju
                        {
                            case '1':
                                klient.zakupy.Add(Napoj.CocaCola); // dodaj napoj do koszyka
                                klient.Pieniadze -= Napoj.CocaCola.Cena; // odejmij wartosc napoju od wplaconej kwoty
                                Console.WriteLine($"\nWybrales: {Napoj.CocaCola.Nazwa}"); // wypisz wybrany produkt
                                break;
                            case '2':
                                klient.zakupy.Add(Napoj.PepsiMax); // dodaj napoj do koszyka
                                klient.Pieniadze -= Napoj.PepsiMax.Cena; // odejmij wartosc napoju od wplaconej kwoty
                                Console.WriteLine($"\nWybrales: {Napoj.PepsiMax.Nazwa}"); // wypisz wybrany produkt
                                break;
                            case '3':
                                klient.zakupy.Add(Napoj.Fanta); // dodaj napoj do koszyka
                                klient.Pieniadze -= Napoj.Fanta.Cena; // odejmij wartosc napoju od wplaconej kwoty
                                Console.WriteLine($"\nWybrales: {Napoj.Fanta.Nazwa}"); // wypisz wybrany produkt
                                break;
                            case '4':
                                klient.zakupy.Add(Napoj.Sprite); // dodaj napoj do koszyka
                                klient.Pieniadze -= Napoj.Sprite.Cena; // odejmij wartosc napoju od wplaconej kwoty
                                Console.WriteLine($"\nWybrales: {Napoj.Sprite.Nazwa}"); // wypisz wybrany produkt
                                break;
                        }
                        break;


                    case 'p':
                        Console.WriteLine("\nWybierz produkt z listy. Nacisnij inny przycisk aby wrocic do strony glownej."); // wybranie przekaski
                        foreach (Przekaska przekaski in Przekaska.ListaPrzekasek) // wyswietlaj liste przekasek z id (wybrany przycisk), nazwa i cena
                        {
                            Console.WriteLine($"{przekaski.ID}: {przekaski.Nazwa} ({przekaski.Cena:c})");
                        }
                        wybranaPozycja = Console.ReadKey().KeyChar; // wczytaj napoj z klawiatury

                        switch (wybranaPozycja) // wybranie napoju
                        {
                            case '1':
                                klient.zakupy.Add(Przekaska.Batonik); // dodaj przekaske do koszyka
                                klient.Pieniadze -= Przekaska.Batonik.Cena; // odejmij wartosc przekaski od wplaconej kwoty
                                Console.WriteLine($"\nWybrales: {Przekaska.Batonik.Nazwa} w cenie {Przekaska.Batonik.Cena:c}."); // wypisz wybrany produkt
                                break;
                            case '2':
                                klient.zakupy.Add(Przekaska.Chrupki); // dodaj przekaske do koszyka
                                klient.Pieniadze -= Przekaska.Chrupki.Cena; // odejmij wartosc przekaski od wplaconej kwoty
                                Console.WriteLine($"\nWybrales: {Przekaska.Chrupki.Nazwa} w cenie {Przekaska.Chrupki.Cena:c}."); // wypisz wybrany produkt
                                break;
                        }
                        break;
            
                    case 'k':
                        Console.WriteLine($"\nDostepne srodki: {klient.Pieniadze:c}."); // koszyk i podsumowanie
                        if (klient.Pieniadze < 0) //zabezpieczenie przed saldem ujemnym
                        {
                            Console.WriteLine($"Nie masz wystarczających funduszy, prosze wpłacić kwotę {klient.Pieniadze:c}!");
                            Console.WriteLine("Podaj kwote doplaty"); // wplacanie okreslonej ilosci pieniedzy
                            Klient.kwota = Convert.ToInt32(Console.ReadLine()); // konwersja wpisanego string (kwoty) na int
                            if (Klient.kwota < 0) // zabezpieczenie przed wplacaniem ujemnej sumy
                            {
                                Console.WriteLine("Podana kwota jest nadal zbyt mała!");
                            }
                            else
                            {
                                klient.Pieniadze += Klient.kwota; // dodanie doplaconej kwoty do salda
                            }
                          
                        }
                        else
                        {
                            Console.WriteLine($"Wybrane pozycje:");
                            foreach (Automat koszyk in klient.zakupy) // wyswietl wybrane produkty
                            {
                                Console.WriteLine(koszyk.Nazwa); // wyswietl nazwe produktow
                            }
                        }
                        break;

                    default:
                        return;
                }
                Console.WriteLine("\n\nNacisnij 'N' aby wybrac napoje oraz 'P' aby wybrac przekaski. 'K' aby przejsc do koszyka. Nacisnij inny przycisk aby wyjsc: ");
                pozycja = Console.ReadKey().KeyChar; // strona poczatkowa jak w kazdym automacie wyswietla sie po zakupach
            }
        }
    }
}
