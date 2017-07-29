using MilitaryElite.Interfaces;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class Program
    {
        public static IList<ISoldier> army;

        private enum corpTypes { Airforces, Marines }

        private enum missionState { inProgress, Finished };

        public static void Main()
        {
            var input = string.Empty;
            army = new List<ISoldier>();
            while ((input = Console.ReadLine().Trim()) != "End")
            {
                var soldierArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                switch (soldierArgs[0])
                {
                    case "Private":
                        CreatePrivate(soldierArgs);
                        break;

                    case "LeutenantGeneral":
                        CreateLeutenantGeneral(soldierArgs);
                        break;

                    case "Engineer":
                        if (soldierArgs[5] != corpTypes.Airforces.ToString() && soldierArgs[5] != corpTypes.Marines.ToString())
                        {
                            break;
                        }
                        CreateEngineer(soldierArgs);
                        break;

                    case "Commando":
                        if (soldierArgs[5] != corpTypes.Airforces.ToString() && soldierArgs[5] != corpTypes.Marines.ToString())
                        {
                            break;
                        }
                        CretaeCommando(soldierArgs);
                        break;

                    case "Spy":
                        CreateSpy(soldierArgs);
                        break;
                }
            }

            foreach (var soldier in army)
            {
                Console.WriteLine(soldier);
            }
        }

        private static void CreateSpy(string[] soldierArgs)
        {
            var id = int.Parse(soldierArgs[1]);
            var firstName = soldierArgs[2];
            var lastName = soldierArgs[3];
            var codeNumber = int.Parse(soldierArgs[4]);
            army.Add(new Spy(id, firstName, lastName, codeNumber));
        }

        private static void CretaeCommando(string[] soldierArgs)
        {
            var id = int.Parse(soldierArgs[1]);
            var firstName = soldierArgs[2];
            var lastName = soldierArgs[3];
            var salary = double.Parse(soldierArgs[4]);
            var corp = soldierArgs[5];
            var missions = new List<IMission>();
            var missionsArg = soldierArgs.Skip(6).ToList();
            for (int i = 0; i < missionsArg.Count() - 1; i += 2)
            {
                if (missionsArg[i + 1] != missionState.Finished.ToString() && missionsArg[i + 1] != missionState.inProgress.ToString())
                {
                    continue;
                }
                missions.Add(new Mission(missionsArg[i], missionsArg[i + 1]));
            }
            var commando = new Commando(id, firstName, lastName, salary, corp, missions);
            army.Add(commando);
        }

        private static void CreateEngineer(string[] soldierArgs)
        {
            var id = int.Parse(soldierArgs[1]);
            var firstName = soldierArgs[2];
            var lastName = soldierArgs[3];
            var salary = double.Parse(soldierArgs[4]);
            var corp = soldierArgs[5];
            var parts = new List<IRepair>();
            var partsArgs = soldierArgs.Skip(6).ToList();
            for (int i = 0; i < partsArgs.Count() - 1; i += 2)
            {
                parts.Add(new Repair(partsArgs[i], int.Parse(partsArgs[i + 1])));
            }
            var engineer = new Engineer(id, firstName, lastName, salary, corp, parts);
            army.Add(engineer);
        }

        private static void CreateLeutenantGeneral(string[] soldierArgs)
        {
            var id = int.Parse(soldierArgs[1]);
            var firstName = soldierArgs[2];
            var lastName = soldierArgs[3];
            var salary = double.Parse(soldierArgs[4]);
            var privates = new List<ISoldier>();
            var privatesArgs = soldierArgs.Skip(5).ToList();
            foreach (var privId in soldierArgs.Skip(5))
            {
                var soldier = army.First(s => s.Id == int.Parse(privId));
                privates.Add(soldier);
            }
            var leutenantGeneral = new LeutenantGeneral(id, firstName, lastName, salary, privates);
            army.Add(leutenantGeneral);
        }

        private static void CreatePrivate(string[] soldierArgs)
        {
            var id = int.Parse(soldierArgs[1]);
            var firstName = soldierArgs[2];
            var lastName = soldierArgs[3];
            var salary = double.Parse(soldierArgs[4]);
            army.Add(new Private(id, firstName, lastName, salary));
        }
    }
}