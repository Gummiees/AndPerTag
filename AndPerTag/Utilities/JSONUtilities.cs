using AndPerTag.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace AndPerTag.Utilities
{
    public static class JSONUtilities
    {
        #region CONSTANTS
        private const string pathJSONFile = "Assets\\JSON\\data.json";
        #endregion

        /// <summary>
        /// Rewrites the whole file with the text assigned to it.
        /// </summary>
        /// <param name="tags"></param>
        public static void Write(AllTags tags)
        {
            // serialize JSON directly to a file. Overwrites the file.
            using (StreamWriter file = new StreamWriter($"{AppDomain.CurrentDomain.BaseDirectory}/{pathJSONFile}"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, tags);
            }
        }
        /// <summary>
        /// Reads the JSON file and returns it as a list of tags.
        /// </summary>
        /// <returns></returns>
        public static AllTags Read()
        {
            AllTags tags;
            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText($"{AppDomain.CurrentDomain.BaseDirectory}{pathJSONFile}"))
            {
                JsonSerializer serializer = new JsonSerializer();
                tags = (AllTags)serializer.Deserialize(file, typeof(AllTags));
            }

            return tags;
        }
    }
}
