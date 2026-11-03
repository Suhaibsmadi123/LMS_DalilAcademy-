using Dalilacademy_.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dalilacademy.infra.Data.Coufigurations
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.id);
            builder.Property(s => s.fullname)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(s => s.email)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasIndex(s => s.email)
                .IsUnique();
            builder.HasMany(s => s.enrollments)
                .WithOne(e => e.student)
                .HasForeignKey(e => e.studentId);
        }
    }
}
