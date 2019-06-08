using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using System.IO;
using System.Threading;

enum Commands { GetFloor = 1,   //                                      | +
    GetESpace = 2,              //                                      | +
    GetExhibit = 3,             //                                      | +
    GetImage = 4,               //                                      | ???
    Autorization = 5,           //                                      | +   
    AddExponatToDataBase = 6,   //                                      | +                          
    DeleteExhibitFromDataBase = 7, //                                   | +
    ChangeExhibit = 8,          //                                      | +
    SetExhibit = 9,             // Повесить экспонат                    | +
    ResetExhibit = 10,          // Снять экспонат                       | +
    ChangeSchem = 11,           // Изменить схему                       | ???
    AddNewExhibitSpace = 12,    // Добавть новую точку                  | +
    DeleteExhibitSpace = 13,    // Удалить точку                        | +
    AddNewSchem = 14,           // Создать новую схему этажа               | ???
    DeleteSchem = 15,           // Удалить                              | +
    AddFloor = 16,              // Выдать свободный id экспоната        | +
    GiveUnvalidFloor = 17,      //  Выдать неиспользуемые этажи         | +
    GiveAllFreeExhibit = 18,    //                                      | +
    GiveAllValidFloor = 19,     // Выдать все действующие этажи         | +
    GiveAllFloor = 20,          // Выдать все этажи                     | +
    CreateManager = 21,         // Запись нового менеджера в БД         | +
    GiveAllManager = 22,        // Показать список менеджеров           | +
    DownloadSheme = 23,         // Загрузить схему этажа                | ???
    AddFloorToValid = 24,       // Добавить этаж как действующий        | +
    DeleteFloorFromValid = 25,  // Удалить                              | +
    DeleteManager = 26,         // Удалить менеджера                    | +
    ChangePassword = 27,        // изменить пароль учётной записи       | +
    SendImage = 28,              // Отправить изображение
    DeleteFloor = 29,
    ChangeFloor = 30,
};

namespace SocketTcpClient
{
 
    class Speaker
    {
        // адрес и порт сервера, к которому будем подключаться
        static int port = 1024;                         // порт сервера
        //static string address = "192.168.0.101";        // Адрес внутри сети
        //static string address = "109.201.126.140";        // подключение по внешнему ip
        static string address = "127.0.0.1";           // localhost
        const int BufferSize = 256;                     // Размер буфера обмена
        
        static public string Send(string args)
        {            
            string answer = "";
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // подключаемся к удаленному хосту
                socket.Connect(ipPoint);
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
                
                // закрываем сокет
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                
                answer = builder.ToString();
                Console.Write(answer + '\n');
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
            return answer;
        }

        static public void SendImage(string command, byte[] bitmap)
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // подключаемся к удаленному хосту
            socket.Connect(ipPoint);

            byte[] data = Encoding.Unicode.GetBytes(command);
            socket.Send(data);
            Thread.Sleep(40);
            data = bitmap;
            socket.Send(data);

            data = new byte[BufferSize]; // буфер для ответа
            StringBuilder builder = new StringBuilder();
            int bytes = 0; // количество полученных байт

            do
            {
                bytes = socket.Receive(data, data.Length, 0);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (socket.Available > 0);

            // закрываем сокет
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }

		static public Bitmap ResiveImage(string command)
		{

			IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

			Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			// подключаемся к удаленному хосту
			socket.Connect(ipPoint);

			byte[] data = Encoding.Unicode.GetBytes(command);
			socket.Send(data);

			// получаю размер

			data = new byte[BufferSize]; // буфер для ответа

			StringBuilder builder = new StringBuilder();
			int bytes = 0; // количество полученных байт

			do
			{
				bytes = socket.Receive(data, data.Length, 0);
				builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
			}
			while (socket.Available > 0);

			string answer = builder.ToString();
			builder.Clear();
			string[] split = Bridge.ParseStr(answer);

			int width = int.Parse(split[0]);
			string str = "";
			int k = 0;
			while (k < split[1].Length && split[1][k] <= '9' && split[1][k] >= '0') { 
				str += split[1][k];
				k++;
			}

			int heigth = int.Parse(str);

            data = new byte[2048];
            byte[] image = new byte[width * heigth * 3];
			for (int i = 0; i < image.Length; i++)
				image[i] = 130;
            int pos = 0;
			Thread.Sleep(image.Length/6144);
			int count = 0;
				do
				{
				count = 0;
					
					socket.Receive(data, data.Length, 0);
					
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (pos < image.Length) image[pos] = data[i];
                        pos++;
                    }

						Thread.Sleep(2);
				} while (socket.Available > 0);

			Bitmap BM = Bridge.ConvertToBitmap(image, width, heigth);

            data = new byte[BufferSize]; // буфер для ответа
            
            bytes = 0; // количество полученных байт

            do
            {
                bytes = socket.Receive(data, data.Length, 0);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (socket.Available > 0);
            answer = builder.ToString();
            builder.Clear();
            // закрываем сокет
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();

            return BM;

        }

    }
}

