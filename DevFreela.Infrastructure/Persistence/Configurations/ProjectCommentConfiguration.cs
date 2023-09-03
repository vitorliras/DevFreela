using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    internal class ProjectCommentConfiguration : IEntityTypeConfiguration<ProjectComment>
    {
        public void Configure(EntityTypeBuilder<ProjectComment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Project).WithMany(x => x.Comments).HasForeignKey(x => x.IdProject);
            builder.HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.IdUser);

        }
    }
}
