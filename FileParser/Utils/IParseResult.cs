using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.Utils
{
    public interface IParseResult
    {
        List<string> ErrorMessages { get; set; }
    }
}
