using System;

namespace linkQtrainning
{
    public class Subjects
    {
        public string Name {get; private set;} = "";
        public int Count {get; private set;}
        public double? Weight {get; private set;}

        public override string ToString()
        {
            return new ($"-(Subject: {Name}, Count: {Count}, Weight: {Weight}.)");
        }

        public string SetName(string name)
        {
            return Name = name;
        }

        public int SetCount(int count)
        {
            return Count = count;
        }

        public double? SetWeight(double? weight)
        {
            return Weight = weight;
        }
    }
}