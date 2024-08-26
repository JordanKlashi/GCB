namespace P3C8
{
    public class Client
    {
        public string Nom { get; set; }
        public string NumeroCompte { get; set; }

        public Client(string nom, string numeroCompte)
        {
            Nom = nom;
            NumeroCompte = numeroCompte;
        }
    }

    public class CompteBancaire
    {
        public decimal Solde { get; protected set; }
        public Client Client { get; private set; }
        public string NumeroCompte { get; private set; }

        public CompteBancaire(Client client, string numeroCompte)
        {
            Client = client;
            NumeroCompte = numeroCompte;
            Solde = 0;
        }

        public virtual void Deposer(decimal montant)
        {
            Solde += montant;
            Console.WriteLine($"Vous avez déposé : {montant} €.");
        }

        public virtual void Retirer(decimal montant)
        {
            if (Solde >= montant)
            {
                Solde -= montant;
                Console.WriteLine($"Vous avez retiré : {montant} €.");
            }
            else
            {
                Console.WriteLine("Fonds insuffisants.");
            }
        }

        public void AfficherSolde()
        {
            Console.WriteLine($"Solde du compte : {Solde} €.");
        }
    }

    public class CompteCourant : CompteBancaire
    {
        public CompteCourant(Client client, string numeroCompte)
            : base(client, numeroCompte)
        {
        }
    }

    public class CompteEpargne : CompteBancaire
    {
        public CompteEpargne(Client client, string numeroCompte)
            : base(client, numeroCompte)
        {
        }
    }

}