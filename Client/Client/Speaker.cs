using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Net;
using System.Net.Sockets;

enum Commands { GetFloor = 1,   
    GetESpace = 2,              
    GetExhibit = 3,             
    Autorization = 4,           
    AddExponatToDataBase = 5,       
    DeleteExhibitFromDataBase = 6,  
    ChangeExhibit = 7,          
    SetExhibit = 8,             // Повесить экспонат
    ResetExhibit = 9,           // Снять экспонат
    ChangeSchem = 10,           // Изменить схему
    EddNewExhibitSpace = 11,    // Добавть новую точку
    DeleteExhibitSpace = 12,    // Удалить точку
    CreateNewSchem = 13,        // Создать новую схему этажа
    DeleteSchem = 14,           // Удалить
    GiveFreeExhibitID = 15,     // Выдать свободный id экспоната
};

namespace SocketTcpClient
{
 
    class Speaker
    {
        // адрес и порт сервера, к которому будем подключаться
        static int port = 1024;                         // порт сервера
        static string address = "127.0.0.1";            // адрес сервера
        const int BufferSize = 1024;                    // Размер буфера обмена
        
        static public string Send(string args)
        {            
            string answer = "";
            Console.Write("\n\n" + args + "\n\n");
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

