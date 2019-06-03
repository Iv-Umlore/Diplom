using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

enum Commands
{
    GetFloor = 1,               //                                      | + | + |
    GetESpace = 2,              //                                      | + | + |
    GetExhibit = 3,             //                                      | + | + |
    GetImage = 4,               //                                      | ???
    Autorization = 5,           //                                      | + | + |
    AddExponatToDataBase = 6,   //                                      | + | + |                        
    DeleteExhibitFromDataBase = 7, //                                   | + | + |
    ChangeExhibit = 8,          //                                      | +
    SetExhibit = 9,             // Повесить экспонат                    | + | + |
    ResetExhibit = 10,          // Снять экспонат                       | + | + |
    ChangeSchem = 11,           // Изменить схему                       | ???
    AddNewExhibitSpace = 12,    // Добавть новую точку                  | + | + |
    DeleteExhibitSpace = 13,    // Удалить точку                        | + | + |
    AddNewSchem = 14,           // Добавить новую схему этажа           | ???
    DeleteSchem = 15,           // Удалить                              | + | + |
    AddFloor = 16,              // Создать новый этаж     
    GiveUnvalidFloor = 17,      //                                      | + | + |
    GiveAllFreeExhibit = 18,    // Выдать все свободные экспонаты       | + | + |
    GiveAllValidFloor = 19,     // Выдать все действующие этажи         | + | + |
    GiveAllFloor = 20,          // Выдать все этажи                     | + | + |
    CreateManager = 21,         // Запись нового менеджера в БД         | + | + |
    GiveAllManager = 22,        // Показать список менеджеров           | + | + |
    DownloadSheme = 23,         // Загрузить схему этажа                | ???
    AddFloorToValid = 24,       // Добавить этаж как действующий        | + | + |
    DeleteFloorFromValid = 25,  // Удалить                              | + | + |
    DeleteManager = 26,         // Удалить менеджера                    | + | + |
    ChangePassword = 27,        // изменить пароль учётной записи       | + | + |
    SaveImage = 28,             // Принять изображение                  | + | + |
    DeleteFloor = 29,
    ChangeFloor = 30

};

public class Bridge
{
    char[] separator = { '&', '*', '&' };
    DataBase DB;
    bool update = false;
    public Bridge()
	{
        DB = new DataBase();
	}

    private string PutTogether(string[] DBanswer)
    {
        string result = "";
        string sep = "&*&";
        result += DBanswer[0];
        for (int i = 1; i < DBanswer.Length; i++)
        {
            result += sep + DBanswer[i];
        }

        return result;
    }

