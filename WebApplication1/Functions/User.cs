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
        private string gender;
        private int disease;
        private int region;
        private DateTime dateOfCreation;

        internal string Name
        {
            get => name;
        }

        internal int Age
        {
            get => age;
        }

        internal string Gender
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
        internal DateTime DateOfCreation
        {
            get => dateOfCreation;
        }
        public User(string Name, string Age, string Gender, string Region, string Disease)
        {
            this.name = Name;
            if (!int.TryParse(Age, out this.age) || age < 0 || age > 120)
                throw new AgeException();
            if (Gender == null)
                throw new GenderException();
            else
                this.gender = Gender;
            if (!int.TryParse(Disease, out this.disease))
                throw new DiseaseException();
            this.region = int.Parse(Region);
            dateOfCreation = DateTime.Now;
        }
    }
}
