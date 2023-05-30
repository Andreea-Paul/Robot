using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    public class Lifeform
    {
        public string Name { get; set; }
        public bool IsAlive { get; set; }
        public int HP { get; set; }

        public Lifeform(string name, int hp)
        {
            Name = name;
            IsAlive = true;
            HP = hp;
        }

    }
    public class Animal : Lifeform
    {
        public Animal(string name) : base(name, 200)
        {
        }
    }

    public class Human : Lifeform
    {
        public Human(string name) : base(name, 300)
        {
        }
    }

    public class Superhero : Lifeform
    {
        public Superhero(string name) : base(name, 1000)
        {
        }
    }
}
