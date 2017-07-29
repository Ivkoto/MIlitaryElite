using System;
using System.Collections.Generic;
using MilitaryElite.Interfaces;
using System.Text;

namespace MilitaryElite.Models
{
    public class LeutenantGeneral : Private, ILeutenantGeneral
    {
        public LeutenantGeneral(int id, string firstName, string lastName, double salary, IList<ISoldier> soldiers)
            :base(id, firstName, lastName, salary)
        {
            this.Soldiers = soldiers;
        }
        public IList<ISoldier> Soldiers { get; private set; }
        

        public override string ToString()
        {
            var sb = new StringBuilder();
              sb.AppendLine($"{base.ToString()}")
              .AppendLine("Privates:")
              .AppendLine($"  {string.Join(Environment.NewLine + "  ", this.Soldiers)}");
            return sb.ToString().Trim();
        }
    }
}