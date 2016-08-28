using Cartif.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Textile.Textile
{
    public class MarkRegex
    {
        // CartifDictionary
        private CartifDictionary<String, Regex> compiledPatterns = new CartifDictionary<String, Regex>(7);
        public Regex this[String name] => compiledPatterns[name];

        public MarkRegex()
        {
            // TODO Refactor this with the new CartifDictionary
            CartifDictionary<String, String> p = new CartifDictionary<String, String>()
            {
                ["Class"] = "\\([^\\)]+\\)",
                ["Style"] = "\\{[^\\}]+\\}",
                ["Lang"] = "\\[[^\\[\\]]+\\]",
                ["Align"] = "(?:<>|<|>|=)",
                ["Pad"] = "[\\(\\)]+",
                ["Blocks"] = "(?:b[qc]|div|notextile|pre|h[1-6]|fn\\d+|p|###)"
            };

            p.Add("Attributes", $"(?:{p["Class"]}|{p["Style"]}|{p["Lang"]}|{p["Align"]}|{p["Pad"]})*");

            foreach (var pattern in p)
                compiledPatterns.Add(pattern.Key, new Regex(pattern.Value, RegexOptions.Compiled));
        }
    }
}
