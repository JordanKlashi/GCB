using P3C8;

namespace GestionnaireDeCompteBancaire
{
    class Program
    {
        static void Main(string[] args)
        {
            // Création du client et des comptes
            Client client = new Client("Jean Dupont", "123456");
            CompteCourant compteCourant = new CompteCourant(client, "CC123456");
            CompteEpargne compteEpargne = new CompteEpargne(client, "CE123456");

            List<string> transactions = new List<string>();

            bool quitter = false;
            while (!quitter)
            {
                Console.WriteLine("Appuyez sur Entrée pour afficher le menu.");
                Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Veuillez sélectionner une option ci-dessous :");
                Console.WriteLine("[I] Voir les informations sur le titulaire du compte");
                Console.WriteLine("[CS] Compte courant - Consulter le solde");
                Console.WriteLine("[CD] Compte courant - Déposer des fonds");
                Console.WriteLine("[CR] Compte courant - Retirer des fonds");
                Console.WriteLine("[ES] Compte épargne - Consulter le solde");
                Console.WriteLine("[ED] Compte épargne - Déposer des fonds");
                Console.WriteLine("[ER] Compte épargne - Retirer des fonds");
                Console.WriteLine("[X] Quitter");

                string choix = Console.ReadLine().ToUpper();

                switch (choix)
                {
                    case "I":
                        AfficherInformationsClient(client);
                        break;
                    case "CS":
                        AfficherSoldeCompte(compteCourant, "courant");
                        break;
                    case "CD":
                        EffectuerDepot(compteCourant, transactions, "courant");
                        break;
                    case "CR":
                        EffectuerRetrait(compteCourant, transactions, "courant");
                        break;
                    case "ES":
                        AfficherSoldeCompte(compteEpargne, "épargne");
                        break;
                    case "ED":
                        EffectuerDepot(compteEpargne, transactions, "épargne");
                        break;
                    case "ER":
                        EffectuerRetrait(compteEpargne, transactions, "épargne");
                        break;
                    case "X":
                        quitter = true;
                        SauvegarderTransactions(transactions);
                        break;
                    default:
                        Console.WriteLine("Option non valide.");
                        break;
                }
            }
        }

        static void AfficherInformationsClient(Client client)
        {
            Console.WriteLine($"Nom du titulaire : {client.Nom}");
            Console.WriteLine($"Numéro de compte : {client.NumeroCompte}");
            Console.WriteLine("Appuyez sur Entrée pour revenir au menu.");
            Console.ReadLine();
        }

        static void AfficherSoldeCompte(CompteBancaire compte, string typeCompte)
        {
            Console.WriteLine($"Solde du compte {typeCompte} : {compte.Solde} €.");
            Console.WriteLine("Appuyez sur Entrée pour revenir au menu.");
            Console.ReadLine();
        }

        static void EffectuerDepot(CompteBancaire compte, List<string> transactions, string typeCompte)
        {
            Console.WriteLine("Quel montant souhaitez-vous déposer ?");
            decimal montant = decimal.Parse(Console.ReadLine());
            compte.Deposer(montant);
            transactions.Add($"Dépôt de {montant} € sur le compte {typeCompte}.");
            Console.WriteLine("Appuyez sur Entrée pour revenir au menu.");
            Console.ReadLine();
        }

        static void EffectuerRetrait(CompteBancaire compte, List<string> transactions, string typeCompte)
        {
            Console.WriteLine("Quel montant souhaitez-vous retirer ?");
            decimal montant = decimal.Parse(Console.ReadLine());
            compte.Retirer(montant);
            transactions.Add($"Retrait de {montant} € sur le compte {typeCompte}.");
            Console.WriteLine("Appuyez sur Entrée pour revenir au menu.");
            Console.ReadLine();
        }

        static void SauvegarderTransactions(List<string> transactions)
        {
            // Chemin absolu - ici on spécifie le bureau de l'utilisateur sous Windows
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "transactions.txt");

            File.WriteAllLines(filePath, transactions);
            Console.WriteLine($"Toutes les transactions ont été sauvegardées dans {filePath}.");
        }
    }
}
