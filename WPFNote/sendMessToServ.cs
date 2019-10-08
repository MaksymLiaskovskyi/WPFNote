using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace WPFNote
{
    static class tcpSocket
    {
        const string ip = "127.0.0.1";
        const int port = 8080;


        public static string send(string text)
        {
            // даю точку обращения (информацию для обращения)
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            //создаю сокет для ip4, потоковой передачи данных и использование протокола TCP
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            var data = Encoding.UTF8.GetBytes(text);
            tcpSocket.Connect(tcpEndPoint);

            tcpSocket.Send(data);

            var buffer = new byte[256]; // заданый буфер для приема данных
            var size = 0;
            var answer = new StringBuilder();

            do
            {
                size = tcpSocket.Receive(buffer); // записывает реальное количество полученных байт
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size)); // берет большую строку по 256 символов
            } while (tcpSocket.Available > 0);

            return answer.ToString();

            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();
        }
    }
}
