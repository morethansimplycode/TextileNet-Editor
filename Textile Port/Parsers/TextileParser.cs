using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Textile.Textile
{
    public class TextileParser : IParser
    {
        #region Fields

        private IFormatter Formatter { get; }

        #endregion

        #region Contructors

        public TextileParser(IFormatter formatter)
        {
            this.Formatter = formatter;
        }

        #endregion

        #region Properties and Setters

        public IParser SetFormatter(IFormatter formatter)
        {
            return new TextileParser(formatter);
        }

        #endregion

        #region Parsing

        public String Parse(string text)
        {
            return Parse(new StringReader(text));
        }

        public String Parse(TextReader reader)
        {
            String line;
            StringBuilder builder = new StringBuilder();

            while ((line = reader.ReadLine()) != null)
                builder.Append(Formatter.FormatLine(line));

            return builder.ToString();
        }

        public String ParseLine(String line)
        {
            return Formatter.FormatLine(line);
        }

        public String ParseLines(String[] lines)
        {
            StringBuilder builder = new StringBuilder();

            foreach (String line in lines)
                builder.Append(Formatter.FormatLine(line));

            return builder.ToString();
        }

        public String[] FormatLines(String[] lines)
        {
            int length = lines.Length;

            for (int i = 0; i < length; i++)
                lines[i] = Formatter.FormatLine(lines[i]);

            return lines;
        }

        #endregion

        #region Regex

        #endregion
    }
}
