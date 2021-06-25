using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.Esercitazione.Context;
using Week6.Esercitazione.Model;
using Microsoft.EntityFrameworkCore;

namespace Week6.Esercitazione.Repository
{
    public class RepositoryClient : IRepositoryClient
    {
        public Client Create(Client item)
        {
            using (var ctx = new InsuranceContext())
            {
                try
                {
                    if (item != null)
                    {
                        ctx.Entry<Client>(item).State = EntityState.Added;
                        //ctx.Clients.Add(item);
                        ctx.SaveChanges();
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
                return item;
        }

        public ICollection<Client> GetAll()
        {
            using(var ctx = new InsuranceContext())
            {
                return ctx.Clients.ToList();   //mi faccio ritornare la lista
            }
        }

        public Client GetByCF(string CF)
        {
            using (var ctx = new InsuranceContext())        //Mi sa che non mi serve
            {
               return ctx.Clients.Find(CF);
            }
        }

        public bool InsertPolicy(string CF, Policy policy)
        {
            bool esito = false;
            using (var ctx = new InsuranceContext())
            {
                try
                {
                    var client = ctx.Clients.Include(p => p.Policies)
                        .FirstOrDefault(n => n.CF == CF);
                    client.Policies.Add(policy);
                    policy.Client = client;
                    ctx.SaveChanges();
                    esito = true; //se va in porto ritorna true
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return esito; //false
                }
            }
            return esito;
        }
    }
}
