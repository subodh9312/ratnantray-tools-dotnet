using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBManager.Utils
{
    public enum QueryMode
    {
        Reader,
        Update,
        Scalar,
        Script,
        ConfigReader
    }
}
