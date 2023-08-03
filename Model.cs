using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.IO;
using System.Windows.Controls;

namespace JsonViewer
{
    internal class Model
    {
        public void PopulateDataTable(StackPanel sP)
        {
            string json = ReadAllTextFromPath();

            JArray jsonArray = JsonConvert.DeserializeObject<JArray>(json);

            foreach (JToken jToken in jsonArray)
            {
                foreach (JProperty jP in jToken)
                {
                    Label label = new Label();
                    label.Content = jP.Value.ToString();
                    sP.Children.Add(label);
                }
            }
        }

        public string ReadAllTextFromPath()
        {
            string path = "../../../Resources/TestJson.json";

            string jsonText = "";

            if (File.Exists(path))
            {
                jsonText =  File.ReadAllText(path);
            }

            return jsonText;
        }

    }
}
