﻿using System;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName, double salary)
            :base(id, firstName, lastName)
        {
            this.Salary = salary;
        }
        public double Salary { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {this.Salary :f2}";
        }
    }
}