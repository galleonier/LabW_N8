﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Threading;
using System.Diagnostics;

namespace Level3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Number15.Program.Start();
        }
    }
}

namespace Number13
{
    internal static class Program
    {
        /// Определить долю в процентах слов, начинающихся на разные
        /// буквы. Выписать эти буквы и доли начинающихся на них слов

        public static void Start()
        {
            var doc = new StreamReader("Text.txt");
            var AllAnswers = new List<Answer>(); 
            var CurrentAnswers = doc.ReadToEnd().Split(' ').ToList().Select(x => x[0]).ToList(); 
            AllAnswers = SupportMethods.FinListMaker(CurrentAnswers); 
            Console.WriteLine(""); 
            AllAnswers = SupportMethods.FinAnswersListMaker(AllAnswers); 
            SupportMethods.PrintParticipant(AllAnswers, CurrentAnswers.Count); 
            Console.WriteLine();
        }
    }

    public struct Answer
    {
        public Char Anss;
        public int Count;
        public Answer(char ans, int count = 1)
        {
            Anss = ans;
            Count = count;
        }
    }

    public static class SupportMethods
    {
        public static void PrintParticipant(List<Answer> answers, int AnsCount)
        {
            for (int i = 0; i < answers.Count; i++) Console.WriteLine($"Answer: {answers[i].Anss} - {answers[i].Count} \t Result: {(answers[i].Count*100)/AnsCount}%");
        }
        public static List<Answer> FinListMaker(List<Char> CurrentAnswers)
        {
            var AllAnswers = new List<Answer>();
            foreach (var answer in CurrentAnswers)
            {
                int index = AllAnswers.Select(x => x.Anss).ToList().IndexOf(answer);
                if (index >= 0) AllAnswers[index] = new Answer(AllAnswers[index].Anss, AllAnswers[index].Count + 1);
                else AllAnswers.Add(new Answer(answer));
            }
            /*foreach (var answer in CurrentAnswers)
                {
                    if (answer == "") continue;
                    else if ((from a in AllAnswers select a.Anss).Contains(answer))
                    {
                        for (int AnswerInd = 0; AnswerInd < AllAnswers.Count; AnswerInd++)
                        {
                            if (AllAnswers[AnswerInd].Anss == answer)
                            {
                                AllAnswers[AnswerInd] = new Answer(AllAnswers[AnswerInd].Anss,
                                    AllAnswers[AnswerInd].Count + 1);
                                break;
                            }
                        }
                    }
                    else
                    {
                        AllAnswers.Add(new Answer(answer));
                    }
                }*/
            return AllAnswers;
        }

        public static List<Answer> FinAnswersListMaker(List<Answer> list )
        {
            for (int i = 0; i < list.Count; i++)
            { 
                Answer temp; 
                for (int j = i + 1; j < list.Count; j++) 
                { 
                    if (list[j].Count > list[i].Count) 
                    { 
                        temp = list[i]; 
                        list[i] = list[j]; 
                        list[j] = temp;
                    }
                }
            }
            return list;
        }
    }
}

namespace Number15
{
    public static class Program
    {
        /// Текст содержит слова и целые числа произвольного порядка.
        /// Найти сумму включенных в текст чисел.

        public static void Start()
        {
            var doc = new StreamReader("Text.txt");
            int Sum = 0;
            int ans;
            while (!doc.EndOfStream)
            {
                var CurrentAnswers = doc.ReadLine().Split(' ');
                foreach (var answer in CurrentAnswers) if (int.TryParse(answer, out ans)) Sum += ans;
            }
            Console.WriteLine(Sum);
        }
    }
}


