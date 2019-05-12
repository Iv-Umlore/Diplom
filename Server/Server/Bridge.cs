using System;

enum Commands
{
    GetFloor = 1,
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

public class Bridge
{
    char[] separator = { '&', '*', '&' };
    public Bridge()
	{
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
        Console.Write(result);
        return result;
    }

    public string ExecuteTheCommand(string command)
    {
        string[] split = command.Split(separator,StringSplitOptions.RemoveEmptyEntries);
        string[] result = null;
        switch (int.Parse(split[0]))
        {
            case (int)Commands.GetFloor:  {
                    result = DataBase.GetFloor(int.Parse(split[1]));
                    break;
                }
            case (int)Commands.GetESpace: {
                    result = DataBase.GetESpace(int.Parse(split[1]));
                    break;
                }
            case 3: {
                    result = DataBase.GetExhibit(int.Parse(split[1]));
                    break;
                }
            case (int)Commands.Autorization: { break; }
            case (int)Commands.AddExponatToDataBase: { break; }
            case (int)Commands.DeleteExhibitFromDataBase: { break; }
            case (int)Commands.ChangeExhibit: { break; }
            case (int)Commands.SetExhibit: { break; }
            case (int)Commands.ResetExhibit: { break; }
            case (int)Commands.ChangeSchem: { break; }
            case (int)Commands.EddNewExhibitSpace: { break; }
            case (int)Commands.DeleteExhibitSpace: { break; }
            case (int)Commands.CreateNewSchem: { break; }
            case (int)Commands.DeleteSchem: { break; }
            case (int)Commands.GiveFreeExhibitID: { break; }
            default: {
                    Console.Write("Такой команды не существует");
                    break;
                }
        }


        return PutTogether(result);
    }
}
