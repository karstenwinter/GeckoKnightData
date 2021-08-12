using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travis_build
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = "../../../";
            list(root);

            root = "../../";
            list(root);

            root = "/../";
            list(root);
            // TODO remove
            // Console.ReadKey();
        }

        static void list(string root)
        {
            try
            {
                list2(root);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static void list2(string root)
            {
                var sb = new StringBuilder("Dir\tSubDir\tFile\tLength\t(this file is generated)\t" + root + "\n");
            // list("../../../", "", Console.WriteLine);

            foreach (var dir in Directory.GetDirectories(root))
            {
                var dirI = new DirectoryInfo(dir);


                foreach (var subDir in Directory.GetDirectories(dir))
                {
                    var subDirI = new DirectoryInfo(subDir);
                    foreach (var file in Directory.GetFiles(subDir))
                    {
                        var f = new FileInfo(file);
                        //if (f.Name.Contains("png"))
                            sb.AppendLine(dirI.Name + "\t" + subDirI.Name + "\t" + f.Name + "\t" + f.Length);
                    }
                }
                foreach (var file2 in Directory.GetFiles(dir))
                {
                    var f2 = new FileInfo(file2);
                    if (f2.Name.Contains("png"))
                        sb.AppendLine(dirI.Name + "\t" + "-" + "\t" + f2.Name + "\t" + f2.Length);
                }
            }

            Console.WriteLine(sb);
            File.WriteAllText("output.tsv", sb.ToString());
        }
    }
}
