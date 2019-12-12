using System.Collections.Generic;
using System.IO;
using FileParser.Utils;

namespace FileParser.Parsers
{
    public abstract class BaseParser
    {
        public ObjectTransformer ObjectTransformer { get; private set; }

        public BaseParser(ObjectTransformer objectTransformer)
        {
            Results = new List<IParseResult>();
            ObjectTransformer = objectTransformer;
        }
        
        /// <summary>
        /// Read the file rows and process it for CSV,PIPE and other delimiters 
        /// </summary>
        public virtual void Read(string FileName, bool hasHeaderRow = true)
        {
            using (FileStream stream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string Linestring = "";
                    bool flag = false;
                    while ((Linestring = reader.ReadLine()) != null)
                    {
                        if (hasHeaderRow && !flag)
                        {
                            flag = true;
                            continue;
                        }
                        IParseResult result = ObjectTransformer.GetParseResult(Linestring, Delimiter);
                        if (result != null)
                        {
                            ObjectTransformer.Validate(result);
                            Results.Add(result);
                        }
                    }
                }
            }
        }

        public List<IParseResult> Results { get; private set; }
        public virtual string Delimiter { get; protected set; }
    }
}