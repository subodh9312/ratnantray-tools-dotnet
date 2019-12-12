using FileParser.Utils;

namespace FileParser.Parsers
{
    /// <summary>
    /// Parsing pipe dilimited file 
    /// </summary>
    public class PipeParser : BaseParser
    {
        public PipeParser(ObjectTransformer objectTransformer) 
            : base(objectTransformer)
        {

        }

        public override void Read(string FileName, bool hasHeaderRow = true)
        {
            Delimiter = "|";
            base.Read(FileName, hasHeaderRow);
        }

        public override string ToString()
        {
            return ParserType.PIPE.ToString();
        }
    }
}
