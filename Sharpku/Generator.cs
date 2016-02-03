using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Sharpku
{
    public class Generator
    {
        private readonly string _path;
        List<string> _list5 = new List<string>();
        List<string> _list7 = new List<string>();
        List<string> _name1 = new List<string>();
        List<string> _name2 = new List<string>();

        public Generator()
        {
            _path = @"Assets\";
        }

        public Generator(string filePathForLists)
        {
            _path = filePathForLists;
        }

        public string GenerateHaiku()
        {
            _list5 = DeserializeListOfJsonSentences(_path + "list5.json");
            _list7 = DeserializeListOfJsonSentences(_path + "list7.json");
            _name1 = DeserializeListOfJsonSentences(_path + "name1.json");
            _name2 = DeserializeListOfJsonSentences(_path + "name2.json");

            var rnd = new Random();

            var poem = string.Format("{0}\n{1}\n{2}", _list5[rnd.Next(0, _list5.Count)], _list7[rnd.Next(0, _list5.Count)], _list5[rnd.Next(0, _list5.Count)]);

            if (poem.Contains("Tom"))
            {
                poem = poem.Replace("Tom", _name1[rnd.Next(0, _name1.Count)]);
            }

            if (poem.Contains("Mary"))
            {
                poem = poem.Replace("Mary", _name2[rnd.Next(0, _name2.Count)]);
            }

            return poem;
        }

        private List<string> DeserializeListOfJsonSentences(string filename)
        {
            using (var file = File.OpenText(filename))
            {
                var serializer = new JsonSerializer();
                return (List<string>)serializer.Deserialize(file, typeof(List<string>));
            }
        }
    }
}
