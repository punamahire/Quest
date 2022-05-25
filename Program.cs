using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
                    1) John
                    2) Paul
                    3) George
                    4) Ringo
                ",
                4, 20
            );

            Challenge numOfHours = new Challenge("How many number of hours are there in a day?",24, 10);
            Challenge starsInGreatBear = new Challenge("How many stars are there is a Great Bear?", 7, 20);
            Challenge statesInUs = new Challenge("How many states are there in U.S?", 50, 10);
            
            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            List<string> colors = new List<string>
            {
                "red",
                "yellow",
                "blue"
            };

            Robe robeObj = new Robe
            {
                Colors = colors,
                Length = 50
            };

            Hat hatObj = new Hat
            {
                ShininessLevel = 4
            };

            Prize prizeObj = new Prize("Trophy");
            // Make a new "Adventurer" object using the "Adventurer" class
            Console.Write("Please enter your name: ");
            string adventurerName = Console.ReadLine();
            Adventurer theAdventurer = new Adventurer(adventurerName, robeObj, hatObj); 

            Console.WriteLine(theAdventurer.GetDescription());

             // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                numOfHours,
                starsInGreatBear,
                statesInUs
            };

            static int GetRandomChallenge()
            {
                List<int> numbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };
 
                Random rnd = new Random();
                int randIndex = rnd.Next(numbers.Count);
                int random = numbers[randIndex];

                return random;
            }

            // Loop through all the challenges and subject the Adventurer to them
            // foreach (Challenge challenge in challenges)
            // {
            //     challenge.RunChallenge(theAdventurer);
            // }

            for (int i = 0; i < 5; i++)
            {
                int randomIndex = GetRandomChallenge();
                challenges[randomIndex].RunChallenge(theAdventurer);
            }

            // This code examines how Awesome the Adventurer is after completing the challenges
            // And praises or humiliates them accordingly
            if (theAdventurer.Awesomeness >= maxAwesomeness)
            {
                Console.WriteLine("YOU DID IT! You are truly awesome!");
            }
            else if (theAdventurer.Awesomeness <= minAwesomeness)
            {
                Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
            }
            else
            {
                Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
            }

            prizeObj.ShowPrize(theAdventurer);
            Console.WriteLine($"Successful attempts: {Challenge.successfulAttempt}");

            Console.WriteLine("Would you like to play again? yes/no ");
            string answer = Console.ReadLine();

            while (answer.ToUpper() == "YES")
            {
                // foreach(Challenge challenge in challenges)
                // {
                //     challenge.RunChallenge(theAdventurer);
                // }
                //phase 8
                Challenge.successfulAttempt = Challenge.successfulAttempt * 10;
                theAdventurer.Awesomeness += Challenge.successfulAttempt;

                for (int i = 0; i < 5; i++)
                {
                    int randomIndex = GetRandomChallenge();
                    challenges[randomIndex].RunChallenge(theAdventurer);
                }

                Console.WriteLine("Would you like to play again? yes/no ");
                answer = Console.ReadLine();
            }
        }
    }
}
