using Cartif.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Textile.Textile
{
    public class MarkRegex
    {
        // CartifDictionary
        private static readonly CartifDictionary<String, String> patterns = new Dictionary<String, String>();

        static MarkRegex()
        {
        }


        #region Attributes

        private const String ClassPattern = "\\([^\\)]+\\)";
        private const String StylePattern = "\\{[^\\}]+\\}";
        private const String LangPattern = "\\[[^\\[\\]]+\\]";
        private const String AlignPattern = "(?:<>|<|>|=)";
        private const String PadPattern = "[\\(\\)]+";

        private static readonly String AttributeUnionPattern = $"(?:{ClassPattern}|{StylePattern}|{LangPattern}|{AlignPattern}|{PadPattern})*";

        #endregion

        private const String BlocksPattern = "(?:b[qc]|div|notextile|pre|h[1-6]|fn\\d+|p|###)";
    }
}
