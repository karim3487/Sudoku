using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    internal class Records
    {
        /*private string _playerName;
        private string _time;
        public Records()
        {
            _playerName = playerName;
            _time = time;
        }*/
        public void pushToFile(string time, string playerName, string filename)
        {
            var records = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(filename));
            if(records != null)
            {
                records.Add(time, playerName);
                File.WriteAllText(filename, JsonConvert.SerializeObject(records));
            }
            else
            {
                var firstRec = new Dictionary<string,string>();
                firstRec.Add(time, playerName);
                File.WriteAllText(filename, JsonConvert.SerializeObject(firstRec));
            }
        }

        public Dictionary<string, string> getRecords(string filename)
        {
            var records = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(filename));
            var integerRec = new Dictionary<int, KeyValuePair<string, string>>();
            var assortedRecords = new Dictionary<string, string>();

            if (records != null)
            {
                foreach (var pair in records)
                {
                    var key = pair.Key.Replace(":", "");
                    key = key.Replace(".", "");
                    var integerKey = Int32.Parse(key);
                    integerRec.Add(integerKey, pair);
                }
                foreach (var pair in integerRec.OrderBy(pair => pair.Key))
                    assortedRecords.Add(pair.Value.Key, pair.Value.Value);
            }
            else
            {
                assortedRecords = null;
            }
            return assortedRecords;
        }

        public void clearFiles()
        {
            File.WriteAllText("beginnerR.txt", String.Empty);
            File.WriteAllText("advancedR.txt", String.Empty);
            File.WriteAllText("professionalR.txt", String.Empty);
        }
    }
}
