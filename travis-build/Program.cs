using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace travis_build
{
    class Program
    {
        static string header = "Dir\tSubDir\tFile\tLength\t(this file is generated)\n";
        static StringBuilder sb = new StringBuilder(header);
            
        static void Main(string[] args)
        {
            // list("../../../", "", Console.WriteLine);

            list("../../../");
            File.WriteAllText("output.tsv", sb.ToString());
            
            sb = new StringBuilder(header)
            list("../../../");
            File.WriteAllText("output3.tsv", sb.ToString());
            
            sb = new StringBuilder(header)
            list("../../");
            File.WriteAllText("output2.tsv", sb.ToString());
            // TODO remove
            //Console.ReadKey();
        }
        
        static void list(string root) 
        {
            foreach (var dir in Directory.GetDirectories(root))
            {
                var dirI = new DirectoryInfo(dir);


                foreach (var subDir in Directory.GetDirectories(dir))
                {
                    var subDirI = new DirectoryInfo(subDir);
                    foreach (var file in Directory.GetFiles(subDir))
                    {
                        var f = new FileInfo(file);
                        if (f.Name.Contains("png"))
                            sb.AppendLine(dirI.Name + "\t" + subDirI.Name + "\t" + f.Name + "\t" + f.Length);
                    }
                }
                foreach (var file2 in Directory.GetFiles(dir))
                {
                    var f2 = new FileInfo(file2);
                    if (f2.Name.Contains("png"))
                        sb.AppendLine(dirI.Name + "\t" + "-"  + "\t" + f2.Name + "\t" + f2.Length);
                }
            }

            Console.WriteLine(root + " => \n\n" + sb);
        }
    }
}
