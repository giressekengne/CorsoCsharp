using System;
using System.Collections.Generic;

namespace CorsoCsharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Console.WriteLine("This is smy first program");
            // variabili, costanti e comenti;
            String nome = "Giresse";
            String cognome = "Kengne";
            int eta = 10 ;

            Console.WriteLine($"Mi chiamo {nome},{cognome} ed ho {eta} anni");// interpolazione
            Console.WriteLine("Mi chiamo " +nome +cognome + "ed ho" +eta);
            // lavorare con le stringhe

            String lc = nome.ToLower();
            Console.WriteLine(lc);

            // input degli utenti
            Console.WriteLine("Inserici un numero 1:");
           string numero1 = Console.ReadLine();
            Console.WriteLine("Inserici un numero 2:");
            string numero2 = Console.ReadLine();

            // casting esplicito convertiomo da stringa ad intero
            // try e catch and finilly le eccezioni

            Console.WriteLine();
            int num1 = 0;
            int num2 = 0;

            try
            {
                num1 = int.Parse(numero1);
                num2 = int.Parse(numero2);
            }
            catch (FormatException)
            {
                Console.WriteLine("Errore di Formato: Inserisci un Numero Valido ");
                //throw;
            }
            catch (OverflowException)
            {
                Console.WriteLine("IL Numero deve essere long ");
            }
            catch(ArgumentNullException)
            {
                Console.WriteLine("L'argomento non puo essere nullo");
            }
            finally
            {
                Console.WriteLine("Lo chiudo a prescindere");
            }

            int ris = num1 + num2;
            Console.WriteLine($"Il risultato è: {ris}");

            // Cliclo for e Foreach

            for(int i = 0; i < ris; i++)
            {
                Console.WriteLine(i);
            }

            string[] nomi =  { "giresse", "mathias", "cedrick" };
            for(int i=0; i < nomi.Length; i++)
            {
                if (nomi[i] == "giresse")
                {
                    break;
                }
                Console.WriteLine(nomi[i]);
            }
            foreach(string name in nomi)
            {
                Console.WriteLine(name);
            }

            // gli Array
            String[] cognomi = {"kengne","demanou","donfack",};
            for(int i=0; i < cognomi.Length; i++)
            {
                Console.WriteLine(cognomi[i]);
            }
            String[] surnames = new string[3];
            surnames[0] = "kengne";
            surnames[1] = "demanou";
            surnames[2] = "donfack";
            foreach(string surname in surnames)
            {
                Console.WriteLine(surname);
            }

            // gli Array 2D
            string[,] codici = {
                {"010","011" },
                {"020","021" },
                {"030","031" }
            };
            foreach(string codice in codici)
            {
                Console.WriteLine(codice); 
            }
            /*
            String[,] codes = new string[2, 3];
            codes[0,0] = "010";
            codes[0,1] = "011";

            codes[1,0] = "020";
            codes[1,1] = "021";

            codes[2, 0] = "030";
            codes[2, 1] = "031";
            */
            // Dictionary
            Dictionary<String, String> dic = new Dictionary<String, String>();

            Dictionary<String, String> dic2 = new Dictionary<String, String>()
            {
                { "Lombardia","Milano" },
                { "Liguria","Genova" },
                { "Piemonte","Torino" },
                { "Lazio","Napoli"},
                {"Toscana","Catanzaro" }
            };
            dic2.Add("Veneto", "Venezia");
            dic2["Lazio"] = "Roma";
            dic2.Remove("Toscana");
            Console.WriteLine(dic2.ContainsKey("Lazio"));
            Console.WriteLine(dic2.ContainsValue("Roma"));

            foreach(var citta in dic2)
            {
                Console.WriteLine(citta.Value);
            }

            // Persona pers1 = new Persona("Giresse","Kengne",25,"bene");

            MESI meseNascita = MESI.Marzo;
            Console.WriteLine(meseNascita);

            int numMese = (int)MESI.Marzo;
            Console.WriteLine(numMese);

            SESSO sex = SESSO.Femina;
            Console.WriteLine($"Sono una {sex}");

            // Lavorare con le date
            DateTime data = new DateTime();
            Console.WriteLine(data);

            DateTime date =  DateTime.Today;
            Console.WriteLine(date);
            DateTime date1 = DateTime.Now;
            Console.WriteLine(date1); 
            
        }

        // metodi e funzioni e swict case
        static void saluta(String nome, int orario)
        {
            switch (orario)
            {
                case 0:
                    Console.WriteLine ($"ciao {nome}, Buongiorno");
                    break;
                case 1:
                    Console.WriteLine($"ciao {nome}, Buonpomeriggio");
                    break;
                case 2:
                    Console.WriteLine($"ciao {nome}, BuonaSera");
                    break;

                default:
                    Console.WriteLine($"Ciao {nome}, Buongiorno");
                    break;
                    
            }

        }
        public class Persona
        {
            protected string _nome;
            protected string _cognome;
            protected int _eta;
            protected string Value { get; set; }
            public static int NumPers =0;

            public Persona(string nome, string cognome, int eta, string value)
            {
                _nome = nome;
                _cognome = cognome;
                _eta = eta;
                Value = value;
                Persona.NumPers++;
            }

            public virtual void saluta()
            {
                Console.WriteLine($"ciao sono {_nome} ");
            }

            public String Nome
            { 
                get => _nome;
                set => _nome = value;
            }
            public string getCognome()
            {
                return _cognome;
            }
            public void setCognome(string cognome)
            {
                _cognome = cognome;
            }


        }
        public class Studente : Persona
        {
            private string _classe { get; set; }  

            public Studente(string nome, string cognome, int eta, string Value, string classe) : base (nome, cognome, eta, Value)
            {
                
                   _classe = classe;
            }

            public override void saluta()
            {
                base.saluta();
                Console.WriteLine($"Buongiorno prof");
            }
        }

        public class Insegnante : Persona
        {
            private String _materia { get; set; }

            public Insegnante(string nome,string cognome, int eta, string value,string materia) : base (nome, cognome, eta,value)
            {
                _materia = materia;
            }
            public override void saluta()
            {
                base.saluta();
                Console.WriteLine($"Buongiorno ragazzi");
            }
        }

        enum MESI
        {
            Gennaoi =1 , Febbraio, Marzo, Aprile, Maggio, Giugno, Luglio, Agosto,
            Settembre, Ottobre, Novembre, Dicembre
        }

        enum SESSO
        {
            Maschio,Femina,Trans
        }
    }
}
