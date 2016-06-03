using System.IO;


namespace AssignmentFolder
{
    class ByteConverter
    {
        public void SetByteArray(byte[][] array, string[] arrayFiles, int count)
        {
            for (int i = 0; i < count; i++)
            {
                using (FileStream stream = new FileStream(arrayFiles[i], FileMode.Open, FileAccess.Read))
                {
                    array[i] = new byte[stream.Length];
                    for (long j = 0; j < array[i].LongLength; j++)
                    {
                        array[i][j] = (byte)stream.ReadByte();
                    }
                    stream.Close();
                }
            }
        }
    }
}
