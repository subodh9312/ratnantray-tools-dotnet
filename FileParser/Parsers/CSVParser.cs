using FileParser.Utils;

namespace FileParser.Parsers
{
    /// <summary>
    /// Parse the CSV file
    /// </summary>
    public class CSVParser : BaseParser
    {
        public CSVParser(ObjectTransformer objectTransformer)
            : base(objectTransformer)
        {
        }

        public override void Read(string FileName, bool hasHeaderRow = true)
        {
            Delimiter = ",";
            base.Read(FileName, hasHeaderRow);
        }

        public override string ToString()
        {
            return ParserType.CSV.ToString();
        }
    }
}
