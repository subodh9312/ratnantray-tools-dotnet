using System.Data;
using System.Data.OleDb;
using System.IO;
using FileParser.Utils;

namespace FileParser.Parsers
{
    /// <summary>
    /// Reading data from excel and process it.
    /// </summary>
    public class ExcelParser : BaseParser
    {
        public ExcelParser(ObjectTransformer objectTransformer)
            : base(objectTransformer)
        {
        }
        
        /// <summary>
        /// Read the data from excel and process it
        /// </summary>
        public override void Read(string FileName, bool hasHeaderRow = true)
        {
            OleDbCommand cmd = GetReader(FileName);

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    // in case of Excel File parsing, we are expecting Columns to be specified in the header Row.
                    // Hence the Header Row would not anyways we returned in the query Resut Set.
                    // No Need to skip header.
                    IParseResult parseResult = ObjectTransformer.ParseResult(reader);
                    ObjectTransformer.Validate(parseResult);
                    Results.Add(parseResult);
                }
            }

        }

        /// <summary>
        /// Getting the reader object from excel odbc driver based on excel version
        /// </summary>
        /// <returns></returns>
        private OleDbCommand GetReader(string FileName)
        {
            string path = FileName;
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            string strFileType = Path.GetExtension(FileName).ToLower();
            OleDbCommand cmd = null;
            OleDbConnection conn = null;
            //Connection String to Excel Workbook
            try
            {
                string query = ObjectTransformer.GetSelectQuery();
                conn = new OleDbConnection(connString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
            } 
            catch
            {
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                conn = new OleDbConnection(connString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
            }            

            cmd = new OleDbCommand(ObjectTransformer.GetSelectQuery(), conn);
            return cmd;
        }

        public override string ToString()
        {
            return ParserType.EXCEL.ToString();
        }
    }
}
