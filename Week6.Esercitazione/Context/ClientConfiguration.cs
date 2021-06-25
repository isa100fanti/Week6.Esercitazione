using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.Esercitazione.Model;

namespace Week6.Esercitazione.Context
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            //specifico con le fluent api le caratteristiche della mia tabella

            builder.ToTable("Client");
            builder.HasKey(k => k.CF);
            builder.Property("CF").HasMaxLength(16).IsFixedLength();
            builder.Property("FirstName").HasMaxLength(20).IsRequired();
            builder.Property("LastName").HasMaxLength(20).IsRequired();
            builder.Property(q => q.Address).HasMaxLength(50).IsRequired();

            builder.HasData(new Client()
            {
                CF = "AS23DF45G3HH12K3",
                FirstName = "Ben",
                LastName = "Harris",
                Address = "Kensigton road 3b"
            },
            new Client()
            {
                CF = "ER56YU7F3S1FF33H",
                FirstName = "James",
                LastName = "Rodrigues",
                Address = "Trafalgar Square 2"
            });

        }
    }
}
