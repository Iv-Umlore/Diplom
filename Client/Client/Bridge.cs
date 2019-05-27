using System;
using System.Collections.Generic;
using SocketTcpClient;
using System.Drawing;
using System.Threading;

public struct floore
{
    public int number_of_floor;
    public int id;    
    public string name;
}

public class Bridge
{
    static public char[] separator = { '&','*','&'};

    static public string[] ParseStr(string str, char[] sep = null)
    {
        if (sep == null) sep = separator;
        return str.Split(sep,StringSplitOptions.RemoveEmptyEntries);
    }

    static private byte[] ConvertToByte(Bitmap image, int width, int height)
    {
        byte[] result = new byte[width * height * 3];
        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
            {
                result[3 * (i * height + j)] = image.GetPixel(i, j).R;
                result[3 * (i * height + j) + 1] = image.GetPixel(i, j).G;
                result[3 * (i * height + j) + 2] = image.GetPixel(i, j).B;
            }
        return result;
    }

    static public Bitmap ConvertToBitmap(byte[] image, int width, int height)
    {
        Bitmap result = new Bitmap(width, height);
        int count = 0;
        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++)
            {
                if (j == 160)
                {
                    Console.Write("hello");
                }
                result.SetPixel(i,j,Color.FromArgb(image[3 * (i * height + j)], image[3 * (i * height + j) + 1], image[3 * (i * height + j) + 2]));
                count++;
            }
        }

        return result;
    }

    static public string GetCorrectComandStrings(int code, string[] parameters)
    {
        string result = "";
        result += code;
        if (parameters != null)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                result += "&*&" + parameters[i];
            }
        }
        
        return result;
    }
    
    public Bridge() { }

    public Floor DownloadFloor(int FloorNumber = 1)
    {
        Console.Write("Запрашиваю этаж номер: " + FloorNumber + "\n");
        string[] parameters = new string[1];
        parameters[0] = FloorNumber.ToString();

        string answer = Speaker.Send(GetCorrectComandStrings((int)Commands.GetFloor, parameters));
        
        Floor floor = new Floor(ParseStr(answer));
        Console.Write("Этаж получен.\n");
        return floor;
    }

    public ExhibitSpace GetExhibitSpace(int ESId)
    {
        Console.Write("Запрашиваю следующую точку.\n");
        ExhibitSpace res = new ExhibitSpace(ESId);
        Console.Write("Точка получена.\n");
        return res;
    }

    public Exhibit GetExhibitAt(int ExhibitId)
    {
        Console.Write("Запрашиваю экспонат номер: " + ExhibitId + "\n");
        Exhibit res = new Exhibit(ExhibitId);
        Console.Write("Экспонат получен.\n");
        return res;

    }

    static public void SendImage(Bitmap image, int width, int heigth)
    {

        byte[] b = ConvertToByte(image, width, heigth);
        string[] parameters = new string[2];
        parameters[0] = width.ToString();
        parameters[1] = heigth.ToString();

        Speaker.SendImage(GetCorrectComandStrings((int)Commands.SendImage,parameters),b);
    }

    static public Bitmap GiveImage(int ImageId)
    {
        string[] param = new string[1];
        param[0] = ImageId.ToString();
        Bitmap result = Speaker.ResiveImage(GetCorrectComandStrings((int)Commands.GetImage, param));
        
        return result;
    }

    static public int Autorization(string login, string pass)
    {
        Console.Write("Авторизация...\n");
        string[] parameters = new string[2];
        parameters[0] = login;
        parameters[1] = pass;
        string answer = Speaker.Send(GetCorrectComandStrings((int)Commands.Autorization, parameters));
        Console.Write("Авторизирован..." + "\n");
        return int.Parse(answer);
    }

    static public void AddExhibit(string name, string description)
    {
        Console.Write("Создаю используя полученные параметры...\n");
        Exhibit exh = new Exhibit(name, description);
        Console.Write("Создано. Идёт отправка...\n");
        exh.SendExhibit();
        Console.Write("Отправлено.\n");
        // true/false
    }

    public void DeleteExhibitNumber(int ExhibitNumber)
    {
        Console.Write("Удаляю экспонат номер " + ExhibitNumber + "...\n");
        string[] parameters = new string[1];
        parameters[0] = ExhibitNumber.ToString();
        string answer = Speaker.Send(GetCorrectComandStrings((int)Commands.DeleteExhibitFromDataBase, parameters));
        Console.Write("Удалено.\n");
        // true/false
    }

    public void ChangeExhibit(Exhibit exh)      // уже изменённый
    {
        Console.Write("Меняю..." + "\n");
        exh.SendExhibit();
        Console.Write("Сменил." + "\n");
        // true/false
    }

    static public void SetExhibit(int SpaceId, int ExhibitID)
    {
        string[] parameters = new string[2];
        parameters[0] = SpaceId.ToString();
        parameters[1] = ExhibitID.ToString();
        string answer = Speaker.Send(GetCorrectComandStrings((int)Commands.SetExhibit,parameters));
        // true/false
    }
    
    static public void ResetExhibit(int ExhibitID)
    {
        string[] parameters = new string[1];
        parameters[0] = ExhibitID.ToString();
        string answer = Speaker.Send(GetCorrectComandStrings((int)Commands.ResetExhibit, parameters));
        // true/false
    }

    /*public void ChangeScheme(Scheme schem)
    {

    }*/

    public void AddNewExhibitSpace(int x, int y, int floor)
    {
        ExhibitSpace ES = new ExhibitSpace(x, y, floor);
        ES.SendExhibitSpace();
        // true/false
    }

    public void DeleteExhibitSpase(int SpaceID)
    {
        string[] parameters = new string[1];
        parameters[0] = SpaceID.ToString();
        Speaker.Send(GetCorrectComandStrings((int)Commands.DeleteExhibitSpace, parameters));
        // true/false
    }
    
    static public void AddNewFloor(string name)
    {
        string[] parameters = new string[1];
        parameters[0] = name;
        Speaker.Send(GetCorrectComandStrings((int)Commands.AddFloor, parameters));
    }

    static public void CreateNewScheme(Bitmap Scheme, int width, int heigth)
    {
        string[] parameters = new string[2];
        parameters[0] = width.ToString();
        parameters[1] = heigth.ToString();
        byte[] scheme = ConvertToByte(Scheme, width, heigth);
        Speaker.SendImage(GetCorrectComandStrings((int)Commands.AddNewSchem, parameters), scheme);
    }

    public void DeleteScheme(int SchemeID)
    {
        string[] parameters = new string[1];
        parameters[0] = SchemeID.ToString();
        Speaker.Send(GetCorrectComandStrings((int)Commands.DeleteSchem, parameters));
        // true/false
    }
    
    static public List<floore> GiveValidFloor()
    {
        string answer = Speaker.Send(GetCorrectComandStrings((int)Commands.GiveAllValidFloor, null));
        string[] res = ParseStr(answer);
        floore tmp = new floore();
        List<floore> result = new List<floore>();
        for (int i = 0; i < res.Length; i += 3)
        {
            tmp.id = int.Parse(res[i]);
            tmp.number_of_floor = int.Parse(res[i+1]);
            tmp.name = res[i + 2];
            result.Add(tmp);
        }
        
        return result;
    }

    static public List<floore> GiveUnvalidFloor()
    {
        string answer = Speaker.Send(GetCorrectComandStrings((int)Commands.GiveUnvalidFloor, null));
        string[] res = ParseStr(answer);
        floore tmp = new floore();
        List<floore> result = new List<floore>();
        for (int i = 0; i < res.Length; i += 2)
        {
            tmp.id = int.Parse(res[i]);
            tmp.name = res[i + 1];
            tmp.number_of_floor = 0;
            result.Add(tmp);
        }
        
        return result;
    }

    public string[] GiveAllFloor()
    {
        string answer = Speaker.Send(GetCorrectComandStrings((int)Commands.GiveAllFloor, null));
        string[] res = ParseStr(answer);
        return res;
    }

    static public void CreateManager(string login, string pass)
    {
        string[] parameters = new string[2];
        parameters[0] = login;
        parameters[1] = pass;
        Speaker.Send(GetCorrectComandStrings((int)Commands.CreateManager, parameters));
        
    }

    static public string[] GiveAllManager()
    {
        string answer = Speaker.Send(GetCorrectComandStrings((int)Commands.GiveAllManager, null));
        string[] res = ParseStr(answer);
        return res;
    }
    
    static public Bitmap DownloadScheme(int SchemeID)
    {
        string[] parameters = new string[1];
        parameters[0] = SchemeID.ToString();
        Bitmap res = Speaker.ResiveImage(GetCorrectComandStrings((int)Commands.DownloadSheme, parameters));
        return res;
    }

    static public void AddFloorToValid(int FloorID, int number_of_floor)
    {
        string[] parameters = new string[2];
        parameters[0] = FloorID.ToString();
        parameters[1] = number_of_floor.ToString();
        Speaker.Send(GetCorrectComandStrings((int)Commands.AddFloorToValid, parameters));
        // true/false
    }

    static public void UnvalidFloor(int FloorID)
    {
        string[] parameters = new string[1];
        parameters[0] = FloorID.ToString();
        Speaker.Send(GetCorrectComandStrings((int)Commands.DeleteFloorFromValid, parameters));
        // true/false
    }

    static public void DeleteFloor(int floorID)
    {
        string[] parameters = new string[1];
        parameters[0] = floorID.ToString();
        Speaker.Send(GetCorrectComandStrings((int)Commands.DeleteFloor, parameters));
    }

    static public void DeleteManager(string login)
    {
        string[] parameters = new string[1];
        parameters[0] = login;
        Speaker.Send(GetCorrectComandStrings((int)Commands.DeleteManager, parameters));
        // true/false
    }

    static public void ChangePassword(string login, string pass)
    {
        string[] parameters = new string[2];
        parameters[0] = login;
        parameters[1] = pass;
        Speaker.Send(GetCorrectComandStrings((int)Commands.ChangePassword, parameters));
    }

    static public exh[] GetFreeExh()
    {
        string command = ((int)(Commands.GiveAllFreeExhibit)).ToString();
        command = Speaker.Send(command);
        string[] parseAnsw = ParseStr(command);
        exh[] res = new exh[parseAnsw.Length / 2];
        exh tmp;
        for (int i = 0; i < parseAnsw.Length / 2; i++)
        {
            tmp.exhibit_id = int.Parse(parseAnsw[i * 2]);
            tmp.exhibit_name = parseAnsw[i * 2 + 1];
            res[i] = tmp;
        }
        return res;
    }

}
