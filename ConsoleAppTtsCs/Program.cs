using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTtsCs
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ModuleSuara ms = new ModuleSuara();

            if (args.Length == 0 || args[0] == "-h")
            {
                help_msg();
            }
            else if (args.Length == 1)
            {
                if (args[0] == "-l")
                {
                    ms.listVocalizer();        
                }
            }
            else
            {
                if (args[0] == "-p")
                {
                    ms.suara(args[1]);
                }
                else if(args[0] == "-f")
                {
                    ms.suaraToFile(args[1], args[2]);
                }
                else if (args[0] == "-c")
                {
                    ms.suaraToLZString(args[1]);
                }
                else
                {
                    help_msg();
                }
            }

        }

        private static void help_msg()
        {
            Console.WriteLine("-l : Show List Of Vocalizer");
            Console.WriteLine("-p : Playing Sound Example : -p \"Text What You Want to speech\"");
            Console.WriteLine("-f : Generate.wav file Example : -f \"Text What You Want to speech\" \"file_name\"");
            Console.WriteLine("-c : Compress file to LZ string Example : -c \"Text What You Want to speech\"");
        }
    }
}
