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
    internal class ProjectConfigurations : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Freelancer).WithMany(x => x.FreelancerProjects).HasForeignKey(x => x.IdFreelancer).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Client).WithMany(x => x.OwenedProjects).HasForeignKey(x => x.IdClient).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
