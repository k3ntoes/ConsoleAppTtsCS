using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ConsoleAppTtsCs
{
    class ModuleMain
    {
        RootObject jJson;

        private RootObject readConfig() { 
            string fJson = File.ReadAllText(@"cn.json");
            return JsonConvert.DeserializeObject<RootObject>(fJson);
        }
        
        public string getUrl()
        {
            jJson = readConfig();
            return jJson.host.url;
        }

        public int getIndVocalizer()
        {
            jJson = readConfig();
            return jJson.confVocalizer.indVocalizer;
        }


    }
}
