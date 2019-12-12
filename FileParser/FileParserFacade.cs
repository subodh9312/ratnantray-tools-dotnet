using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using FileParser.Parsers;
using FileParser.Utils;

namespace FileParser
{
    public class FileParserFacade : IFileParser
    {
        private static FileParserFacade _instance = new FileParserFacade();
        protected FileParserFacade()
        {

        }

        public static FileParserFacade GetInstance()
        {
            return _instance;
        }

        public List<IParseResult> ParseFile(string FileName, ObjectTransformer objectTransformer, bool hasHeaderRow = true)
        {
            ParserFactory Factory = new ParserFactory(objectTransformer);
            Factory.PopulateParsers(objectTransformer, Assembly.GetCallingAssembly());
            BaseParser parser = null;

            string configuredParser = ConfigurationManager.AppSettings["FileParser.Class"];
            if (!String.IsNullOrEmpty(configuredParser))
            {
                parser = Factory.GetParser(configuredParser);
            }
            else
            {
                ParserType type = GetExtention(FileName);
                parser = Factory.GetParser(type.ToString());
            }
            parser.Read(FileName, hasHeaderRow);
            return parser.Results;
        }

        public ParserType GetExtention(string FileName)
        {
            string strFileType = Path.GetExtension(FileName).ToLower();
            switch (strFileType)
            {
                case ".xls":
                    return ParserType.EXCEL;
                case ".xlsx":
                    return ParserType.EXCEL;
                case ".pipe":
                    return ParserType.PIPE;
                case ".txt":
                    return ParserType.SEMICOLON;
                default:
                    return ParserType.CSV;
            }
        }
    }
}
