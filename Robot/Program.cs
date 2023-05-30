using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Problema enuntata de acest pseudocod este aceea ca un robot killer a fost initializat pentru a distruge toate fiintele vii de pe planeta Pamant. Robotul este dotat cu un laser puternic si poate distruge animale, oameni si supereroi. Robotul isi va folosi ochii pentru a cauta tinte si va incerca sa le distruga pana cand nu mai exista viata pe Pamant.
namespace Robot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GiantKillerRobot giantKillerRobot = new GiantKillerRobot();
            giantKillerRobot.Initialize();

            giantKillerRobot.IntensityLevels = new List<Intensity>
        {
            Intensity.None,
            Intensity.Low,
            Intensity.Medium,
            Intensity.High,
            Intensity.Kill
        };

            Planet earth = new Planet("Earth", 10, true);
            Planet mars = new Planet("Mars", 10, true);
            Planet venus = new Planet("Venus", 5, true);

            giantKillerRobot.ExecuteDestroyLifeLoop(earth);

            giantKillerRobot.ExecuteDestroyLifeLoop(mars);

            giantKillerRobot.ExecuteDestroyLifeLoop(venus);
        }
    }
}
    
    

