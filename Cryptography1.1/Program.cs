using System;
using System.IO;
using System.Text.RegularExpressions;

namespace МетодПростойЗамены
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathKey = "key.txt";
            string inputPath = "input.txt";
            string outputPath = "output.txt";
            File.WriteAllText(outputPath, String.Empty);

            char[] res = new char[1];
            char[] arrayKey = new char[33];
            char[] cipher = new char[11000];
            string text;

            int n = 33;
            char[] abc = new char[n];
            int j = 0;
            for (int i = 'а'; i <= 'е'; i++)
            {
                abc[j] = (char)i;
                j++;
            }
            abc[j] = 'ё';
            j++;
            for (int i = 'ж'; i <= 'я'; i++)
            {
                abc[j] = (char)i;
                j++;
            }

            int k = 0;

            using (StreamReader sr = new StreamReader(pathKey, System.Text.Encoding.UTF8)) //reading the key
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    res = line.ToCharArray();
                    arrayKey[k] = res[0];
                    k++;
                }
            }

            using (StreamReader sr = new StreamReader(inputPath, System.Text.Encoding.UTF8)) //reading the text
            {
                text = sr.ReadToEnd();
            }

            text = text.ToLower();
            text = text.Replace(" ", "");
            text = Regex.Replace(text, "(?i)[^А-ЯЁ]", "");
            cipher = text.ToCharArray();

            for (int l = 0; l < text.Length; l++)
            {
                for (int m = 0; m < 33; m++)
                {
                    if (cipher[l] == abc[m])
                    {
                        cipher[l] = arrayKey[m];
                        break;
                    }
                }
            }


                for (int l = 0; l < cipher.Length; l++)
                    using (StreamWriter stream = new StreamWriter(outputPath, true, System.Text.Encoding.UTF8))
                        stream.Write(cipher[l]);
        }
    }
}
