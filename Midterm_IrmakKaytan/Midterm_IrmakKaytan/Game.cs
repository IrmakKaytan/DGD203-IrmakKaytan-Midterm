//I got support from ChatGPT while writing the code.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_IrmakKaytan
{
    internal class Game
    {
        private Player player;

        public void Start()
        {
            Console.Write("Welcome, you are about to take part in a simulation of your first day at university. If you're ready, let's start! What's your name? ");
            string name;
            while (true)
            {
                name = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Name cannot be empty. Please enter a valid name.");
                }
                else
                {
                    break;
                }
            }
            player = new Player(name);

            Question[] questions = CreateQuestions();
            foreach (var question in questions)
            {
                question.Ask(player);
            }

            player.DisplayStats();
            DisplayEnding();
        }

        private Question[] CreateQuestions()
        {
            return new Question[]
            {
                new Question(
                    "You see a group of students near the library. What would you do in this situation?",
                    new string[] { "Join them and introduce yourself.", "Ignore them and head to the library.", "Watch them from afar." },
                    new Action<Player>[]
                    {
                        p => p.SocialScore += 5,
                        p => p.AcademicScore += 5,
                        p => p.SocialScore += 2
                    }
                ),
                new Question(
                    "The professor asks a question in class. What would you do in this situation?",
                    new string[] { "Raise your hand and answer confidently.", "Stay silent and listen.", "Whisper the answer to a nearby classmate." },
                    new Action<Player>[]
                    {
                        p => p.AcademicScore += 5,
                        p => p.AcademicScore += 2,
                        p => p.SocialScore += 3
                    }
                ),
                new Question(
                    "It's lunch time. Where do you prefer to sit?",
                    new string[] { "Make new friends at a random table.", "Sit alone and enjoy your meal.", "Grab food and find a quiet spot to read." },
                    new Action<Player>[]
                    {
                        p => p.SocialScore += 5,
                        p => p.AcademicScore += 2,
                        p => p.AcademicScore += 3
                    }
                ),
                new Question(
                    "A club invites you to their meeting. What would you do in this situation?",
                    new string[] { "Attend and actively participate.", "Decline politely.", "Attend but stay quiet." },
                    new Action<Player>[]
                    {
                        p => p.SocialScore += 5,
                        p => p.AcademicScore += 2,
                        p => { p.SocialScore += 2; p.AcademicScore += 2; }
                    }
                ),
                new Question(
                    "You're running late for class. How do you handle it?",
                    new string[] { "Get there as soon as you can.", "Take a deep breath and go at your own pace.", "Send a message to a friend to ask if you missed anything." },
                    new Action<Player>[]
                    {
                        p => p.AcademicScore += 3,
                        p => p.AcademicScore += 2,
                        p => p.SocialScore += 2
                    }
                ),
                new Question(
                    "You get invited to a study group. What would you do in this situation?",
                    new string[] { "Join and contribute to the group.", "Decline and study alone.", "Join but don't contribute." },
                    new Action<Player>[]
                    {
                        p => p.AcademicScore += 5,
                        p => p.AcademicScore += 3,
                        p => { p.SocialScore += 2; p.AcademicScore += 2; }
                    }
                ),
                new Question(
                    "You have free time between classes. How do you spend your time?",
                    new string[] { "Explore the campus and meet new people.", "Go to the library and read.", "Take a nap in a quiet corner." },
                    new Action<Player>[]
                    {
                        p => p.SocialScore += 5,
                        p => p.AcademicScore += 5,
                        p => p.SocialScore += 2
                    }
                ),
                new Question(
                    "During a group project, you are assigned a task you don't like. How do you react?",
                    new string[] { "Do the task anyway, trying your best.", "Tell them you don't feel comfortable and ask to do something else.", "Finish the task on your own, hoping someone will help." },
                    new Action<Player>[]
                    {
                        p => p.AcademicScore += 4,
                        p => p.SocialScore += 3,
                        p => { p.AcademicScore += 2; p.SocialScore += 2; }
                    }
                ),
                new Question(
                    "A professor offers extra credit for attending a seminar. What would you do?",
                    new string[] { "Attend the seminar to boost your grades.", "Decline, prefer to rest.", "Attend to see if it's interesting." },
                    new Action<Player>[]
                    {
                        p => p.AcademicScore += 5,
                        p => p.AcademicScore += 1,
                        p => p.AcademicScore += 3
                    }
                ),

                new Question(
                    "A friend invites you to a weekend trip. What would you do?",
                    new string[] { "Go on, it's a great chance to bond.", "Politely decline, you need to study.", "Think about it, but say you'll decide later." },
                    new Action<Player>[]
                    {
                        p => p.SocialScore += 5,
                        p => p.AcademicScore += 3,
                        p => p.SocialScore += 2
                    }
                )
            };
        }

        private void DisplayEnding()
        {
            Console.WriteLine("\nBased on your choices:");
            if (player.SocialScore > player.AcademicScore)
            {
                Console.WriteLine($"You, {player.Name}, had a fantastic first day! You met so many people and had a great time!");
            }
            else if (player.AcademicScore > player.SocialScore)
            {
                Console.WriteLine($"You, {player.Name}, have done an amazing job of focusing on your studies and building a fantastic foundation for your future!");
            }
            else
            {
                Console.WriteLine($"You, {player.Name}, absolutely nailed it! You managed to balance your academics and social life perfectly!");
            }
        }
    }
}
