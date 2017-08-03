using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Program progran = new Program();
            //char[] MidCharData=new char[1000];
            Function content = new Function();
            content.ReadAndWrite();
        }
    }
    class Function
    {
        char[] MidCharData = new char[1000];
        public void ReadAndWrite()
        {
            
            byte[] byData = new byte[1000];
            char[] charData = new char[1000];
            try
            {
                FileStream file = new FileStream(@"C:\Users\Lzhou\Desktop\\新建文本文档.txt", FileMode.Open);
                file.Seek(0, SeekOrigin.Begin);
                file.Read(byData, 0, 1000);/*byData传进来的字节数组,用以接受FileStream对象中的数据,第2个参数是字节数组中开始写入数据的位置,
                它通常是0,表示从数组的开端文件中向数组写数据,最后一个参数规定从文件读多少字符.*/
                Decoder d = Encoding.Default.GetDecoder();
                d.GetChars(byData, 0, byData.Length, charData, 0);
                MidCharData = charData;
                Console.WriteLine(charData);
                file.Close();
                FileStream fs = new FileStream(@"C:\Users\Lzhou\Desktop\\ak.txt", FileMode.Create);
                //获得字节数组
                byte[] data = System.Text.Encoding.Default.GetBytes(MidCharData);
                //开始写入
                fs.Write(data, 0, data.Length);
                //清空缓冲区、关闭流
                fs.Flush();
                fs.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}
