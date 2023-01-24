using static System.Console;

namespace H1GPDag6
{
    public class CharacterStats
    {
        private Random random = new Random();

        public int Strength     { get; set; }
        public int Dexterity    { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom       { get; set; }
        public int Charisma     { get; set; }

        public CharacterStats()
        {
            Strength     = random.Next(3, 19);
            Dexterity    = random.Next(3, 19);
            Constitution = random.Next(3, 19);
            Intelligence = random.Next(3, 19);
            Wisdom       = random.Next(3, 19);
            Charisma     = random.Next(3, 19);
        }

        public CharacterStats RerollStats()
        {
            CharacterStats charStats = new CharacterStats();

            charStats.Strength     = random.Next(3, 19);
            charStats.Dexterity    = random.Next(3, 19);
            charStats.Constitution = random.Next(3, 19);
            charStats.Intelligence = random.Next(3, 19);
            charStats.Wisdom       = random.Next(3, 19);
            charStats.Charisma     = random.Next(3, 19);
        
            return charStats;
        }
    }
}
