using System;
using System.Collections.Generic;
using SocketTcpClient;

public class Bridge
{
    public Floor floor;
    public Bridge() {
        floor = new Floor(); 
    }

    public void DownloadFloor(int FloorNumber)
    {
        Console.Write("Запрашиваю этаж номер: " + FloorNumber);
        floor = new Floor(FloorNumber);
        Console.Write("Этаж получен.\n");
    }

    public Exhibit GetExhibitAt(int ExhibitId)
    {
        Console.Write("Запрашиваю экспонат номер: " + ExhibitId);
        Exhibit res = new Exhibit();
        res.ResiveExhibit(ExhibitId);
        Console.Write("Экспонат получен.\n");
        return res;

    }

    public int Autorization(string login, string pass)
    {
        Console.Write("Авторизация...\n");
        Console.Write("Авторизирован...");
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

    public void ChangeDescription(Exhibit exh, string NEWdescription)
    {
        Console.Write("Меняю...");
        exh.ChangeDescription(NEWdescription);
        Console.Write("Сменил.");
    }

    
}
