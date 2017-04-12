using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LMS
{
    static class Parser
    {
        public static Dictionary<string, string> ReadDataIn(string filename)
        {
            string line;
            var dataIn = new Dictionary<string, string>();
            using (StreamReader file = new StreamReader(filename))
            {
                while ((line = file.ReadLine()) != null)
                {
                    string[] split = line.Split(new Char[] { ':' });
                    dataIn.Add(split[0], split[1]);
                }
            }
            return dataIn;
        }

        public static Dictionary<string, List<string>> Read(string filename)
        {
            string line;
            var data = new Dictionary<string, List<string>>();
            using (StreamReader file = new StreamReader(filename))
            {
                while ((line = file.ReadLine()) != null)
                {
                    var list = new List<string>();
                    string[] split = line.Split(new Char[] { ':', '|' });
                    for (int index = 1; index < split.Length; index++)
                    {
                        list.Add(split[index]);
                    }
                    data.Add(split[0], list);
                }
            }
            return data;
        }


        public static void WriteData(string filename, string text)
        {
            File.AppendAllText(filename, text, Encoding.UTF8);
        }


        public static void ChangeData(string filename, string searchText, string replaceText, string key)
        {
            string firstLine;
            string secondLine = "";
            List<string> content = new List<string>();
            using (StreamReader file = new StreamReader(filename))
            {
                while ((firstLine = file.ReadLine()) != null)
                {
                    string[] split = firstLine.Split(new Char[] { ':', '|' });
                    if (split[0] == key)
                    {
                        for (int index = 0; index < split.Length; index++)
                        {
                            if (split[index] == searchText) split[index] = replaceText;
                            if (index == 0) secondLine += split[index] + ':';
                            else if (index < split.Length - 1) secondLine += split[index] + '|';
                            else secondLine += split[index];
                        }
                        content.Add(secondLine);
                    }
                    else content.Add(firstLine);
                }
            }
            using (StreamWriter file = new StreamWriter(filename))
            {
                foreach (string element in content)
                    file.WriteLine(element);
            }
        }

        public static void PutData(string filename, string putText, string key)
        {
            string firstLine;
            string secondLine = "";
            List<string> content = new List<string>();
            using (StreamReader file = new StreamReader(filename))
            {
                while ((firstLine = file.ReadLine()) != null)
                {
                    string[] split = firstLine.Split(new Char[] { ':', '|' });
                    if (split[0] == key)
                    {
                        for (int index = 0; index < split.Length; index++)
                        {
                            if (index == 0) secondLine += split[index] + ':';
                            else secondLine += split[index] + '|';

                        }
                        secondLine += putText;
                        content.Add(secondLine);
                    }
                    else content.Add(firstLine);
                }
            }
            using (StreamWriter file = new StreamWriter(filename))
            {
                foreach (string element in content)
                    file.WriteLine(element);
            }
        }
        public static void DeleteData(string filename, string key)
        {
            string firstLine;
            List<string> content = new List<string>();
            using (StreamReader file = new StreamReader(filename))
            {
                while ((firstLine = file.ReadLine()) != null)
                {
                    string[] split = firstLine.Split(new Char[] { ':' });
                    if (split[0] != key) content.Add(firstLine);
                }
            }
            using (StreamWriter file = new StreamWriter(filename))
            {
                foreach (string element in content)
                    file.WriteLine(element);
            }
        }

        public static void DeleteData(string filename, string deleteText, string key)
        {
            string firstLine;
            string secondLine = "";
            List<string> content = new List<string>();
            using (StreamReader file = new StreamReader(filename))
            {
                while ((firstLine = file.ReadLine()) != null)
                {
                    string[] split = firstLine.Split(new Char[] { ':', '|' });
                    if (split[0] == key)
                    {
                        for (int index = 0; index < split.Length; index++)
                        {
                            if (split[index] != deleteText)
                            {
                                if (index == 0) secondLine += split[index] + ':';
                                else if ((index + 1 == split.Count() - 1 && split[index + 1] == deleteText) || (index == split.Count() - 1))
                                    secondLine += split[index];
                                else secondLine += split[index] + '|';
                            }
                        }
                        content.Add(secondLine);
                    }
                    else content.Add(firstLine);
                }
            }
            using (StreamWriter file = new StreamWriter(filename))
            {
                foreach (string element in content)
                    file.WriteLine(element);
            }
        }
    }
}
