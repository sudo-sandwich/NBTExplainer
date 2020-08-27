using NBTExplainer.Tags;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NBTExplainer {
    public class Program {
        public static void Main(string[] args) {
            StringBuilder prettyPrinter = new StringBuilder();

            // download test files
            using (WebClient client = new WebClient()) {
                client.DownloadFile("https://raw.github.com/Dav1dde/nbd/master/test/hello_world.nbt", "hello_world.nbt");
                client.DownloadFile("https://raw.github.com/Dav1dde/nbd/master/test/bigtest.nbt", "bigtest.nbt");
            }

            // hello_world.nbt test
            NbtTag helloWorld = NbtParser.ReadFromFile("hello_world.nbt", Endian.Big);
            Console.WriteLine();

            helloWorld.PrettyPrint(prettyPrinter, "  ", 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(prettyPrinter.ToString());
            Console.ForegroundColor = ConsoleColor.White;
            prettyPrinter.Clear();

            // bigtest.nbt test
            NbtTag bigTest = NbtParser.ReadFromFile("bigtest.nbt", Endian.Big);
            Console.WriteLine();

            bigTest.PrettyPrint(prettyPrinter, "  ", 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(prettyPrinter.ToString());
            Console.ForegroundColor = ConsoleColor.White;
            prettyPrinter.Clear();

            /*
            // level.dat test
            NbtTag level = NbtParser.ReadFromFile("level.dat", Endian.Little);
            Console.WriteLine();

            level.PrettyPrint(prettyPrinter, "  ", 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(prettyPrinter.ToString());
            Console.ForegroundColor = ConsoleColor.White;
            prettyPrinter.Clear();
            */

#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}
