
namespace Santa_s_Gifts
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
            Dictionary<string, int> children = new Dictionary<string, int>();
            Dictionary<string, int> presents = new Dictionary<string, int>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] childrenData = command.Split("->");//Sam->Candy->20, Leo->Candy->10

                if (childrenData[0] == "Remove")
                {
                    string childName = childrenData[1];
                    children.Remove(childName);
                }
                else if(childrenData[0] != "Remove")//Sam->Candy->20, Leo->Candy->10
                {
                    string childName = childrenData[0];
                    string typeOfPresent = childrenData[1];
                    int sumOfPresents = int.Parse(childrenData[2]);

                    if (!children.ContainsKey(childName))
                    {
                        children.Add(childName, sumOfPresents);
                        
                    }
                    else
                    {
                        children[childName] += sumOfPresents;
                        
                    }

                    if (!presents.ContainsKey(typeOfPresent))
                    {
                        
                        presents.Add(typeOfPresent, sumOfPresents);
                    }
                    else
                    {
                        
                        presents[typeOfPresent] += sumOfPresents;
                    }

                }

            }

            Console.WriteLine("Children:");
            foreach (var (childName, sumOfPresents) in children.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{childName} -> {sumOfPresents}");
            }

            Console.WriteLine("Presents:");
            foreach (var (typeOfPresent, sumOfPresents) in presents)
            {
                Console.WriteLine($"{typeOfPresent} –> {sumOfPresents}");
            }
        }
    }
}
