//I got support from ChatGPT while writing the code.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_IrmakKaytan
{
    internal class Player
    {
        public string Name { get; set; }
        public int SocialScore { get; set; }
        public int AcademicScore { get; set; }

        public Player(string name)
        {
            Name = name;
            SocialScore = 0;
            AcademicScore = 0;
        }

        public void DisplayStats()
        {
            Console.WriteLine($"\n{Name}'s Stats:");
            Console.WriteLine($"Social Score: {SocialScore}");
            Console.WriteLine($"Academic Score: {AcademicScore}");
        }
    }
}
