using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;

namespace SDETAPI_CSharp.Core
{
    public class JsonReader
    {
        public JObject ReadJsonFile([NotNull] string completePath)
        {
            JObject result = null;
            try
            {
                /// Complete the method
                using StreamReader sr = new StreamReader(completePath);
                var text = sr.ReadToEnd();
                result = JObject.Parse(text);
            }
            catch (Exception e) when (e is IOException || e is OutOfMemoryException || e is JsonReaderException)
            {
                Console.WriteLine("Parse Exception, either for lack of memory, filesystem issue, or mistakes in file.Exception[{0}]", e.Message);
            }

            return result;
        }
    }
}
