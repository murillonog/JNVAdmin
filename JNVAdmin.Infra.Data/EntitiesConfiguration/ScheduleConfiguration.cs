using JNVAdmin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JNVAdmin.Infra.Data.EntitiesConfiguration
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            EntityBaseConfiguration<Schedule>.Configure(builder);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Date)
                .HasColumnType("datetime");

            builder.Property(e => e.Quantity)
                .HasColumnType("int")
                .IsRequired(false);

            builder.Property(e => e.AvarageAge)
                .HasColumnType("decimal(18,2)")
                .IsRequired(false);

            builder.Property(e => e.SpentValue)
                .HasColumnType("decimal(18,2)")
                .IsRequired(false);

            builder.Property(e => e.ReceivedValue)
                .HasColumnType("decimal(18,2)")
                .IsRequired(false);

            builder.Property(e => e.FullValue)
                .HasColumnType("decimal(18,2)")
                .IsRequired(false);

            builder.HasOne(x => x.Snack)
                .WithMany(x => x.Schedules)
                .HasForeignKey(x => x.SnackId);
        }
    }
}
