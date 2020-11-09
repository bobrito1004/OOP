using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace lab1
{
    public class IniParser
    {
        private List<Section> arr = new List<Section>();

        public IniParser(string path)
        {
            Load(path);
        }

        private void Load(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    throw new Exception("No such file.");
                }

                if (path.Substring(path.Length - 4, 4) != ".ini")
                {
                    throw new Exception("File is not .ini");
                }

                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    var idx = arr.Count - 1;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line == "" || line.StartsWith(";")) continue;
                        if (line.StartsWith("[") && line.EndsWith("]"))
                        {
                            var groupName = line.Substring(1, line.Length - 2);
                            foreach (var section in arr)
                            {
                                if (groupName != section.get_sect()) continue;
                                idx = arr.IndexOf(section);
                                break;
                            }

                            if (idx == arr.Count - 1)
                            {
                                Section sect = new Section(groupName, new Dictionary<string, string>());
                                idx++;
                                arr.Add(sect);
                            }
                            else
                            {
                                arr[idx].Add(line);
                            }
                        }
                        else
                        {
                            arr[idx].Add(line);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        
        public string find_string(string cat, string key)
        {
            if (arr == null) throw new Exception("File is empty");
            foreach (var group in arr)
            {
                if (group.get_sect() != cat) continue;
                if (group.Dict.ContainsKey(key))
                    return group.Dict[key];
                throw new Exception("No such key");
            }

            throw new Exception("No such category.");
        }
        public int find_int(string cat, string key)
        {
            if (int.TryParse(find_string(cat, key), out var answer))
            {
                return answer;
            }
            throw new Exception("The value is not int");
        }

        public double find_float(string cat, string key)
        {
            if (float.TryParse(find_string(cat, key), out var answer))
            {
                return answer;
            }
            throw new Exception("The value is not float");
        }
    }

    public class Section
    {
        private string sect;
        public Dictionary<string, string> Dict;

        public Section(string n, Dictionary<string, string> dict)
        {
            Dict = dict;
            sect = n;
        }

        public string get_sect()
        {
            return sect;
        }

        public void Add(string line)
        {
            if (line.Contains(";"))
            {
                line = line.Substring(0, line.Length - (line.Length - line.IndexOf(";")));
            }
            if(line.Count(c => c == '=') > 1)
            {
                throw new Exception("Wrong format of the string");
            }
            var tmp = line.Split('=');
            tmp[0] = tmp[0].Trim();
            tmp[1] = tmp[1].Trim();
            Dict.Add(tmp[0], tmp[1]);
        }
    }
}