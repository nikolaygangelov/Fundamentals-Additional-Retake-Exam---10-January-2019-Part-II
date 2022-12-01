
namespace Secret_Helper
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {

            int key = int.Parse(Console.ReadLine());

            
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                StringBuilder sb = new StringBuilder();
                foreach (char ch in command)
                {
                    sb.Append((char)((int)ch - key));
                }

                string pattern = @"@(?<name>[A-Za-z]+)[^\@\-\!\:\>]*!(?<behavior>G|N)!";
                Regex regex = new Regex(pattern);//@Kate^jfdvbkrjgb!G!
                Match match = regex.Match(sb.ToString());

                if (match.Success)
                {
                    string behavior = match.Groups["behavior"].ToString();
                    if (behavior == 'G'.ToString())
                    {
                        Console.WriteLine(match.Groups["name"]);
                    }
                }
                
            }
        }
    }
}
