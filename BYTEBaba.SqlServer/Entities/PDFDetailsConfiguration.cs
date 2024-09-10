using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BYTEBaba.Model.Entities;

namespace BYTEBaba.SqlServer.Entities
{
    public class PDFDetailsConfiguration : IEntityTypeConfiguration<PDFDetails>
    {
        public void Configure(EntityTypeBuilder<PDFDetails> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn(1, 1).HasColumnOrder(1);               

                
        }
    }
}
