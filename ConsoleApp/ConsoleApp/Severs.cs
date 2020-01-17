using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Sever
    {
        public void man(User u)
        {
            HttpWebRequest httpWebRequest = WebRequest.Create("http://www.baidu.com") as HttpWebRequest;

            httpWebRequest.Method = "POST";

            using (var requestStream = httpWebRequest.GetRequestStream())
            {
                byte[] data = Encoding.UTF8.GetBytes("Hello");

                requestStream.Write(data, 0, data.Length);
                requestStream.Flush();
            }

            using (HttpWebResponse response = httpWebRequest.GetResponse() as HttpWebResponse)
            {
                using (var responseStream = response.GetResponseStream())
                {
                    byte[] readBuffer = new byte[1000];
                    List<byte> allData = new List<byte>();
                    int readBytes;

                    do
                    {
                        readBytes = responseStream.Read(readBuffer, 0, readBuffer.Length);

                        for (var i = 0; i < readBytes; i++)
                        {
                            allData.Add(readBuffer[i]);
                        }

                    } while (readBytes > 0);//如果readBytes为0表示HttpWebResponse中的所有数据已经被读取完毕

                    string message = Encoding.UTF8.GetString(allData.ToArray());
                    Console.WriteLine(message);
                }
            }
        }
    }
    
}

