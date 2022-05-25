using System;

namespace Quest
{
    public class Prize
    {
        private string _text;

        public Prize(string text)
        {
            _text = text;
        }

        public void ShowPrize(Adventurer adObj)
        {
            if (adObj.Awesomeness > 0)
            {
                for (int i = 0; i < adObj.Awesomeness; i++)
                {
                    Console.WriteLine($"{_text}");
                }
            }
            else
            {
                Console.WriteLine("Such a pity!");
            }
        }
    }
}