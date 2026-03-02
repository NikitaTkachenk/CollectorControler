using System;

namespace linkQtrainning
{
    public class Subjects
    {
        public string Name {get; private set;} = "";
        public int Count {get; private set;}
        public double? Weight {get; private set;}

        public Subjects(string name, int count, double? weight)
        {
            Name = name;
            Count = count;
            Weight = weight;
        }

        public override string ToString()
        {
            return new ($"-(Subject: {Name}, Count: {Count}, Weight: {Weight}.)");
        }

        public void Initialize(string name, int count, double? weight)
        {
            SetName(name);
            SetCount(count);
            SetWeight(weight);
        }

        public void Decrease(int value)
        {
            if(value <= 0)
                throw new ArgumentNullException(nameof(value));
            
            if(value > Count)
                Count = 0;
            else    
                Count -= value;
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