// See https://aka.ms/new-console-template for more information
using EsWeek7;
//Il codice commentato è relativo alle prove fatte per incapsulare un try catch con l'exception creata UserNotFounfException
//Le risposte sono
//1)c
//2)b,c
//3)a

Console.WriteLine("Hello, World!");
bool continuare = true;
RepositoryADO repo = new RepositoryADO();
do
{
    Console.WriteLine("Premi 1 per fare Login");
    Console.WriteLine("Premi 0 per uscire");
    int scelta;
    do
    {
        Console.WriteLine("\nInserisci una tra le possibili scelte:");
    } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 1));

    switch (scelta)
    {
        case 1:
            Login();
            break;
        case 0:
            Console.WriteLine("Ciao!");
            continuare = false;
            break;
               }
} while (continuare);

void Login()
{
    string[] credenzialiInseriteDaUtente = ChiediCredenziali();
    Utente utenteRecuperato = repo.GetUserByCredentials(credenzialiInseriteDaUtente[0], credenzialiInseriteDaUtente[1]);
    if (utenteRecuperato == null)
    {
        Console.WriteLine("Accesso negato.");
    }
    else
    {
        Console.WriteLine($" Bentornato {utenteRecuperato}");
    }
}

string[] ChiediCredenziali()
{
    string username = string.Empty;
    do
    {
        Console.WriteLine("Inserisci username");
        username = Console.ReadLine();

    } while (string.IsNullOrEmpty(username));

    string password = string.Empty;
    do
    {
        Console.WriteLine("Inserisci password");
        password = Console.ReadLine();

    } while (string.IsNullOrEmpty(password));
    return new string[] { username, password };
}