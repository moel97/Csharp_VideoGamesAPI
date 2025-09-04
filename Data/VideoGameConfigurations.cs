using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGameApi.Models;

namespace VideoGameApi.Data
{
    public class VideoGameConfigurations : IEntityTypeConfiguration<VideoGame>
    {
        public void Configure(EntityTypeBuilder<VideoGame> builder)
        {
            builder.Property(b => b.Publisher).
                HasConversion( v => string.Join(',',v.Where(s => s != "")),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
        }
    }
}
