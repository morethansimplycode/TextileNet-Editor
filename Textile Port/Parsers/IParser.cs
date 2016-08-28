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
        String Parse(String input);
        String Parse(TextReader reader);
    }
}
