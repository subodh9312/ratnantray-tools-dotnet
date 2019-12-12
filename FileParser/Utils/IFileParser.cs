using System.Collections.Generic;

namespace FileParser.Utils
{
    public interface IFileParser
    {
        ParserType GetExtention(string FileName);
        List<IParseResult> ParseFile(string FileName, ObjectTransformer objectTransformer, bool hasHeaderRow = true);
    }
}