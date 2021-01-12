using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STORE.ENTITY.Entities;

namespace STORE.DATA.Configurations
{
    public class BaseConfiguration<Tentity> : IEntityTypeConfiguration<Tentity> where Tentity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<Tentity> builder)
        {
            
            builder.HasKey(p => p.Id);
            builder.Property(p=>p.Id).UseMySqlIdentityColumn();
        }
    }
}
