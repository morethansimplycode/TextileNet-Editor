using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Textile.Textile
{
    class TextileParser : IParser
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

        public string Parse(string text)
        {
            return Parse(new StringReader(text));
        }

        public string Parse(TextReader reader)
        {
            String line;
            StringBuilder builder = new StringBuilder();

            while ((line = reader.ReadLine()) != null)            
                builder.Append(Formatter.FormatLine(line));            

            return builder.ToString();
        }

        #endregion
    }
}
