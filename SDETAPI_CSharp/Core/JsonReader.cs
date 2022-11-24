using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SDETAPI_CSharp.Core
{
    public class JsonReader
    {
        public JObject ReadJsonFile(string fileName, Logger log)
        {
            string completePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName + ".json");

            JObject result = null;
            try
            {
                /// Complete the method
                StreamReader sr = new StreamReader(completePath);
                var text = sr.ReadToEnd();
                result = JObject.Parse(text);
            }
            catch (Exception e) when (e is IOException || e is OutOfMemoryException || e is JsonReaderException)
            {
                log.Error("Parse Exception, either for lack of memory, filesystem issue, or mistakes in file.Exception[{0}]", e.Message);
            }

            return result;
        }
    }
}
