using Dalilacademy.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dalilacademy.infra.Data.Coufigurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.id);
            builder.Property(c => c.title).IsRequired().HasMaxLength(200);
            builder.HasIndex(c => c.title).IsUnique();
            builder.Property(c => c.price).HasPrecision(10, 2);
            builder.Property(c => c.level).HasMaxLength(50);
            builder.HasOne(c => c.instructor)
                   .WithMany(i => i.courses)
                   .HasForeignKey(c => c.instructorId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
