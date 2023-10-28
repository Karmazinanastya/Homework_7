using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Dictionary<string, string> PhoneBook = new Dictionary<string, string>();

        
        using (StreamReader reader = new StreamReader("D:\\Курси\\Homework_7\\phones.txt"))
        {
            string line;
            int count = 0;
            while ((line = reader.ReadLine()) != null && count < 9)
            {
                string[] parts = line.Split(' '); 
                if (parts.Length == 2)
                {
                    PhoneBook[parts[0]] = parts[1];
                    count++;
                }
            }
        }

        using (StreamWriter phoneWriter = new StreamWriter("D:\\Курси\\Homework_7\\Phones_1.txt"))
        {
            foreach (var entry in PhoneBook)
            {
                phoneWriter.WriteLine(entry.Value);
            }
        }

        Console.Write("Введіть ім'я для пошуку номера телефону: ");
        string searchName = Console.ReadLine();
        if (PhoneBook.ContainsKey(searchName))
        {
            Console.WriteLine($"Номер телефону для {searchName}: {PhoneBook[searchName]}");
        }
        else
        {
            Console.WriteLine("Такого імені в телефонній книзі не знайдено.");
        }

        using (StreamWriter newPhone = new StreamWriter("D:\\Курси\\Homework_7\\New.txt"))
        {
            foreach (var entry in PhoneBook)
            {
                string name = entry.Key;
                string phoneNumber = entry.Value;

                if (phoneNumber.StartsWith("80"))
                {
                    phoneNumber = "+380" + phoneNumber.Substring(2);
                }

                newPhone.WriteLine($"{name}: {phoneNumber}");
            }

        }
    }
}
