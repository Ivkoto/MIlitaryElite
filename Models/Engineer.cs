using System;
using System.Collections.Generic;
using MilitaryElite.Interfaces;
using System.Text;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, double salary, string corp, IList<IRepair> parts) 
            : base(id, firstName, lastName, salary, corp)
        {
            this.Parts = parts;
        }

        public IList<IRepair> Parts { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{base.ToString()}")
              .AppendLine("Repairs:")
              .AppendLine($"  {string.Join(Environment.NewLine + "  ", this.Parts)}");

            return sb.ToString().Trim();
        }
    }
}