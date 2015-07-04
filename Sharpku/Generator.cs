using System;
using System.Collections.Generic;
using System.IO;

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
            //_list5 = ReadListOfSentences(@"Assets\list5");
            _list5 = ReadListOfSentences(_path + "list5");
            _list7 = ReadListOfSentences(_path + "list7");
            _name1 = ReadListOfSentences(_path + "name1");
            _name2 = ReadListOfSentences(_path + "name2");

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

        private List<string> ReadListOfSentences(string filename)
        {
            var list = new List<string>();
            using (var reader = new StreamReader(filename))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            return list;
        }
    }
}
