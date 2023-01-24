using static System.Console;

namespace H1GPDag6
{
    public class Character
    {
        public string Name { get; set; }
        CharacterClasses CharacterClass { get; set; }
        public int Level { get; set; }
        public DateTime Birthday { get; set; }
        public CharacterStats Stats { get; set; }

        public Character(string name, int classChoice)
        {
            Name = name;
            if (Enum.IsDefined(typeof(CharacterClasses), classChoice))
                CharacterClass = (CharacterClasses)classChoice;
            Level = 1;
            Birthday = GetRandomBirthdayValue();
            Stats = new CharacterStats();
        }

        public void ShowCharacter()
        {
            Clear();

            WriteLine($"*** Our fierce character {Name} ***" + Environment.NewLine);
            WriteLine($"Class: { CharacterClass }");
            WriteLine($"Level: { Level }");
            WriteLine($"Birthday: { Birthday.ToString("dd. MMMM yyyy") }");
            WriteLine($"Stats:");
            WriteLine($"    Strength: { Stats.Strength }");
            WriteLine($"    Dexterity: { Stats.Dexterity }");
            WriteLine($"    Constitution: { Stats.Constitution }");
            WriteLine($"    Intelligence: { Stats.Intelligence }");
            WriteLine($"    Wisdom: { Stats.Wisdom }");
            WriteLine($"    Charisma: { Stats.Charisma }");
            WriteLine(Environment.NewLine + "****************************");
        }
        
        public void CalculateAge(DateTime currentDate)
        {
            Clear();

            WriteLine($"Vores helt er {currentDate.Year - Birthday.Year} år gammel");
        }

        static DateTime GetRandomBirthdayValue()
        {
            Random random = new Random();

            DateTime start = new DateTime(1010 , 1, 1);
            DateTime end = new DateTime(1219, 6, 15);

            int range = (end - start).Days;
            int days = random.Next(range);

            DateTime randomBirthday = start.AddDays(days);

            return randomBirthday;
        }
    }
}
