using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("===============OPERAZIONI==============");
            Console.WriteLine("Scegli l'operazione da effettuare:");
            Console.WriteLine("1.: Login");
            Console.WriteLine("2.: Logout");
            Console.WriteLine("3.: Verifica ora e data di login");
            Console.WriteLine("4.: Lista degli accessi");
            Console.WriteLine("5.: Esci");
            Console.WriteLine("========================================");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    Logout();
                    break;
                case "3":
                    VerificaOraDataLogin();
                    break;
                case "4":
                    ListaAccessi();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Scelta non valida. Riprova.");
                    break;
            }
        }
    }

    static class Utente
    {
        public static string Username { get; private set; }
        private static string Password { get; set; }
        private static DateTime? LastLoginDateTime { get; set; }
        private static List<DateTime> Accessi { get; set; } = new List<DateTime>();

        public static void Login(string username, string password, string confermaPassword)
        {
            if (!string.IsNullOrEmpty(username) && password == confermaPassword)
            {
                Username = username;
                Password = password;
                LastLoginDateTime = DateTime.Now;
                Accessi.Add(LastLoginDateTime.Value);
                Console.WriteLine("Login effettuato con successo.");
            }
            else
            {
                Console.WriteLine("Errore durante il login. Assicurati di inserire una username e che le password coincidano.");
            }
        }

        public static void Logout()
        {
            if (!string.IsNullOrEmpty(Username))
            {
                Username = null;
                Password = null;
                LastLoginDateTime = null;
                Console.WriteLine("Logout effettuato con successo.");
            }
            else
            {
                Console.WriteLine("Nessun utente loggato. Impossibile effettuare il logout.");
            }
        }

        public static void VerificaOraDataLogin()
        {
            if (!string.IsNullOrEmpty(Username))
            {
                Console.WriteLine($"Ultimo login effettuato il: {LastLoginDateTime}");
            }
            else
            {
                Console.WriteLine("Nessun utente loggato. Impossibile verificare l'ora e la data di login.");
            }
        }

        public static void ListaAccessi()
        {
            if (!string.IsNullOrEmpty(Username))
            {
                Console.WriteLine("Lista degli accessi:");
                foreach (var accesso in Accessi)
                {
                    Console.WriteLine(accesso);
                }
            }
            else
            {
                Console.WriteLine("Nessun utente loggato. Impossibile visualizzare la lista degli accessi.");
            }
        }
    }

    static void Login()
    {
        Console.Write("Inserisci username: ");
        string username = Console.ReadLine();

        Console.Write("Inserisci password: ");
        string password = Console.ReadLine();

        Console.Write("Conferma password: ");
        string confermaPassword = Console.ReadLine();

        Utente.Login(username, password, confermaPassword);
    }

    static void Logout()
    {
        Utente.Logout();
    }

    static void VerificaOraDataLogin()
    {
        Utente.VerificaOraDataLogin();
    }

    static void ListaAccessi()
    {
        Utente.ListaAccessi();
    }
}
