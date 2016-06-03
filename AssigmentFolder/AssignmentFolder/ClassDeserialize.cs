using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentFolder
{
    class ClassDeserialize
    {
        int file = 0;
        int directory = 1;
        public void SaveFolder(string path)
        {
            
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream("folder.dat", FileMode.Open, FileAccess.Read))
            {
                string[][] arrayPaths = (string[][])formatter.Deserialize(stream);
                byte[][] arrayFile = (byte[][])formatter.Deserialize(stream);
                                
                for (int i = 0; i < arrayPaths[directory].Length; i++)
                {
                    Directory.CreateDirectory(path + arrayPaths[directory][i]);
                }

                for (int i = 0; i < arrayFile.Length; i++)
                {
                    File.WriteAllBytes(path + arrayPaths[file][i], arrayFile[i]);
                }
                stream.Close();
            }
        }
    }
}
