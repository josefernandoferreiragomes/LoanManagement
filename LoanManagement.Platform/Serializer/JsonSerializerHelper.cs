using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.CodeDom;

namespace LoanManagement.Platform.Serializer
{
    public static class JsonSerializerHelper
    {
        public static string SerializeToJson<T>(T obj)
        {
            string output = "";            
            output = JsonSerializer.Serialize<T>(obj);
            return output;
        }
        public static string SerializeToJsonWithIndent<T>(T obj)
        {
            string output = "";
            var options = new JsonSerializerOptions { WriteIndented = true };
            output = JsonSerializer.Serialize<T>(obj, options);
            return output;
        }
    }
}
