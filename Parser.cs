using System;
using System.Collections.Generic;
using System.IO;

namespace SBT
{
    public static class Parser
    {
        public static string[] ReadFile(string fileToOpen)
        {
            string[] lines;
            using StreamReader sr = new StreamReader(fileToOpen);
            var wholeFile = sr.ReadToEnd();
            return lines = wholeFile.Split('\n');
        }
        public static List<string> GetPolicies(string[] fileLines)
        {
            string definedCriteria = "";
            List<string> policies = new List<string>();

            for (var i = 0; i < fileLines.Length; i += 1)
            {
                if (!fileLines[i].StartsWith("#"))
                {
                    if (fileLines[i].Contains("<custom_item>"))
                    {
                        definedCriteria = "";
                    }
                    else if (fileLines[i].Contains("</custom_item>"))
                    {
                        policies.Add(definedCriteria);
                    }
                    else
                    {
                        definedCriteria += fileLines[i] + "\n ";
                    }
                }
            }
            return policies;
        }
        public static List<Dictionary<string, string>> GetParsedPolicies(List<string> policies)
        {
            List<Dictionary<string, string>> parsedPolicies = new List<Dictionary<string, string>>();
            foreach (string policy in policies)
            {
                Dictionary<string, string> parsedPolicy = new Dictionary<string, string>();
                string[] linesOfOnePolicy = ParsePolicyByNewLine(policy);

                for (var j = 0; j < linesOfOnePolicy.Length; j += 1)
                {
                    if (string.IsNullOrEmpty(linesOfOnePolicy[j]))
                        continue;

                    string[] splittedLine = ParseLineByColon(linesOfOnePolicy[j]);

                    if (splittedLine.Length < 2)
                        continue;
                    parsedPolicy.Add(splittedLine[0], splittedLine[1]);
                }
                parsedPolicies.Add(parsedPolicy);
            }
            return parsedPolicies;
        }
        public static string[] ParsePolicyByNewLine(string policy)
        {
            string[] linesOfOnePolicy = policy.Trim().Split(new string[] { "\n " }, StringSplitOptions.RemoveEmptyEntries); ;
            return linesOfOnePolicy;
        }
        public static string[] ParseLineByColon(string line)
        {
            string[] splittedLine = line.Trim().Split(new string[] { " : " }, StringSplitOptions.RemoveEmptyEntries); ;
            return splittedLine;
        }
    }
}
