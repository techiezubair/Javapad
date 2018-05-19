using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.Script.Serialization;

namespace Javapad
{
    class ProjectEuler
    {
        private static string[] problems, answers;
        public static int currentProblem = 1;
        public ProjectEuler()
        {
            Init();
        }
        private void Init()
        {
            string problemsPlainText = Properties.Resources.project_euler_problems;
            string[] problemsArray = Regex.Split(problemsPlainText, @"^Problem", RegexOptions.Multiline);
            problems = new string[problemsArray.Length];
            answers = new string[problemsArray.Length];
            for (int i = 0; i < problemsArray.Length; i++)
            {
                string question = problemsArray[i];
                question = DeleteLines(question, 3);
                int len = question.Length;
                int index = question.IndexOf("Answer: ");
                if (index > 0)
                    len = index;
                 problems[i] = question.Substring(0, len);
             
                string answer = question.Substring(index + 7);
                answer = Regex.Replace(answer, @"\t|\n|\r| ", "");
                answers[i] = answer;
            }
        }
        public static string DeleteLines(string input, int linesToSkip)
        {
            int startIndex = 0;
            for (int i = 0; i < linesToSkip; ++i)
                startIndex = input.IndexOf('\n', startIndex) + 1;
            return input.Substring(startIndex);
        }
        public string Question(int num)
        {
            currentProblem = num;
            return problems[num];
        }
        public string Answer(int num)
        {
            return answers[num];
        }
        public static int TotalQuestions
        {
            get { return problems.Length; }
        }

        public static bool CheckAnswer(int problemNumber, string answer, string userAnswer, int points)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, userAnswer);
                if (hash.CompareTo(answer) == 0)
                {
                    Points.Add(points);
                    ProjectEulerProgress.Solved(problemNumber, userAnswer);
                    return true;
                }
                else
                {
                    // to remove ponits
                    // same amount as Add points
                    //this.remove(points);
                    return false;
                }
            }
        }
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
    public static class ProjectEulerProgress
    {
        public static Dictionary<string, string> SolvedDictionary = new Dictionary<string, string>();
        public static JavaScriptSerializer js = new JavaScriptSerializer();
        private static void Init()
        {
            // create or get info from the registry...
        }
        public static void Solved(int problemNumber, string userPlainTextAnswer)
        {
            SolvedDictionary.Add(problemNumber.ToString(), userPlainTextAnswer);
            Update();
        }
        private static void Update()
        {
            // update the registry entry
            RegistryManager.Write("PESolved", js.Serialize(SolvedDictionary));
        }
        public static bool GetSolved(int problemNumber)
        {
            if (SolvedDictionary.ContainsKey(problemNumber.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
