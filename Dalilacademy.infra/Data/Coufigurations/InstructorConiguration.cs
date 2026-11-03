using Dalilacademy_.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dalilacademy.infra.Data.Coufigurations
{
    internal class InstructorConiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.id);
            builder.Property(i => i.fullname)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(i => i.price)
                .IsRequired();
            builder.HasMany(i => i.courses)
                .WithOne(c => c.instructor)
                .HasForeignKey(c => c.instructorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
