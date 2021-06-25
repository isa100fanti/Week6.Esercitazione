using System;
using Week6.Esercitazione.Context;
using Week6.Esercitazione.Model;
using Week6.Esercitazione.Repository;

namespace Week6.Esercitazione
{
    class Program
    {
        private static IRepository<Client> repoClient = new RepositoryClient();
        private static IRepository<Policy> repoPolicy = new RepositoryPolicy();

        static void Main(string[] args)
        {
            /*- Inserire nuovi clienti
    - Inserire una polizza (rcauto, furto, vita) per un cliente
    - Stampare i dati delle polizze presenti a db (comprese le info sul cliente che l'ha stipulata*).
    In fase di stampa dei dati del cliente deve essere visualizzabile anche la spesa totale mensile che il cliente sostiene per tutte le sue polizze.
*/

            Client c = new Client()
            {
                CF = "AS34FG23JK45L23M",
                FirstName = "Jen",
                LastName = "Creek",
                Address = "First Street 4"
            };
            Client c1 = new Client()
            {
                CF = "AS34FG23JK4E3ES2",
                FirstName = "Karl",
                LastName = "Fredriksen",
                Address = "Paradise Waterfall 4"
            };
            repoClient.Create(c1);
            using (var ctx = new InsuranceContext())
            {
                foreach (var client in ctx.Clients)
                {
                    Console.WriteLine(client);
                }
            }

        bool continua = true;
            while (continua)
            {
                continua = InsuranceManagement.Menu();
            }


        }
    }
}