    public string ExecuteTheCommand(string command, Socket handler = null)
    {
        string[] split = command.Split(separator,StringSplitOptions.RemoveEmptyEntries);
        string[] result = null;
        Console.Write("\nCommand code: " + split[0]);
        switch (int.Parse(split[0]))
        {
            case (int)Commands.GetFloor:  {
                    result = DB.GetFloor(int.Parse(split[1]));
                    break;
                }
            case (int)Commands.GetESpace: {
                    result = DB.GetESpace(int.Parse(split[1]));
                    break;
                }
            case (int)Commands.GetExhibit: {
                    result = DB.GetExhibit(int.Parse(split[1]));
                    break;
                }
            case (int)Commands.GetImage:
                {
                    
                    result = new string[1];
                    result[0] = true.ToString();

                    byte[] image = DB.GetImage(int.Parse(split[1]));

                    string message = DB.width + "&*&" + DB.height;
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    handler.Send(data);
                    Thread.Sleep(10);
                    handler.Send(image);

                    break;
                }
            case (int)Commands.Autorization: {
                    result = new string[1];
                    result[0] = DB.Autorization(split[1], split[2]).ToString();
                    break;
                }
            case (int)Commands.AddExponatToDataBase: {
                    result = new string[1];
                    result[0] = DB.AddExponatToDataBase(split).ToString();
                    break;
                }
            case (int)Commands.DeleteExhibitFromDataBase: {
                    result = new string[1];
                    result[0] = DB.DeleteExhibitFromDataBase(int.Parse(split[1])).ToString();
                    break;
                }
            case (int)Commands.ChangeExhibit: {
                    result = new string[1];
                    result[0] = DB.ChangeExhibit(split).ToString();
                    break;
                }
            case (int)Commands.SetExhibit: {
                    result = new string[1];
                    result[0] = DB.SetExhibit(int.Parse(split[1]), int.Parse(split[2])).ToString();
                    break;
                }
            case (int)Commands.ResetExhibit: {
                    result = new string[1];
                    result[0] = DB.ResetExhibit(int.Parse(split[1])).ToString();
                    break;
                }

            case (int)Commands.ChangeSchem: {
                    byte[] data = new byte[int.Parse(split[1]) * int.Parse(split[2]) * 3]; // буфер для получаемых данных

                    do
                    {
                        handler.Receive(data);
                    }
                    while (handler.Available > 0);
                    result = new string[1];
                    result[0] = DB.ChangeSchem(data, int.Parse(split[3])).ToString();
                    break;
                }

            case (int)Commands.AddNewExhibitSpace: {
                    result = new string[1];
                    result[0] = DB.AddNewExhibitSpace(int.Parse(split[1]), int.Parse(split[2]), int.Parse(split[3])).ToString();
                    break;
                }

            case (int)Commands.DeleteExhibitSpace:
                {
                    result = new string[1];
                    result[0] = DB.DeleteExhibitSpace(int.Parse(split[1])).ToString();
                    break;
                }

            case (int)Commands.AddNewSchem:
                {
                    byte[] image = new byte[int.Parse(split[1]) * int.Parse(split[2]) * 3]; // буфер для получаемых данных
                    byte[] data = new byte[2048];
                    int pos = 0;
                    do
                        {
                            handler.Receive(data, data.Length, 0);
                            for (int i = 0; i < data.Length; i++)
                            {
                                if (pos < image.Length) image[pos] = data[i];
                                pos++;
                            }
                            //Thread.Sleep(4);
                        } while (handler.Available > 0);
                    result = new string[1];
                    result[0] = DB.AddScheme(data, int.Parse(split[1]), int.Parse(split[2])).ToString();
                    break;
                }

            case (int)Commands.DeleteSchem:
                {
                    result = new string[1];
                    result[0] = DB.DeleteSchem(int.Parse(split[1])).ToString();
                        break;
                }
            case (int)Commands.AddFloor:
                {
                    result = new string[1];
                    result[0] = DB.AddFloor(split[1]).ToString();
                    break;
                }

            case (int)Commands.GiveUnvalidFloor:
                {
                    result = DB.GiveUnvalidFloor();
                    break;
                }

            case (int)Commands.GiveAllFreeExhibit:
                {
                    result = DB.GiveAllFreeExhibit();
                        break;
                }

            case (int)Commands.GiveAllValidFloor:
                {
                    result = DB.GiveAllValidFloor();
                    break;
                }

            case (int)Commands.GiveAllFloor:
                {
                    result = DB.GiveAllFloor();
                    break;
                }

            case (int)Commands.CreateManager:
                {
                    result = new string[1];
                    result[0] = DB.CreateManager(split[1], split[2]).ToString();
                        break;
                }

            case (int)Commands.GiveAllManager:
                {
                    result = DB.GiveAllManager();
                        break;
                }

            case (int)Commands.DownloadSheme:
                {

                    result = new string[1];
                    result[0] = true.ToString();

                    byte[] image = DB.DownloadSheme(int.Parse(split[1]));

                    string message = DB.width + "&*&" + DB.height;
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    handler.Send(data);
                    Thread.Sleep(10);
                    handler.Send(image);

                    break;
                }

            case (int)Commands.AddFloorToValid:
                {
                    result = new string[1];
                    result[0] = DB.AddFloorToValid(int.Parse(split[1]),int.Parse(split[2])).ToString();
                    break;
                }

            case (int)Commands.DeleteFloorFromValid:
                {
                    result = new string[1];
                    result[0] = DB.DeleteFloorFromValid(int.Parse(split[1])).ToString();
                        break;
                }

            case (int)Commands.DeleteManager:
                {
                    result = new string[1];
                    result[0] = DB.DeleteManager(split[1]).ToString();
                        break;
                }

            case (int)Commands.ChangePassword:
                {
                    result = new string[1];
                    result[0] = DB.ChangePassword(split[1],split[2]).ToString();
                    break;
                }

            case (int)Commands.SaveImage:
                {
                    byte[] image = new byte[int.Parse(split[1]) * int.Parse(split[2]) * 3]; // буфер для получаемых данных
                    byte[]data = new byte[2048];
                    int pos = 0;
                        do
                        {
                            handler.Receive(data, data.Length, 0);
                            for (int i = 0; i < data.Length; i++)
                            {
                                if (pos < image.Length) image[pos] = data[i];
                                pos++;
                            }

                            Thread.Sleep(4);
                        } while (handler.Available > 0);
                    
                    result = new string[1];
                    result[0] = DB.SaveImage(image, int.Parse(split[1]), int.Parse(split[2])).ToString();
                    break;
                }

            case (int)Commands.DeleteFloor:
                {
                    result = new string[1];
                    DB.DeleteFloor(int.Parse(split[1]));
                    result[0] = true.ToString();
                    break;
                }


            case (int)Commands.ChangeFloor:
                {                 
                    DB.ChangeFloor(int.Parse(split[1]), split[2]);
                    result = new string[1];
                    result[0] = true.ToString();
                    break;
                }
            

            default: {
                    Console.Write("Такой команды не существует");
                    break;
                }
        }


        return PutTogether(result);
    }
}
