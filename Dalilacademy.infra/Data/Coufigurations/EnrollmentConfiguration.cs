using Dalilacademy_.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dalilacademy.infra.Data.Coufigurations
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => e.id);
            builder.HasIndex(e => new { e.studentId, e.courseId }).IsUnique();
            builder.HasOne(e => e.student)
                   .WithMany(s => s.enrollments)
                   .HasForeignKey(e => e.studentId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.course)
                   .WithMany(c => c.enrollments)
                   .HasForeignKey(e => e.courseId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Property(e => e.enrollmentAt)
                   .IsRequired()
                   .HasDefaultValueSql("now()");
        }
    }
}
