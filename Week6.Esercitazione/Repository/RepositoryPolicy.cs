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
    public class RepositoryPolicy : IRepositoryPolicy
    {
        public Policy Create(Policy item)
        {
            using(var ctx = new InsuranceContext())
            {
                try
                {
                    if(item != null)
                    {
                        ctx.Entry<Policy>(item).State = EntityState.Added;
                        ctx.Policies.Add(item);
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

        public ICollection<Policy> GetAll()
        {
            using (var ctx = new InsuranceContext())
            {
                return ctx.Policies.ToList();
            }
        }
    }
}
