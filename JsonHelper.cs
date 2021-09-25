using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SBT
{
    public static class JsonHelper
    {
        public static string ShowJSON(string name)
        {
            string[] lines = Parser.ReadFile(name);
            List<string> policies = Parser.GetPolicies(lines);
            List<Dictionary<string, string>> parsedPolicies = Parser.GetParsedPolicies(policies);
            string json = MakeJSON(parsedPolicies);
            return json;
        }
       
        public static string MakeJSON(List<Dictionary<string, string>> parsedPolicies)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(parsedPolicies, options);
            return json;

        }
        public static void ExportToJsonFile(string json, string desiredName)
        {
            File.WriteAllText(desiredName, json);
        }
        
    }
}
