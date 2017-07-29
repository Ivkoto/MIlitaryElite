using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.Name = codeName;
            this.State = state;
        }

        private string state;

        public string Name { get; private set; }

        public string State { get; private set; }

        public void CompleteMission()
        {
        }

        public override string ToString()
        {
            return $"Code Name: {this.Name} State: {this.State}";
        }
    }
}