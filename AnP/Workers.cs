﻿using System;
using System.Linq;
class HelloWorld {
    static void Main() {
        bool Menu = true;
        Worker Data = new Worker();
        do { 
            Console.WriteLine("Выборка работников\n\n" +
                "1. Ввод данных\n" +
                "2. По заданному образованию\n" +
                "3. С единственной работой \n" +
                "4. По заданному возрасту\n" +
                "5. Выход\n");

            
            int number = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (number) {

                case 1:     //Заполнение
                    Console.WriteLine("ФИО: ");
                    Data.fullname.Add(Console.ReadLine());

                    Console.WriteLine("Дата рождения: ");
                    Data.birthday.Add(Console.ReadLine());

                    Console.WriteLine("Образование: ");
                    Console.WriteLine("1. Высшее (бакалавриат)\n" +
                        "2. Неоконченное высшее \n" +
                        "3. Среднее профессиональное\n" +
                        "4. Высшее (специалитет,магистратура)");
                    Data.education.Add(int.Parse(Console.ReadLine()));

                    Console.WriteLine("Количество работ:");
                    int nj = int.Parse(Console.ReadLine());
                    Data.numberw.Add(nj);
                    string res = "Работа: ";
                    for (int i = 1; i <= nj; i++) {
                        Console.WriteLine($" Работа №{i} ");

                        Console.WriteLine("Год устройства: ");
                        string app_yj = Console.ReadLine();
                        Console.WriteLine("Место: ");
                        string pw = Console.ReadLine();
                        Console.WriteLine("Год увольнения: ");
                        string dism = Console.ReadLine();
                        res += $" №{i}: {pw} {app_yj}-{dism};";

                    }
                    Data.workplace.Add(res);
                    Console.WriteLine("Работник записан.\n");
                    Console.WriteLine("1. Записать другого работника\n"
                        + "2. В меню");
                    int A = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    if (A == 1) goto case 1;
                    break;

                case 2:     //По образованию
                    Console.WriteLine("Выбор по образованию: ");
                    Console.WriteLine("1. Высшее (бакалавриат)\n" +
                        "2. Неоконченное высшее \n" +
                        "3. Среднее профессиональное\n" +
                        "4. Высшее (специалитет,магистратура)");

                    Data.Education(int.Parse(Console.ReadLine()));
                    Console.WriteLine("1. Найти работников с другим образованием\n"
                        + "2. В меню");
                    int B = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    if (B == 1) goto case 2;
                    break;

                case 3:     //С одной работой
                    Data.OneJob();
                    Console.WriteLine("Для продолжения нажмите любую клавишу . . .");
                    Console.ReadKey();
                    break;

                case 4:     //По возрасту
                    Console.WriteLine("Введите год рождения:");
                    Data.Age(Console.ReadLine());
                    Console.WriteLine("1. Найти работников другого года рождения\n"
                        + "2. В меню");
                    int C = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    if (C == 1) goto case 4;
                    break;

                case 5:     //Выход
                    Menu = false;
                break;

            } Console.Clear();
        } while (Menu);
    }    
}
class Worker {
    public List<string> fullname = new List<string>();
    public List<string> birthday = new List<string>();
    public List<int> education = new List<int>();
    public List<int> numberw = new List<int>();
    public List<string> workplace = new List<string>();

    public void Education(int Inp) { 
        int i = 0, ans = 0;
        foreach(int e in education) {
            if (e == Inp) {
                Console.WriteLine(fullname[i]);
                ans++;
            }
            i++;
        }
        if (ans == 0) Console.WriteLine("Работников с данным образованием нет.");
    }
    public void OneJob() { 
        int i = 0, ans = 0;
        Console.WriteLine("Работники с одной записью работы:");
        foreach(int e in numberw) {
            if (e == 1) {
                Console.WriteLine(fullname[i]);
                ans++;
            }
            i++;
        }
        if (ans == 0) Console.WriteLine("Работников с одной записью работы нет.");
    }
    public void Age(string Inp) {
        int i = 0, ans = 0;
        foreach(string e in birthday) {
            if (e.IndexOf(Inp) != -1) {
                Console.WriteLine(fullname[i]);
                ans++;
            }
            i++;
        }
        if (ans == 0) Console.WriteLine("Работников с данным годом рождения нет.");
    
    }
}