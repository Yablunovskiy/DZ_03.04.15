using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace NFS_Yabl
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Title = "Garage.";
            var A = new Car[4];
            bool Kl = true;
            DirectoryInfo dir = new DirectoryInfo(".");
            dir.CreateSubdirectory("MyCar");
            DirectoryInfo myCarFolder = dir.CreateSubdirectory(@"MyCar");
            while (Kl)
            {
                Menu(ref A, myCarFolder, ref Kl);
            }
            

        }

        static void Menu(ref Car[] A, DirectoryInfo myCarFolder, ref bool Kl)
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("\t\tДобро пожаловать в гараж.");
            Console.Write("\n\n\tВведите Выш ключ от гаража (имя или пароль, 0 - выход)->");
            string Key = Convert.ToString(Console.ReadLine());
            if (Key.Equals("0"))
            {
                Console.WriteLine("\n\n");
                Kl = false;
            }
            else
            {
                string adress = "Garage" + @"\" + Key + ".bin";
                if (File.Exists(adress))
                {
                    Menu1(ref A, adress, Key);
                }
                else
                {
                    Menu11(ref A, adress, myCarFolder);
                }

                Menu2(ref A);
                SaveInFile(adress, A);

            }
        }

        static void Menu1(ref Car[] A, string adress, string Key)
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("\t\tПривет хозяин с ключом " + Key + " (KeyEnter)");
            Console.ReadKey();
            ReadInFile(adress, ref A);
            
        }

        static void Menu11(ref Car[] A, string adress, DirectoryInfo myCarFolder)
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("\t\tВы новичек Добро пожаловать в гараж.(KeyEnter)");
            Console.ReadKey();
            SetCar(myCarFolder, ref A);
            FileInfo f = new FileInfo(adress);
            FileStream fs = f.Create();
            fs.Close();
            SaveInFile(adress, A);
        }

        static void Menu2(ref Car[] A)
        {
            
            bool next = true;
            int I = 0;
            Action<Car , ConsoleColor, ConsoleColor> action = DispayMessage;
            Console.Clear();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("\t\tВот список Ваших авто.");
            for (int i = 0; i < A.Length; i++)
            {
                if (i == I)
                    action(A[i], ConsoleColor.Yellow, ConsoleColor.Blue);
                else
                {
                    if (CompareAll(A[i]))
                        action(A[i], ConsoleColor.DarkBlue, ConsoleColor.White);
                    else
                        action(A[i], ConsoleColor.DarkBlue, ConsoleColor.Magenta);
                }
            }
            Console.WriteLine("\t\t   Закрыть гараж. Esc.");
            while (next)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    --I;
                    if (I < 0) I = A.Length - 1;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    ++I;
                    if (I > A.Length - 1) I = 0;
                }

                Console.Clear();
                Console.WriteLine("\n\n\n");
                Console.WriteLine("\t\tВот список Ваших авто.");
                for (int i = 0; i < A.Length; i++)
                {
                    if (i == I)
                    {
                        action(A[i], ConsoleColor.Yellow, ConsoleColor.Blue);
                    }
                    else
                    {
                        if (CompareAll(A[i]))
                            action(A[i], ConsoleColor.DarkBlue, ConsoleColor.White);
                        else
                            action(A[i], ConsoleColor.DarkBlue, ConsoleColor.Magenta);
                    }
                }
                Console.WriteLine("\t\t     Выход Esc.");
                if (key.Key == ConsoleKey.Enter)
                {
                    Menu3(ref A[I]);
                }
                if (key.Key == ConsoleKey.Escape)
                    next = false;
                Console.Clear();
                Console.WriteLine("\n\n\n");
                Console.WriteLine("\t\tВот список Ваших авто.");
                for (int i = 0; i < A.Length; i++)
                {
                    if (i == I)
                        action(A[i], ConsoleColor.Yellow, ConsoleColor.Blue);
                    else
                    {
                        if (CompareAll(A[i]))
                            action(A[i], ConsoleColor.DarkBlue, ConsoleColor.White);
                        else
                            action(A[i], ConsoleColor.DarkBlue, ConsoleColor.Magenta);
                    }
                }
                Console.WriteLine("\t\t   Закрыть гараж. Esc.");
            }
        }

        static void Menu3(ref Car A)
        {
            bool next = true;
            var mass = new string[] { " " + A.MaxSpeed.ToString() + @"км/ч ", " 100м за " + A.Speed_Up.ToString() + "с ", " " + A.Nitro.ToString() + "секунд ", " " + A.TypeOfBrakes + " ", " " + A.Transmission + " " };
            var com = new string[] { A.MaxSpeed.ToString(), A.Speed_Up.ToString(), A.Nitro.ToString(), A.TypeOfBrakes, A.Transmission };
            int I = 0;
            Action<string, ConsoleColor, ConsoleColor> action = DispayMessage1;
            Console.Clear();
            
            Console.WriteLine("\n\n\n");
            Console.WriteLine("\t\tХарактеристики модели '" + A.Model + "'.");
            for (int i = 0; i < mass.Length; i++)
            {
                if (i == I)
                    action(mass[i], ConsoleColor.Yellow, ConsoleColor.Blue);
                else
                {
                    if (Compare(com[i]))
                        action(mass[i], ConsoleColor.DarkBlue, ConsoleColor.White);
                    else
                        action(mass[i], ConsoleColor.DarkBlue, ConsoleColor.Magenta);
                }
            }
            Console.WriteLine("\t\t     Выход Esc.");
            while (next)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    --I;
                    if (I < 0) I = mass.Length - 1;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    ++I;
                    if (I > mass.Length - 1) I = 0;
                }

                Console.Clear();
                Console.WriteLine("\n\n\n");
                Console.WriteLine("\t\tХарактеристики модели '" + A.Model + "'.");
                for (int i = 0; i < mass.Length; i++)
                {
                    if (i == I)
                        action(mass[i], ConsoleColor.Yellow, ConsoleColor.Blue);
                    else
                    {
                        if (Compare(com[i]))
                            action(mass[i], ConsoleColor.DarkBlue, ConsoleColor.White);
                        else
                            action(mass[i], ConsoleColor.DarkBlue, ConsoleColor.Magenta);
                    }
                }
                Console.WriteLine("\t\t     Выход Esc.");

                if (key.Key == ConsoleKey.Enter)
                {
                    switch (I)
                    {
                        case 0:
                            A.MaxSpeed = Convert.ToInt32(Upgrade(A.MaxSpeed.ToString(), @"Upgrade\MaxSpeed.txt", " Максимальная скорасть "));
                            break;
                        case 1:
                            A.Speed_Up = Convert.ToDouble(Upgrade(A.Speed_Up.ToString(), @"Upgrade\Speed_Up.txt", " Ускорение "));
                            break;
                        case 2:
                            A.Nitro = Convert.ToDouble(Upgrade(A.Nitro.ToString(), @"Upgrade\Nitro.txt", " Время работы нитро "));
                            break;
                        case 3:
                            A.TypeOfBrakes = Upgrade(A.TypeOfBrakes, @"Upgrade\TypeOfBrakes.txt", " Тип тормозов ");
                            break;
                        case 4:
                            A.Transmission = Upgrade(A.Transmission, @"Upgrade\Transmission.txt", " Тип сцепления ");
                            break;
                        case 5:
                            next = false;
                            break;
                    }
                }
                if (key.Key == ConsoleKey.Escape)
                    next = false;
                mass = new string[] { " " + A.MaxSpeed.ToString() + @"км/ч ", " 100м за " + A.Speed_Up.ToString() + " с ", " " + A.Nitro.ToString() + " секунд ", " " + A.TypeOfBrakes + " ", " " + A.Transmission + " " };
                com = new string[] { A.MaxSpeed.ToString(), A.Speed_Up.ToString(), A.Nitro.ToString(), A.TypeOfBrakes, A.Transmission };
                Console.Clear();
                Console.WriteLine("\n\n\n");
                Console.WriteLine("\t\tХарактеристики модели '" + A.Model + "'.");
                for (int i = 0; i < mass.Length; i++)
                {
                    if (i == I)
                        action(mass[i], ConsoleColor.Yellow, ConsoleColor.Blue);
                    else
                    {
                        if (Compare(com[i]))
                            action(mass[i], ConsoleColor.DarkBlue, ConsoleColor.White);
                        else
                            action(mass[i], ConsoleColor.DarkBlue, ConsoleColor.Magenta);
                    }
                }
                Console.WriteLine("\t\t     Выход Esc.");
            }
        }

        static string Upgrade(string N, string s, string M)
        {
            bool next = true;
            var mass = new string[5];
            Enter(ref mass, s);
            int I = 0;
            Action<string, ConsoleColor, ConsoleColor> action = DispayMessage1;
            Console.Clear();

            Console.WriteLine("\n\n\n");
            Console.WriteLine("\t\tВаша '" + M + "'"+ N );
            for (int i = 0; i < mass.Length; i++)
            {
                if (i == I)
                    action(mass[i], ConsoleColor.Yellow, ConsoleColor.Blue);
                else
                    action(mass[i], ConsoleColor.DarkBlue, ConsoleColor.White);
            }
            Console.WriteLine("\t\t     Выход Esc.");
            while (next)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    --I;
                    if (I < 0) I = mass.Length - 1;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    ++I;
                    if (I > mass.Length - 1) I = 0;
                }

                Console.Clear();
                Console.WriteLine("\n\n\n");
                Console.WriteLine("\t\tВаша '" + M + "'" + N);
                for (int i = 0; i < mass.Length; i++)
                {
                    if (i == I)
                        action(mass[i], ConsoleColor.Yellow, ConsoleColor.Blue);
                    else
                        action(mass[i], ConsoleColor.DarkBlue, ConsoleColor.White);
                }
                Console.WriteLine("\t\t     Выход Esc.");

                if (key.Key == ConsoleKey.Enter)
                {
                    return mass[I].ToString();
                }
                if (key.Key == ConsoleKey.Escape)
                    next = false;
            }
            return N;
        }

        static void DispayMessage(Car A, ConsoleColor color, ConsoleColor Bcolor)
        {
            ConsoleColor prev = Console.ForegroundColor;
            ConsoleColor Bprev = Console.BackgroundColor;
            Console.WriteLine();
            Console.Write("\t\t\t");
            Console.ForegroundColor = color;
            Console.BackgroundColor = Bcolor;
            Console.WriteLine(A.Model);
            Console.ForegroundColor = prev;
            Console.BackgroundColor = Bprev;
            Console.WriteLine();
        }

        static void DispayMessage1(string msg, ConsoleColor color, ConsoleColor Bcolor)
        {
            ConsoleColor prev = Console.ForegroundColor;
            ConsoleColor Bprev = Console.BackgroundColor;
            Console.WriteLine();
            Console.Write("\t\t\t");
            Console.ForegroundColor = color;
            Console.BackgroundColor = Bcolor;
            Console.WriteLine(msg);
            Console.ForegroundColor = prev;
            Console.BackgroundColor = Bprev;
            Console.WriteLine();
        }

        static void Enter(ref string[] A, string fl)
        {
            using (StreamReader sr = File.OpenText(fl))
            {
                for (int i = 0; i < A.Length; i++)
                {
                    A[i] = sr.ReadLine().ToString();
                }
            }
        }
        
        static bool CompareAll(Car A)
        {
            Car B = new Car("", 200, 11.0, 0, "usual", "usual");
            if (A == B)
                return true;
            else
                return false;
        }

        static bool Compare(string r)
        {
            if ( r.Equals("200") || r.Equals("11") || r.Equals("0") || r.Equals("usual"))
                return true;
            else
                return false;
        }

        static void SaveInFile(string adress, Car[] A)
        {
            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(adress)))
            {
                for (int i = 0; i < A.Length; i++)
                {
                    writer.Write(A[i].Model);
                    writer.Write(A[i].MaxSpeed);
                    writer.Write(A[i].Speed_Up);
                    writer.Write(A[i].Nitro);
                    writer.Write(A[i].TypeOfBrakes);
                    writer.Write(A[i].Transmission);
                }
            }
        }

        static void ReadInFile(string adress, ref Car[] A)
        {
            using (BinaryReader br = new BinaryReader(File.OpenRead(adress)))
            {
                for (int i = 0; i < A.Length; i++)
                {
                    A[i] = new Car();
                    A[i].Model = br.ReadString();
                    A[i].MaxSpeed = br.ReadInt32();
                    A[i].Speed_Up = br.ReadDouble();
                    A[i].Nitro = br.ReadDouble();
                    A[i].TypeOfBrakes = br.ReadString();
                    A[i].Transmission = br.ReadString();
                }
            }
        }

        static void SetCar(DirectoryInfo myCarFolder, ref Car[] A)
        {
            int i = 0;
            foreach (string s in File.ReadAllLines(myCarFolder + @"\Car.txt"))
            {
                A[i] = new Car(s, 200, 11.0, 0, "usual", "usual");
                i++;
            }
        }

        static void PrintCar(Car[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                Console.WriteLine(A[i]);
            }
        }
    }
}
