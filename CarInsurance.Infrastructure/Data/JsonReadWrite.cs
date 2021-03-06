using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CarInsurance.Infrastructure.Data
{
    public class JsonReadWrite
    {
        public string Read(string fileName)
        {
            //string root = "wwwroot";
            string root = Directory.GetParent(Environment.CurrentDirectory).FullName;
            var path = string.Format("{0}{1}{2}", root, "\\CarInsurance.Core\\JSONData\\", fileName);

            string jsonResult;

            using (StreamReader streamReader = new StreamReader(path))
            {
                jsonResult = streamReader.ReadToEnd();
            }
            return jsonResult;
        }

        public void Write(string fileName, string jSONString)
        {
            string root = Directory.GetParent(Environment.CurrentDirectory).FullName;
            var path = string.Format("{0}{1}{2}", root, "\\CarInsurance.Core\\JSONData\\", fileName);

            using (var streamWriter = File.CreateText(path))
            {
                streamWriter.Write(jSONString);
            }
        }
    }
}
