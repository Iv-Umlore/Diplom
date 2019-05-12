using System;
using System.Collections.Generic;
using SocketTcpClient;

public class Bridge
{
    public Floor floor;
    static public char[] separator = { '&','*','&'};

    static public string[] ParseStr(string str, char[] sep)
    {
        return str.Split(sep,StringSplitOptions.RemoveEmptyEntries);
    }

    static public int GetNextExhibitId()                    // Выдать свободный id Экспоната
    {
        return 1;
    }

    static public int GetNextExhibitSpaceId()               // Выдать свободный id точки расположения
    {
        return 1;
    }

    static public int GetNextFloorId()                      // Выдать свободный id Этажа
    {
        return 1;
    }

    static public string GetCorrectComandStrings(int code, string[] parameters)
    {
        string result = "";
        result += code;
        for (int i = 0; i < parameters.Length; i++)
        {
            result += "&*&" + parameters[i];
        }
        //result += '\0';
        return result;
    }

    public Bridge() {
        floor = new Floor();
        separator = new char[3];
        separator[0] = separator[2] = '&';
        separator[0] = '*';
    }

    public void DownloadFloor(int FloorNumber = 1)
    {
        Console.Write("Запрашиваю этаж номер: " + FloorNumber + "\n");
        string[] parameters = new string[1];
        parameters[0] = FloorNumber.ToString();

        string answer = Speaker.Send(GetCorrectComandStrings((int)Commands.GetFloor, parameters));

        floor = new Floor(answer.Split(separator));
        Console.Write("Этаж получен.\n");
    }

    public Exhibit GetExhibitAt(int ExhibitId)
    {
        Console.Write("Запрашиваю экспонат номер: " + ExhibitId + "\n");
        Exhibit res = new Exhibit(ExhibitId);
        Console.Write("Экспонат получен.\n");
        return res;

    }

    public int Autorization(string login, string pass)
    {
        Console.Write("Авторизация...\n");
        Console.Write("Авторизирован..." + "\n");
        return 2;
    }

    public void AddExhibit(string name, string description, List<string> links, int Xcoord, int Ycoord)
    {
        Console.Write("Создаю используя полученные параметры...\n");
        Exhibit exh = new Exhibit(name, description, links, Xcoord, Ycoord);
        Console.Write("Создано. Идёт отправка...\n");
        exh.SendExhibit();
        Console.Write("Отправлено.\n");
    }

    public void DeleteExhibitNumber(int ExhibitNumber)
    {
        Console.Write("Удаляю экспонат номер " + ExhibitNumber + "...\n");
        // Вызвать функцию
        Console.Write("Отправлено.\n");
    }

    public void ChangeExhibit(Exhibit exh)
    {
        Console.Write("Меняю..." + "\n");
        exh.SendExhibit();
        Console.Write("Сменил." + "\n");
    }

    
}
