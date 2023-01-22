using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;
using System.Xml.Linq;

namespace HW_3_2_Praktika
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 2, 6, 3, 100, -10, 22, 36, 893, 13, 104, 33, 1, 3, -10, 22, 22, 36, 13, 1, 2 };

            // 1 Write a LINQ query to find the numbers in a given array which are divisible by 2 and 3
            var numbersDivideBy2and3 = numbers.Where(n => n % 2 == 0 && n % 3 == 0);
            Console.Write("Numbers that are divisible by 2 and 3: ");
            foreach (var item in numbersDivideBy2and3)
            {
                Console.Write($"{item} ");
            }

            // 2 Write a LINQ query to find the sum of all the numbers in a given array
            var sumOfNumbers = (from n in numbers select n).Sum();
            Console.WriteLine($"\nSum of all numbers: {sumOfNumbers}");

            // 3 Write a LINQ query to find the average of all the numbers in a given array
            var averageOfNumbers = (from n in numbers select n).Average();
            Console.WriteLine($"Average of all numbers: {averageOfNumbers}");

            // 4 Write a LINQ query to find the maximum number in a given array
            var numberMax = (from n in numbers select n).Max();
            Console.WriteLine($"The maximum number: {numberMax}");

            // 5 Write a LINQ query to find the minimum number in a given array
            var numberMin = (from n in numbers select n).Min();
            Console.WriteLine($"The minimum number: {numberMin}");

            // 6 Write a LINQ query to find the numbers greater than 10 in a
            // given array and multiply each number by 10
            var numberGreater10Multiply10 = from n in numbers
                                            where n > 10
                                            select n * 10;

            Console.WriteLine("The numbers that are greater that 10 and multiplied by 10 ");
            foreach (var item in numberGreater10Multiply10)
            {
                Console.Write(item + " ");
            }

            string text = "Abilities forfeited situation extremely my to he resembled. " +
                "Old had conviction discretion understood put principles you.";

            // 7 Write a LINQ query to find the unique characters from a given string
            char[] chars = text.ToCharArray();

            var uniqueChars = chars.Distinct();
            Console.WriteLine("\nUnique characters: ");
            foreach (var item in uniqueChars)
            {
                Console.Write(item + " ");
            }

            // 8 Write a LINQ query to find the numbers and the frequency of each number in a given array
            var freqNumber = numbers.GroupBy(x => x);
            Console.WriteLine("\nThe frequency of each number: ");
            foreach (var g in freqNumber)
            {
                Console.WriteLine("{0} occurs {1} times", g.Key, g.Count());
            }

            // 9 Write a LINQ query to group the numbers in a given array into even
            // and odd groups and then find the maximum number in each group
            var evenOddgroup = numbers.GroupBy(n => n % 2 == 0);
            foreach (var group in evenOddgroup)
            {
                if (group.Key == true)
                {
                    Console.WriteLine("Even Elements: ");
                }
                else
                {
                    Console.WriteLine("Odd Elements: ");
                }

                foreach (var n in group)
                {
                    Console.Write(n + " ");
                }

                Console.WriteLine();
                Console.WriteLine($"Max number: {group.Max()}");
            }

            // 10 Find the elements of a list of integers that are greater than the average of the list
            var numbersGreaterAverage = from n in numbers
                                        where n > numbers.Average()
                                        select n;
            Console.Write($"Numbers that are greater than the average: ");
            foreach (var n in numbersGreaterAverage)
            {
                Console.Write(n + " ");
            }

            Console.WriteLine();

            string[] words = new string[] { "Abilities", "forfeited", "situation", "extremely", "my", "to", "he", "resembled", "Old", "had", "conviction", "discretion", "understood", "put", "principles", "you" };

            // 11 Group the elements of a list of strings by the length of the string
            var groupWordByLength = from word in words
                                    group word by word.Length;

            foreach (var group in groupWordByLength)
            {
                Console.WriteLine($"Group key: {group.Key}");

                foreach (var w in group)
                {
                    Console.WriteLine($"{w}");
                }

                Console.WriteLine("---------");
            }

            // 12 Find the elements of a list of strings that contain a given substring, group them by
            // the length of the string and project them into a new list with the strings in
            // a normalized format (first character upper-case every else lower-case)
            var findSubstring = from word in words
                                where word.Contains("it")
                                select word.Substring(0, 1).ToUpper() + word.Substring(1);
            Console.WriteLine("Words that contains substring 'it': ");
            foreach (var w in findSubstring)
            {
                Console.WriteLine(w);
            }

            // 13
            List<Users> usersList = new List<Users>()
            {
                new Users { FirstName = "Max", LastName = "Kolesnik", Email = "m.ivanov@gmail.com", DateOfBirth = new DateOnly(1992, 10, 21), UserId = 11 },
                new Users { FirstName = "Ann", LastName = "Dontsova", Email = "ann.dontsova@gmail.com", DateOfBirth = new DateOnly(2008, 12, 5), UserId = 12 },
                new Users { FirstName = "Alex", LastName = "Mukha", Email = "mukhaa@gool.com", DateOfBirth = new DateOnly(1997, 11, 6), UserId = 13 },
                new Users { FirstName = "Katya", LastName = "Polyakova", Email = "k.polyakova@ukr.ua", DateOfBirth = new DateOnly(1982, 7, 27), UserId = 14 },
                new Users { FirstName = "Petya", LastName = "Kravetz", Email = "p.ivanov@gool.com", DateOfBirth = new DateOnly(1990, 10, 20), UserId = 15 },
                new Users { FirstName = "Lilya", LastName = "Petrova", Email = "li.petrova@gool.com", DateOfBirth = new DateOnly(2013, 7, 2), UserId = 16 },
                new Users { FirstName = "Misha", LastName = "Kravetz", Email = "m.kravetz@ukr.ua", DateOfBirth = new DateOnly(1988, 4, 9), UserId = 17 },
                new Users { FirstName = "Alina", LastName = "Chirva", Email = "a.chirva@gmail.com", DateOfBirth = new DateOnly(1996, 7, 17), UserId = 18 },
                new Users { FirstName = "Dima", LastName = "Kravetz", Email = "dima.kravz@gmail.com", DateOfBirth = new DateOnly(2007, 3, 6), UserId = 19 },
                new Users { FirstName = "Kris", LastName = "Veselova", Email = "kr.veselova@boom.com", DateOfBirth = new DateOnly(1980, 8, 6), UserId = 20 }
            };

            var ageGrThan18 = from u in usersList
                              where DateTime.Now.Year - u.DateOfBirth.Year >= 18
                              select new
                              {
                                  u.FirstName,
                                  u.LastName,
                                  u.DateOfBirth,
                                  age = DateTime.Now.Year - u.DateOfBirth.Year,
                              };

            foreach (var a in ageGrThan18)
            {
                Console.WriteLine(a);
            }

            var groupEmail = from e in usersList
                             group e by e.Email.Substring(e.Email.IndexOf("@")) into g
                             orderby g.Count() descending
                             select g;
            foreach (var a in groupEmail)
            {
                Console.WriteLine($"{a.Key} - {a.Count()}");
                foreach (var k in a)
                {
                    Console.WriteLine($" {k.FirstName} {k.LastName} - {k.Email}");
                }

                break;
            }

            void UserID(int userID)
            {
                var id = from u in usersList
                         where u.UserId == userID
                         select new { u.LastName, u.FirstName, u.UserId };
                foreach (var i in id)
                {
                    Console.WriteLine(i);
                }
            }

            UserID(11);

            void SearchRelatives(string firstName, string lastName)
            {
                var relatives = from u in usersList
                                orderby u.DateOfBirth
                                where u.LastName == lastName && u.FirstName != firstName
                                group u by u.LastName into groupRel
                                orderby groupRel.Key
                                select groupRel;

                foreach (var group in relatives)
                {
                    Console.WriteLine(group.Key + " " + firstName);
                    Console.WriteLine("Possible relatives");

                    foreach (var item in group)
                    {
                        Console.WriteLine($"First Name: {item.FirstName}, Date of Birth: {item.DateOfBirth}");
                    }

                    Console.WriteLine("===============");
                }
            }

            SearchRelatives("Misha", "Kravetz");
        }
    }
}