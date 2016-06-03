using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentFolder
{
    class ClassSerialize
    {
        public void SaveToBinaryFile(string path)
        {        
            int pathLength = path.Length;
            

            int countFiles = Directory.GetFiles(path, "*", SearchOption.AllDirectories).Length;
            byte[][] arrayByteFiles = new byte[countFiles][];

            string[] arrayFiles = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            string[] arrayDirectories = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
            string[][] arrayString = new string[2][];

            
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream streamWrite = File.Create("Folder.dat"))
            {
                new ByteConverter().SetByteArray(arrayByteFiles, arrayFiles, countFiles);


                RemovePathLength(arrayFiles, pathLength);
                RemovePathLength(arrayDirectories, pathLength);
                arrayString[0] = arrayFiles;
                arrayString[1] = arrayDirectories;


                formatter.Serialize(streamWrite, arrayString);
                formatter.Serialize(streamWrite, arrayByteFiles);

                streamWrite.Close();
            }
        }


        private static void RemovePathLength(string[] array,int pathLength)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i].Remove(0, pathLength);
            }            
        }        
    }
}
