using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossAz
{

    public static class FileHelper
    {
        public static void WriteJson(Database database)
        {
            var ser = new Newtonsoft.Json.JsonSerializer();
            if ("database.json" != null)
            {
                using (var sw = new StreamWriter("database.json"))
                {
                    using (var jw = new JsonTextWriter(sw))
                    {
                        jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                        ser.Serialize(jw,database );
                    }
                }
            }
        }

        public static Database ReadJsonDatabase(Database database)

        {
            if (!File.Exists("database.json")) { WriteJson(database); }
            var ser = new Newtonsoft.Json.JsonSerializer();
            using (var sr = new StreamReader("database.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    var db = ser.Deserialize<Database>(jr);
                    return db;
                }
            }
        }

     

        

    }
}
