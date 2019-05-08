﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Net;
using System.Net.Sockets;



namespace SocketTcpClient
{    

    class Speaker
    {
        // адрес и порт сервера, к которому будем подключаться
        static int port = 1024;                         // порт сервера
        static string address = "127.0.0.1";            // адрес сервера
        const int BufferSize = 1024;                    // Размер буфера обмена

        static public int GetNextExhibitId()            // Выдать свободный id Экспоната
        {
            return 1;
        }

        static public int GetExhibitCountAt(int FlooreNumber)   // Выдать число экспонатов на этаже
        {

            return 1;
        }

        static public string Send(string args)
        {
            string answer = "";
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // подключаемся к удаленному хосту
                socket.Connect(ipPoint);
                // Console.Write("Введите сообщение:");
                byte[] data = Encoding.Unicode.GetBytes(args);
                socket.Send(data);
                
                // получаем ответ
                data = new byte[BufferSize]; // буфер для ответа
                StringBuilder builder = new StringBuilder();
                int bytes = 0; // количество полученных байт
                
                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);
                // Console.WriteLine("\n\n");
                // Console.WriteLine("ответ сервера: " + builder.ToString());
                
                // закрываем сокет
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();

                answer = builder.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
            return answer;
        }

    }
}
