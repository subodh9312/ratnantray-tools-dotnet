using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileParser.Utils;

namespace FileParser.Parsers
{
    public class SemiColonParser : BaseParser
    {
        public SemiColonParser(ObjectTransformer objectTransformer)
            : base(objectTransformer)
        {

        }

        public override void Read(string FileName, bool hasHeaderRow = true)
        {
            Delimiter = ";";
            base.Read(FileName, hasHeaderRow);
        }

        public override string ToString()
        {
            return ParserType.SEMICOLON.ToString();
        }
    }
}
