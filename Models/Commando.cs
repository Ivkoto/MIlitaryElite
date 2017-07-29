using System;
using System.Collections.Generic;
using MilitaryElite.Interfaces;
using System.Text;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, double salary, string corp, IList<IMission> missions) 
            : base(id, firstName, lastName, salary, corp)
        {
            this.Missions = missions;
        }

        public IList<IMission> Missions { get; private set; }

        public void CompleteMission()
        {            
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
              sb.AppendLine($"{base.ToString()}")
              .AppendLine("Missions:")
              .AppendLine($"  {string.Join(Environment.NewLine + "  ", this.Missions)}");

            return sb.ToString().Trim();
        }
    }
}