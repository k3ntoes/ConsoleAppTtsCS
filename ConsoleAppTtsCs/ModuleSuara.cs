using SpeechLib;
using System;
using System.IO;
using System.Media;
using Newtonsoft.Json;
using System.Threading;

namespace ConsoleAppTtsCs
{
    class ModuleSuara
    {
        private SoundPlayer player = new SoundPlayer();
        private SpVoice voice;
        private string path = @"Sound";
        private RootObject jJson;

        public ModuleSuara()
        {
            this.jJson = readConfig();
        }

        private RootObject readConfig()
        {
            string fJson = File.ReadAllText(@"cn.json");
            return JsonConvert.DeserializeObject<RootObject>(fJson);
        }

        private SpVoice ConfVoice()
        {
            voice = new SpVoice();
            voice.Voice = voice.GetVoices().Item(jJson.confVocalizer.indVocalizer);
            voice.Rate = jJson.confVocalizer.rate;
            voice.Volume = jJson.confVocalizer.volume;
            
            return voice;
        }

        public void listVocalizer()
        {
            voice = new SpVoice();
            int i = 0;
            foreach(ISpeechObjectToken token in voice.GetVoices(string.Empty, string.Empty))
            {
                Console.WriteLine(i.ToString() + " : " + token.GetDescription());
                i++;
            }
        }

        public void suara(string kata)
        {
            voice = ConfVoice();
            //Bunyi
            player.PlaySync();
            voice.Speak(kata);
        }

        public void suaraToFile(string kata, string fname)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            voice = ConfVoice();

            SpeechStreamFileMode spFileMode = SpeechStreamFileMode.SSFMCreateForWrite;
            SpFileStream spFs = new SpFileStream();
            spFs.Open(path + "/" + fname + ".wav", spFileMode, false);
            voice.AudioOutputStream = spFs;
            voice.Speak(kata, SpeechVoiceSpeakFlags.SVSFlagsAsync);
            voice.WaitUntilDone(Timeout.Infinite);
            spFs.Close();
        }

        public void suaraToLZString(string kata)
        {
            suaraToFile(kata, "temp");
            path = @"Sound/temp.wav";
            Byte[] bytes = File.ReadAllBytes(path);
            String file = Convert.ToBase64String(bytes);
            string compressed = LZStringCSharp.LZString.CompressToEncodedURIComponent(file);
            Console.WriteLine(compressed);
        }
    }
}
