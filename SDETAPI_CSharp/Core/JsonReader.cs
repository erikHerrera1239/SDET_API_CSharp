using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SDETAPI_CSharp.Features.HealthcareGov.Models;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace SDETAPI_CSharp.Core
{
    public class JsonReader
    {
        public JObject ReadJsonFile([NotNull] string completePath, ILog log)
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
                log.Info("Parse Exception, either for lack of memory, filesystem issue, or mistakes in file.Exception[{0}]", e);
            }

            return result;
        }

        public JObject GetJObjectFromJsonFile(string directory, string fileName, ILog log)
        {
            var files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories);
            var filePath = files.Single(f => Path.GetFileName(f) == fileName + ".json");
            return this.ReadJsonFile(filePath, log);
        }
    }
}
