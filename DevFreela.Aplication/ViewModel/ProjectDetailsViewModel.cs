using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.ViewModel
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(int id, string title, string description, decimal? totalCost, DateTime? startedAt, DateTime? finisedAt, string clientName, string freelancerName)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
            StartedAt = startedAt;
            FinisedAt = finisedAt;
            ClientName = clientName;
            FreelancerName = freelancerName;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal? TotalCost { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinisedAt { get; private set; }
        public string ClientName { get; private set; }
        public string FreelancerName { get; private set; }
    }
}
