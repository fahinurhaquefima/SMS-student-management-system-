using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.WebApp.Models;

namespace SMS.WebApp.ModelConfiguration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable(nameof(Student));
        //builder.ToTable("Student");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Name).HasMaxLength(20).IsRequired();
        builder.Property(t => t.Email).HasMaxLength(100).IsRequired();
        builder.Property(t => t.Phone).HasMaxLength(14).IsRequired();
        builder.Property(t => t.Address).HasMaxLength(250).IsRequired();
    }
}
