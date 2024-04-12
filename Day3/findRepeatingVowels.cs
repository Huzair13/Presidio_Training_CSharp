namespace UnderstandingBasicsApp.Models
{
    class RepeatingVowel
    {
        public void findRepeatVowels()
        {
            Console.WriteLine("Enter a string with words separated by commas:");
            string input = Console.ReadLine();

            string[] words = input.Split(',');

            Dictionary<string, int> wordVowelCounts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                int vowelCount = CountRepeatingVowels(word);
                if (!wordVowelCounts.ContainsKey(word))
                {
                    wordVowelCounts.Add(word, vowelCount);
                }
            }

            int minVowelCount = wordVowelCounts.Min(kv => kv.Value);

            var wordsWithMinVowelCount = wordVowelCounts.Where(kv => kv.Value == minVowelCount).Select(kv => kv.Key);

            Console.WriteLine($"Words with the least repeating vowels ({minVowelCount}):");
            foreach (string word in wordsWithMinVowelCount)
            {
                Console.WriteLine(word);
            }
        }

        static int CountRepeatingVowels(string word)
        {
            HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
            int count = 0;
            char prevChar = '\0';
            int repeatingCount = 0;

            foreach (char c in word.ToLower())
            {
                if (vowels.Contains(c))
                {
                    if (c == prevChar)
                    {
                        repeatingCount++;
                    }
                    else
                    {
                        repeatingCount = 1;
                    }

                    if (repeatingCount > count)
                    {
                        count = repeatingCount;
                    }
                    prevChar = c;
                }
            }

            return count;
        }

    }

}

