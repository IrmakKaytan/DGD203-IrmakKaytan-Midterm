//I got support from ChatGPT while writing the code.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_IrmakKaytan
{
    internal class Question
    {
        public string Text { get; set; }
        public string[] Options { get; set; }
        public Action<Player>[] Effects { get; set; }

        public Question(string text, string[] options, Action<Player>[] effects)
        {
            Text = text;
            Options = options;
            Effects = effects;
        }

        public void Ask(Player player)
        {
            Console.WriteLine($"\n{player.Name}, {Text}");

            for (int i = 0; i < Options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Options[i]}");
            }

            int choice;
            while (true)
            {
                Console.Write("Your choice: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= Options.Length)
                {
                    Effects[choice - 1](player); 
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice, please try again.");
                }
            }
            Console.WriteLine($"\n{player.Name}, your choice has been recorded.");
        }
    }
}
