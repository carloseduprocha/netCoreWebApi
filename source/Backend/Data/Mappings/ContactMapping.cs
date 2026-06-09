
using Contatos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contatos.Data.Mappings
{
    public class ContactMapping : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(120);
            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(80);
            builder.HasIndex(c => c.Email).IsUnique();
            builder.Property(c => c.Phone)
                .IsRequired()
                .HasMaxLength(11);
        }
    }
}
