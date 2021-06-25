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
    public class PolicyConfiguration : IEntityTypeConfiguration<Policy>
    {
        public void Configure(EntityTypeBuilder<Policy> builder)
        {
            //specifico con le fluent api le caratteristiche della mia tabella
            builder.ToTable("Policy");
            builder.HasKey(k => k.Number);
            builder.Property(e => e.DateOfSign).HasColumnType("datetime2").IsRequired();
            builder.Property(r => r.InsuredAmount).HasColumnType("float").IsRequired();
            builder.Property(t => t.MonthlyRate).HasColumnType("float").IsRequired();

            //scrivo il discriminator
            builder.HasDiscriminator<string>("Policy_type")
                   .HasValue<PolicyLife>("life")
                   .HasValue<PolicyRCCar>("RCcar")
                   .HasValue<PolicyTheft>("theft");

            //scrivo il collegamento con la tab client: relazione uno(client) a molti(policies)
            builder.HasOne(y => y.Client) //navigation property di collegamento in policy
                   .WithMany(u => u.Policies)   //la lista in client
                   .HasForeignKey(i => i.CFClient); //la FK in policy

            


        }
    }
}
