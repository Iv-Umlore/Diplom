using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Net;
using System.Net.Sockets;

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
    AddNewSchem = 14,        // Создать новую схему этажа               | ???
    DeleteSchem = 15,           // Удалить                              | +
    GiveFreeExhibitID = 16,     // Выдать свободный id экспоната        | +
    GiveFreeExhibitSpaceID = 17,//                                      | +
    GiveFreeFloorID = 18,       //                                      | +
    GiveAllValidFloor = 19,     // Выдать все действующие этажи         | +
    GiveAllFloor = 20,          // Выдать все этажи                     | +
    CreateManager = 21,         // Запись нового менеджера в БД         | +
    GiveAllManager = 22,        // Показать список менеджеров           | +
    DownloadSheme = 23,         // Загрузить схему этажа                | ???
    AddFloorToValid = 24,       // Добавить этаж как действующий        | +
    DeleteFloorFromValid = 25,  // Удалить                              | +
    DeleteManager = 26,         // Удалить менеджера                    | +
    ChangePassword = 27         // изменить пароль учётной записи       | +
};

namespace SocketTcpClient
{
 
    class Speaker
    {
        // адрес и порт сервера, к которому будем подключаться
        static int port = 1024;                         // порт сервера
        static string address = "127.0.0.1";            // адрес сервера
        const int BufferSize = 256;                    // Размер буфера обмена
        
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
                Console.Write(answer);
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

