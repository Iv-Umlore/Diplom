using System;

public class DataBase
{
	static public string[] GetFloor(int number)
    {
        // Здесь будет обращение к БД
        string[] res = new string[3];
        int id = 5;
        res[0] = id.ToString();
        res[1] = "Floor Name";
        id = 2;
        res[2] = id.ToString();
        Console.Write("Выдаю этаж\n");
        return res;
    }

    static public string[] GetESpace(int number)
    {
        // Здесь будет обращение к БД
        string[] res = new string[3];
        int id = 2;
        res[0] = id.ToString();
        res[1] = id.ToString();
        id = 3;
        res[2] = id.ToString();
        Console.Write("Выдаю Точку\n");
        return res;
    }

    static public string[] GetExhibit(int number)
    {
        // Здесь будет обращение к БД
        string[] res = new string[4];
        int id = 2;
        res[0] = "Имя Экспоната";
        res[1] = "Описание этого экспоната может быть достаточно большим";
        res[2] = id.ToString();     // число ссылок на фотографии
        res[3] = "https:\\a.ru|||https:\\b.ru"; // ссылки поочерёдно, разделяя |||
        Console.Write("Выдаю экспонат\n");
        return res;
    }

}
