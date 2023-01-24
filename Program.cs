using static System.Console;
using System.Threading;
using System.Runtime.Intrinsics.X86;
using System.Linq;

namespace H1GPDag6
{
    class Program
    {
        static List<Character> characters = new List<Character>();

        static void Main(string[] args)
        {
            Character klaus = new Character("Klaus", 2);
            characters.Add(klaus);

            MainMenu();

            ReadKey();
        }

        static void MainMenu()
        {
            Clear();

            WriteLine("Velkommen til TECs RPG karaktergenerator!" + Environment.NewLine);
            WriteLine("1. Ny karakter");
            WriteLine("2. Se karaterer");
            WriteLine("3. Afslut" + Environment.NewLine);


            int menuChoice;
            do
            {
                Write("Vælg en mulighed fra menuen: ");
            } while (!Int32.TryParse(ReadLine(), out menuChoice) || menuChoice < 1 || menuChoice > 3);

            switch (menuChoice)
            {
                case 1:
                    Clear();
                    NewCharacter();
                    break;
                case 2:
                    Clear();
                    ViewAllCharacters();
                    break;
                case 3:
                    Quit();
                    break;
            }
        }

        private static void ViewAllCharacters()
        {
            WriteLine("Her er alle oprettede karakterer!" + Environment.NewLine);
            int charIndex = 1;
            foreach (Character character in characters)
            {
                WriteLine($"{charIndex}. {character.Name}" );
                charIndex++;
            }
            WriteLine($"{characters.Count + 1}. Tilbage til hovedmenu");

            WriteLine();

            int menuChoice;
            do
            {
                Write("Vælg en mulighed fra menuen: ");
            } while (!Int32.TryParse(ReadLine(), out menuChoice) || menuChoice < 1 || menuChoice > charIndex + 1);

            if (menuChoice == characters.Count + 1)
                MainMenu();
            else
            {
                characters[menuChoice - 1].ShowCharacter();

                WriteLine(Environment.NewLine + "Tryk en tast for at vende tilbage til hovedmenuen");
                ReadKey();
                MainMenu();
            }
        }

        static void NewCharacter()
        {
            WriteLine("*** Ny karakter ***" + Environment.NewLine);

            string newName;
            do
            {
                Write("Indtast navn (mindst tre bogstaver): ");
                newName = ReadLine();
            } while (string.IsNullOrEmpty(newName) || newName.Length < 3);
            
            Clear();

            int classIndex = 1;
            foreach (CharacterClasses cc in Enum.GetValues(typeof(CharacterClasses)))
            {
                WriteLine($"{classIndex}. {cc}");
                classIndex++;
            }
            WriteLine();

            int classChoice;
            do
            {
                Write("Vælg en klasse fra menuen: ");
            } while (!Int32.TryParse(ReadLine(), out classChoice) || classChoice < 1 || classChoice > classIndex /* + 1 */);

            Clear();
            Character newChar = new Character(newName, classChoice);

            NewCharacterMenu(newChar);
        }

        static void NewCharacterMenu(Character newChar)
        {
            newChar.ShowCharacter();

            WriteLine(Environment.NewLine + "1. Reroll stats");
            WriteLine("2. Accepter og vend tilbage til hovedmenuen");
            WriteLine("3. Afslut og vend tilbage til hovedmenuen uden at gemme" + Environment.NewLine);

            int menuChoice;
            do
            {
                Write("Indtast valgmulighed fra menuen: ");

            } while (!Int32.TryParse(ReadLine(), out menuChoice) || menuChoice < 1 || menuChoice > 3);

            switch (menuChoice)
            {
                case 1:
                    CharacterStats newStats = new CharacterStats();
                    newChar.Stats = newStats.RerollStats();
                    NewCharacterMenu(newChar);
                    break;
                case 2:
                    Clear();
                    characters.Add(newChar);
                    WriteLine("Din karakter er oprettet! Tryk en tast for at vende tilbage til hovedmenuen");
                    ReadKey();
                    MainMenu();
                    break;
                case 3:
                    MainMenu();
                    break;
            }
        }

        private static void Quit()
        {
            Clear();
            WriteLine("Tak for at have besøgt TEC RPG karaktergenerator!");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
    }
}