using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt___maszyna_do_kawy //wspolna przestrzen nazw 
{
    class Klient // utworzenie klasy klient
    {
        public static int kwota; // utworzenie elementu statycznego do przetrzymywania kwoty
        private decimal pieniadze = (decimal)kwota; // utworzenie elementu do przetrzymywania kwoty jako liczba dziesiatkowa
        public decimal Pieniadze {  // utworzenie elementu zwracajacego dane z kwoty i przypisujace mu wartosc dziesietna (pieniadze)
            get { return pieniadze; } 
            set { pieniadze = value; } 
        }

        public List<Automat> zakupy = new(); // utworzenie listy do wyswietlania zrobionych zakupow

    }

    abstract class Automat // utworzenie klasy abstrakcyjnej automat, co umozliwa dziedziczenie w prosty sposob
    {
        public string Nazwa { get; set; } // utworzenie elementow zwracajacych wartosci nazwy ceny i id
        public decimal Cena { get; set; }
        public int ID { get; set; }
    }

    class Napoj : Automat // utworzenie podklasy Napoj z Automat
    {
        public static Napoj CocaCola = new() { Nazwa = "Coca-Cola", Cena = 6M, ID = 1 }; // utworzenie czterech obiektow (napoi) w nich: nazwa, cena oraz id
        public static Napoj PepsiMax = new() { Nazwa = "Pepsi Max", Cena = 5M, ID = 2 };
        public static Napoj Fanta = new() { Nazwa = "Fanta", Cena = 7M, ID = 3 };
        public static Napoj Sprite = new() { Nazwa = "Sprite", Cena = 5M, ID = 4 };

        public static List<Napoj> ListaNapoi = new() // utworzenie listy do wyswietlania wczesniej utworzonych obiektow
        {
            CocaCola,
            PepsiMax,
            Fanta,
            Sprite,
        };
    }

    class Przekaska : Automat // utworzenie podklasy Przekaska z Automat
    {
        public static Przekaska Batonik = new Przekaska { Nazwa = "Batonik czekoladowo-kokosowy", Cena = 3M, ID = 1 }; // utworzenie dwoch obiektow (przekasek) w nich: nazwa, cena oraz id
        public static Przekaska Chrupki = new Przekaska { Nazwa = "Chrupki serowe", Cena = 8M, ID = 2 };

        public static List<Przekaska> ListaPrzekasek = new() // utworzenie listy do wyswietlania wczesniej utworzonych obiektow
        {
            Batonik,
            Chrupki,

        };
    }
}
