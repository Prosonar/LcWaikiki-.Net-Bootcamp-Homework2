using EntityFrameworkMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkMigration.DataAccess.Mapping
{
    public class SchoolMapping : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.ToTable("School", "dbo");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id");
            builder.Property(b => b.Name).HasColumnName("Name");
            builder.Property(b => b.CityId).HasColumnName("CityId");
            builder.Property(b => b.SchoolTypeId).HasColumnName("SchoolTypeId");
        }
    }
}
