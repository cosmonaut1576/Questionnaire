using System;
using System.Collections.Generic;

namespace Questionnaire
{
    public class Program
    {
        public static void Main()
        {
            var user = EnterAnketa();

            Console.WriteLine();

            ShowAnketa(user);
        }
        static (string name, string lastName, int age, bool hasAPet, int numOfPets, List<string> petNames, int numFavouriteColors, List<string> favouriteColors) EnterAnketa()
        {
            var Anketa = (Name: "", LastName: "", Age: 0, HasAPet: false, NumOfPets: 0, PetNames: new List<string>(), NumFavouriteColors: 0, FavouriteColors: new List<string>());
            //(string Name", string LastName, int age, bool HasAPet, int NumOfPets, string[] PetNames, int NumFavouriteColors, string[] FavouriteColors) Anketa;
            
            do
            {
                Console.Write("Введите имя: ");
                Anketa.Name = Console.ReadLine();
            } while (CheckString(Anketa.Name));

            do {
                Console.Write("Введите фамилию: ");
                Anketa.LastName = Console.ReadLine();
            } while (CheckString(Anketa.LastName));

            string age;
            int intage;
            do
            {
                Console.Write("Введите возраст (используя цифры 0-9): ");
                age = Console.ReadLine();
            } while (!CheckNum(age, out intage));

            Anketa.Age = intage;

            bool isCorrect = false;
            bool hasAPet = false;
            do
            {
                Console.Write(@"Есть ли у вас животные (""Да""/""Нет""): ");
                switch (Console.ReadLine())
                {
                    case "Да":
                        hasAPet = true;
                        isCorrect = true;
                        break;
                    case "Нет":
                        hasAPet = false;
                        isCorrect = true;
                        break;
                    default:
                        Console.WriteLine("Введено некорректное значение. Попробуйте ещё раз.");
                        break;
                }
            } while (!isCorrect);

            Anketa.HasAPet = hasAPet;

            if (Anketa.HasAPet)
            {
                string numOfPets;
                int intNumOfPets;
                do
                {
                    Console.Write("Какое количество животных у вас есть (используйте цифры 0-9): ");

                    numOfPets = Console.ReadLine();
                } while (!CheckNum(numOfPets, out intNumOfPets));

                Anketa.NumOfPets = intNumOfPets;

                Anketa.PetNames = CreateArrayPets(intNumOfPets);
            }

            string numFavouriteColors;
            int intNumFavouriteColors;
            do
            {
                Console.Write("Введите количество любимых цветов (используйте цифры 0-9): ");

                numFavouriteColors = Console.ReadLine();
            } while (!CheckNum(numFavouriteColors, out intNumFavouriteColors));

            Anketa.NumFavouriteColors = intNumFavouriteColors;

            Anketa.FavouriteColors = CreateArrayColors(intNumFavouriteColors);

            return Anketa;
        }

        static void ShowAnketa((string name, string lastName, int age, bool hasAPet, int numOfPets, List<string> petNames, int numFavouriteColors, List<string> favouriteColors) anketa)
        {
            Console.WriteLine("Имя: {1} {0}", anketa.name, anketa.lastName);
            Console.WriteLine("Возраст: {0}", anketa.age);
            if (anketa.hasAPet)
            {
                Console.Write("Животные[{0}]: ", anketa.numOfPets);
                for(int i = 0; i < anketa.petNames.Count; i++)
                {
                    Console.Write(anketa.petNames[i]);
                    if (i != anketa.petNames.Count-1)
                        Console.Write(", ");
                }
            }
            else
                Console.Write("Животные: отсутствуют. ");

            Console.WriteLine();

            Console.Write("Любимые цвета[{0}]: ", anketa.numFavouriteColors);
            for (int i = 0; i < anketa.favouriteColors.Count; i++)
            {
                Console.Write(anketa.favouriteColors[i]);
                if (i != anketa.favouriteColors.Count - 1)
                    Console.Write(", ");
            }
        }
        static bool CheckNum(string number, out int corrnumber)
            {
                if (int.TryParse(number, out int intnum))
                {
                    if (intnum > 0)
                    {
                        corrnumber = intnum;
                        return true;
                    }
                }
                corrnumber = 0;
                return false;
            }

        static bool CheckString(string str)
        {
            return String.IsNullOrEmpty(str);
        }

        static List<string> CreateArrayPets(int num)
        {
            var _petNames = new List<string>();
            string petName;
            for (int i = 0; i < num; i++)
            {
                do 
                {
                    Console.Write("Введите кличку {0}-го животного: ", i + 1);
                    petName = Console.ReadLine();
                } while (CheckString(petName));
                _petNames.Add(petName);
            }
            return _petNames;
        }
        static List<string> CreateArrayColors(int num)
        {
            var _favouriteColors = new List<string> ();
            string color;
            for (int i = 0; i < num; i++)
            {
                do 
                { 
                Console.Write("Введите любимый цвет №{0}: ", i+1);
                    color = Console.ReadLine();
                } while (CheckString(color));
                _favouriteColors.Add(color);
            }
            return _favouriteColors;
        }

    }
}
