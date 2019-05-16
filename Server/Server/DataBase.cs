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

    /*static Bitmap GetImage(int ImageID)
    {
        return
    }*/

    static public int Autorization(string login, string pass)
    {
        return 1;
    }

    static public bool AddExponatToDataBase(string[] Exhib)
    {
        return true;
    }

    static public bool DeleteExhibitFromDataBase(int ExhID)
    {
        return true;
    }

    static public bool ChangeExhibit(string[] Exhib)
    {
        return true;
    }

    static public bool SetExhibit(int ExhibSpaceID, int ExhibID)
    {
        return true;
    }

    static public bool ResetExhibit(int ExhibID)
    {
        return true;
    }

    /*static public bool ChangeSchem(Bitmap BM)
    {

    }*/
    static public bool AddNewExhibitSpace(int ExhibSpaceID, int x, int y)
    {
        return true;
    }

    static public bool DeleteExhibitSpace(int ExhibSpaceID)
    {
        return true;
    }

    /*static public bool AddNewSchem(Bitmap BM)
    {

    }*/

    static public bool DeleteSchem(int SchemeID)
    {
        return true;
    }

    static public int GiveFreeExhibitID()
    {
        return 1;
    }

    static public int GiveFreeExhibitSpaceID()
    {
        return 1;
    }

    static public int GiveFreeFloorID()
    {
        return 1;
    }

    static public string[] GiveAllValidFloor()
    {
        string[] res = new string[1];
        return res;
    }

    static public string[] GiveAllFloor()
    {
        string[] res = new string[1];
        return res;
    }

    static public bool CreateManager(string login, string pass)
    {
        return true;
    }
    static public string[] GiveAllManager()
    {
        string[] res = new string[1];
        return res;
    }

    /*static public Bitmap DownloadSheme(int SchemeID)
    {

    }*/

    static public bool AddFloorToValid(int FloorID)
    {
        return true;
    }

    static public bool DeleteFloorFromValid(int FloorID)
    {
        return true;
    }

    static public bool DeleteManager(string login)
    {
        return true;
    }

    static public bool ChangePassword(string login, string pass)
    {
        return true;
    }

}
