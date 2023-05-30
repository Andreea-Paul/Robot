using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    public enum Intensity
    {
        None = 0,
        Low = 10,
        Medium = 30,
        High = 50,
        Kill = 100
    }
    public class Robot
    {
        public virtual void Initialize()
        {
            Console.WriteLine("Robot initialized");
        }
    }

    public class GiantKillerRobot : Robot
    {
        public List<Intensity> IntensityLevels { get; set; }
        public List<Lifeform> Targets { get; set; }

        public bool Active { get; set; }
        public Lifeform CurrentTarget { get; private set; }

        

        public override void Initialize()
        {
            Active = true;
            Console.WriteLine("Killer Robot initialized");
        }

        public void FireLaserAt(Lifeform target)
        {
            Intensity intensity = GetIntensity(target);
            int reduction = (int)intensity;

            Console.WriteLine($"Firing laser at {target.Name} with intensity {intensity}");
            target.HP -= reduction;

            if (target.HP <= 0)
            {
                target.IsAlive = false;
                Console.WriteLine($"Killed {target.Name}");

                if (Targets.FindAll(lifeform => lifeform.IsAlive && lifeform.GetType() == target.GetType()).Count == 0)
                {
                    Console.WriteLine($"Killed all {target.GetType().Name}s");
                }

                if (Targets.FindAll(lifeform => lifeform.IsAlive).Count == 0)
                {
                    Active = false;
                    Console.WriteLine("The planet no longer contains life");
                }
            }
        }

        public void AcquireNextTarget()
        {
            if (Targets.Count > 0)
            {
                CurrentTarget = Targets[0];
                Targets.RemoveAt(0);
            }
            else
            {
                Active = false;
            }
        }

        private Intensity GetIntensity(Lifeform target)
        {
            if (target is Human || target is Animal)
            {
                return Intensity.High;
            }
            else if (target is Superhero)
            {
                return Intensity.Kill;
            }
            else
            {
                return Intensity.None;
            }
        }

        public void ExecuteDestroyLifeLoop(Planet planet)
        {
            Targets = planet.Lifeforms;

            Console.WriteLine("Switching to planet: " + planet.Name);
            while (Active && planet.ContainsLife)
            {
                if (CurrentTarget != null && CurrentTarget.IsAlive)
                {
                    FireLaserAt(CurrentTarget);
                }
                else
                {
                    AcquireNextTarget();
                }

                if (Targets.Count == 0)
                {
                    planet.ContainsLife = false;
                }
            }

            Console.WriteLine();
            Console.WriteLine("All life destroyed on " + planet.Name);
        }
    }
}


