using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    public class User
    {
        private string name;
        private int age;
        private int gender;
        private int disease;
        private int region;
        private int durationOfIlness;
        private int exacerbation;
        private int stage;
        private DateTime dateOfCreation;

        internal string Name
        {
            get => name;
        }

        internal int Age
        {
            get => age;
        }

        internal int Gender
        {
            get => gender;
        }

        internal int Disease
        {
            get => disease;
        }

        internal int Region
        {
            get => region;
        }

        internal int DurationOfIlness
        {
            get => durationOfIlness;
        }

        internal int Exacerbation
        {
            get => exacerbation;
        }

        internal int Stage
        {
            get => stage;
        }

        internal DateTime DateOfCreation
        {
            get => dateOfCreation;
        }
        public User(string Name, string Age, string Gender, string Region, string Disease, string DurationOfIlness, string Exacerbation, string Stage)
        {
            this.name = Name;
            this.age = int.Parse(Age);
            this.gender = int.Parse(Gender);
            this.disease = int.Parse(Disease);
            this.region = int.Parse(Region);
            this.durationOfIlness = int.Parse(DurationOfIlness);
            this.exacerbation = int.Parse(Exacerbation);
            this.stage = int.Parse(Stage);
            dateOfCreation = DateTime.Now;
        }
    }
}
