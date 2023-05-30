using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    public class Planet
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public bool ContainsLife { get; set; }
        public List<Lifeform> Lifeforms { get; set; }

        public Planet(string name, int population, bool containsLife)
        {
            Name = name;
            Population = population;
            ContainsLife = containsLife;
            Lifeforms = GenerateLifeforms(population);

            Console.WriteLine($"Initialized planet: {Name}. Population: {Population}. Contains Life: {ContainsLife}");
        }

        private List<Lifeform> GenerateLifeforms(int population)
        {
            List<Lifeform> lifeforms = new List<Lifeform>();

            int animalPopulation = (int)(population * 0.7);
            int humanPopulation = (int)(population * 0.29);
            int superheroPopulation = population - animalPopulation - humanPopulation;

            for (int i = 0; i < animalPopulation; i++)
            {
                lifeforms.Add(new Animal($"{Name} Animal{i + 1}"));
            }

            for (int i = 0; i < humanPopulation; i++)
            {
                lifeforms.Add(new Human($"{Name} Human{i + 1}"));
            }

            for (int i = 0; i < superheroPopulation; i++)
            {
                lifeforms.Add(new Superhero($"{Name} Superhero{i + 1}"));
            }

            return lifeforms;
        }


    }
}
