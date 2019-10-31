using Newtonsoft.Json.Linq;

namespace ConsoleAppTtsCs
{
    class CsJson
    {
        JObject host;

        internal JObject Host { get => host; set => host = value; }
    }

    public class Host
    {
        public string url { get; set; }
        public string uri_panggil_poli { get; set; }
    }

    public class ConfVocalizer
    {
        public int indVocalizer { get; set; }
        public int rate { get; set; }
        public int pitch { get; set; }
        public int volume { get; set; }
    }

    public class RootObject
    {
        public Host host { get; set; }
        public ConfVocalizer confVocalizer { get; set; }
    }
}