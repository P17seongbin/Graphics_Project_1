using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBJ_MAKER
{
    public class Object4D
    {
        public List<Tuple<float, float, float, float, float>> v;
        public List<Tuple<float, float, float, float, float>> n;
        public List<Tuple<float, float, float>> f;
    }
    class HyperCube : Object4D
    {
        HyperCube()
        {
            v.Add(new Tuple<float, float, float, float, float>(0, 0, 0, 0, 1));//0
            v.Add(new Tuple<float, float, float, float, float>(1, 0, 0, 0, 1));//1
            v.Add(new Tuple<float, float, float, float, float>(0, 1, 0, 0, 1));//2
            v.Add(new Tuple<float, float, float, float, float>(1, 1, 0, 0, 1));//3
            v.Add(new Tuple<float, float, float, float, float>(0, 0, 1, 0, 1));//4
            v.Add(new Tuple<float, float, float, float, float>(1, 0, 1, 0, 1));//5
            v.Add(new Tuple<float, float, float, float, float>(0, 1, 1, 0, 1));//6
            v.Add(new Tuple<float, float, float, float, float>(1, 1, 1, 0, 1));//7

            v.Add(new Tuple<float, float, float, float, float>(0, 0, 0, 1, 1));//8
            v.Add(new Tuple<float, float, float, float, float>(1, 0, 0, 1, 1));//9
            v.Add(new Tuple<float, float, float, float, float>(0, 1, 0, 1, 1));//10
            v.Add(new Tuple<float, float, float, float, float>(1, 1, 0, 1, 1));//11
            v.Add(new Tuple<float, float, float, float, float>(0, 0, 1, 1, 1));//12
            v.Add(new Tuple<float, float, float, float, float>(1, 0, 1, 1, 1));//13
            v.Add(new Tuple<float, float, float, float, float>(0, 1, 1, 1, 1));//14
            v.Add(new Tuple<float, float, float, float, float>(1, 1, 1, 1, 1));//15

        }
    }
    class Obj_maker
    {
        static void Main()
        {
            string docpath = System.IO.Directory.GetCurrentDirectory();
            Console.WriteLine(docpath);
        }
        void Write()
        {
            string docPath = System.IO.Directory.GetCurrentDirectory();
            Console.WriteLine(docpath);
            
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt")))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }
            
        }
    }
}
