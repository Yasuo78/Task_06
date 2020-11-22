using System;

namespace RAP_Task_06
{
    class Program
    {
        static void Add(ref string[] Name, ref string[] Status)
        {
            string[] boof;
            string s;
            int count;

        ErorName:
            Console.Write("Введите ФИО: ");
            s = Console.ReadLine();

            count = Name.Length;
            boof = new string[count];

            if ((s != "") && (s != "-"))
            {
                count++;
                boof = Name;
                Name = new string[count];

                for (int i = 0; i < count - 1; i++)
                    Name[i] = boof[i];

                Name[count - 1] = s;
            }
            else if (s == "")
            {
                Console.WriteLine("Введите имя!");
                goto ErorName;
            }

        ErorStatus:
            Console.Write("Введите Должность: ");
            s = Console.ReadLine();

            if (s != "")
            {
                boof = Status;
                Status = new string[count];

                for (int i = 0; i < count - 1; i++)
                    Status[i] = boof[i];

                Status[count - 1] = s;

            }
            else if (s == "")
            {
                Console.WriteLine("Введите должность!");
                goto ErorStatus;
            }
        }

        static void Find(string[] Name, string[] Status)
        {
            string F;
            bool Fin;
            Out(Name, Status);

            Console.Write("Введите ФИО: ");
            F = Console.ReadLine();

            Console.Clear();
            for (int i = 0; i < Name.Length; i++)
            {
                Fin = Name[i].Contains(F, StringComparison.CurrentCultureIgnoreCase);
                if (Fin == true)
                {
                    Console.WriteLine($"{i + 1}.\t{Name[i]}-{Status[i]}");
                }
            }
            Console.ReadKey();
        }

        static void Out(string[] Name, string[] Status)
        {
            for (int i = 0; i < Name.Length; i++)
            {
                Console.WriteLine($"{i + 1}.\t{Name[i]}-{Status[i]}");
            }
            Console.ReadKey();
        }

        static void Delete(ref string[] Name, ref string[] Status)
        {
            int DelNum;
            string[] DelBoofN, DelBoofP;

        delete:
            Console.Write("Введите номер досье: ");
            DelNum = Convert.ToInt32(Console.ReadLine());

            if (DelNum <= 0)
            {
                return;
            }
            else if (DelNum > Name.Length)
            {
                Console.WriteLine("Досье с таким номером не существует!");
                Console.ReadKey();
                Console.Clear();
                goto delete;
            }

            DelNum--;
            DelBoofN = Name;
            DelBoofP = Status;

            if (DelNum != Name.Length)
            {
                for (int i = DelNum--; i < Name.Length - 1; i++)
                {
                    DelBoofN[i] = DelBoofN[i + 1];
                    DelBoofP[i] = DelBoofP[i + 1];
                }
                Name = new string[DelBoofN.Length - 1];
                Status = new string[DelBoofP.Length - 1];

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i] = DelBoofN[i];
                    Status[i] = DelBoofP[i];
                }
            }
            else
            {
                Name = new string[DelBoofN.Length - 1];
                Status = new string[DelBoofP.Length - 1];

                for (int i = 0; i < Name.Length; i++)
                {
                    Name[i] = DelBoofN[i];
                    Status[i] = DelBoofP[i];
                }
            }

            Console.WriteLine("Удаление успешно завершенно!");
            Console.ReadKey();

        }

        static void Menu(ref string[] Name, ref string[] Status)
        {
            string comand;

            do
            {
                Console.Clear();
                Console.WriteLine("Меню:");
                Console.WriteLine("'Добавить' - Добавить досье.");
                Console.WriteLine("'Вывести' - Вывести все досье.");
                Console.WriteLine("'Удалить' - Удалить досье.");
                Console.WriteLine("'Поиск' - Поиск по фамилии.");
                Console.WriteLine("'Выход' - Выход.");

                comand = Console.ReadLine();

                if (comand == "Добавить")
                {
                    Console.Clear();
                    Add(ref Name, ref Status);

                }
                else if (comand == "Вывести")
                {
                    Console.Clear();
                    Out(Name, Status);

                }
                else if (comand == "Поиск")
                {
                    Console.Clear();
                    Find(Name, Status);
                }
                else if (comand == "Удалить")
                {
                    Console.Clear();
                    Delete(ref Name, ref Status);
                }
            } while (comand != "Выход");
        }


        static void Main(string[] args)
        {
            string[] Name = new string[0];
            string[] Status = new string[0];

            Menu(ref Name, ref Status);
        }
    }
}