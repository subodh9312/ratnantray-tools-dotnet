using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using FileParser.Parsers;
using FileParser.Utils;

namespace FileParser
{
    /// <summary>
    /// Parser Factory Pattern
    /// </summary>
    public class ParserFactory
    {
        Dictionary<string, BaseParser> parsers = new Dictionary<string, BaseParser>();
        
        /// <summary>
        /// Load the assembly dynamically which are inheriting from baseparser class.
        /// We can add any number of classes which inherit from baseparser
        /// </summary>
        public ParserFactory(ObjectTransformer objectTransformer)
        {
            PopulateParsers(objectTransformer, Assembly.GetExecutingAssembly());
        }

        public void PopulateParsers(ObjectTransformer objectTransformer, Assembly assembly)
        {
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.IsSubclassOf(typeof(BaseParser)) && (!type.IsAbstract))
                {
                    BaseParser parser = Activator.CreateInstance(type, new object[] { objectTransformer }) as BaseParser;
                    parsers.Add(parser.ToString(), parser);
                }
            }
        }

        public BaseParser GetParser(string type)
        {
            return parsers[type];
        }
    }


}
