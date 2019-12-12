using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace FileParser.Utils
{
    public abstract class ObjectTransformer
    {
        /// <summary>
        /// Converting the string of array into object. In order to avoid run time error the values are set to min value
        /// </summary>
        /// <param name="LineString"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public IParseResult GetParseResult(string LineString, string separator)
        {
            string[] stringarray = LineString.Split(separator.ToCharArray());
            return ParseResult(stringarray);
        }

        /// <summary>
        /// Abstract method which should be overridden for parsing.
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        public abstract IParseResult ParseResult(string[] elements);

        /// <summary>
        /// Method should be overridden in sub-classes for instance like in Excel for 
        /// which the data can be selected via SQL Query
        /// </summary>
        /// <returns></returns>
        public virtual string GetSelectQuery()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Used for validation of Parsed Data
        /// </summary>
        /// <param name="parseResult"></param>
        /// <returns></returns>
        public abstract bool Validate(IParseResult parseResult);

        /*public bool Validate(IParseResult parseResult, ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            List<string> errors = new List<string>();
            bool Isvalid = Validator.TryValidateObject(parseResult, validationContext, results);
            if (!Isvalid)
            {
                foreach (var validationResult in results)
                {
                    errors.Add(validationResult.ErrorMessage);
                }
                parseResult.ErrorMessages = errors;
            }
            return Isvalid;
        }*/

        /// <summary>
        /// Converting datareader to object. In order to avoid run time error the values are set to min value
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public IParseResult ParseResult(OleDbDataReader reader)
        {
            List<string> stringElements = new List<string>();

            for (int i = 0; i < reader.VisibleFieldCount; i++)
                stringElements.Add(reader[i].ToString());

            return ParseResult(stringElements.ToArray());
        }

        protected virtual double ValidateDouble(string value, IParseResult parseResult, string errorMessage, bool isRequired = true)
        {
            double result;
            bool isValid = Double.TryParse(value, out result);

            if (!isRequired && String.IsNullOrEmpty(value))
                return Double.NaN;

            if (!isValid)
                parseResult.ErrorMessages.Add(errorMessage);

            return result;
        }

        protected virtual decimal ValidateDecimal(string value, IParseResult parseResult, string errorMessage, bool isRequired = true)
        {
            decimal result;
            bool isValid = Decimal.TryParse(value, out result);

            if (!isRequired && String.IsNullOrEmpty(value))
                return Decimal.Zero;

            if (!isValid)
                parseResult.ErrorMessages.Add(errorMessage);

            return result;
        }

        protected virtual double ValidateInteger(string value, IParseResult parseResult, string errorMessage, bool isRequired = true)
        {
            int result;
            bool isValid = Int32.TryParse(value, out result);

            if (!isRequired && String.IsNullOrEmpty(value))
                return 0;

            if (!isValid)
                parseResult.ErrorMessages.Add(errorMessage);

            return result;
        }

        protected virtual bool ValidateBoolean(string value, IParseResult parseResult, string errorMessage)
        {
            bool result;
            bool isValid = Boolean.TryParse(value, out result);

            if (!isValid)
                parseResult.ErrorMessages.Add(errorMessage);

            return result;

        }

        protected virtual DateTime ValidateDateTime(string value, string dateTimeFormat, IParseResult parseResult, 
            string errorMessage, bool defaultToCurrentDate = true)
        {
            DateTime result;
            bool isValid = DateTime.TryParseExact(value, dateTimeFormat, null, System.Globalization.DateTimeStyles.None, out result);

            if (!isValid)
            {
                // check if the dateTime is while importing from Excel
                dateTimeFormat = "dd-MM-yyyy hh.mm.ss tt";
                isValid = DateTime.TryParseExact(value, dateTimeFormat, null, System.Globalization.DateTimeStyles.AssumeLocal, out result);
                if (!isValid)
                {
                    parseResult.ErrorMessages.Add(errorMessage);
                    if (defaultToCurrentDate)
                        return DateTime.Today;
                }
            }

            return result;

        }
    }
}
