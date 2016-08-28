using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Textile.Textile
{
    public interface IParser
    {
        String Parse(String texts);
        String Parse(TextReader reader);
        String ParseLine(String line);
        String ParseLines(String[] line);
    }
}
