using System;

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
    //GiveFreeExhibitID = 16,     // Выдать свободный id экспоната      
    //GiveFreeExhibitSpaceID = 17,//                                    
    //GiveFreeFloorID = 18,       //                                    
    GiveAllValidFloor = 19,     // Выдать все действующие этажи         | + | + |
    GiveAllFloor = 20,          // Выдать все этажи                     | + | + |
    CreateManager = 21,         // Запись нового менеджера в БД         | + | + |
    GiveAllManager = 22,        // Показать список менеджеров           | + | + |
    DownloadSheme = 23,         // Загрузить схему этажа                | ???
    AddFloorToValid = 24,       // Добавить этаж как действующий        | + | + |
    DeleteFloorFromValid = 25,  // Удалить                              | + | + |
    DeleteManager = 26,         // Удалить менеджера                    | + | + |
    ChangePassword = 27         // изменить пароль учётной записи       | + | + |
};

public class Bridge
{
    char[] separator = { '&', '*', '&' };
    DataBase DB;
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
            /*case (int)Commands.GetImage:
                {
                    result = DB.GetImage(int.Parse(split[1]));
                    break;
                }*/
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

            /*case (int)Commands.ChangeSchem: {
                    result = new string[1];
                    result[0] = DB.ChangeScheme(int.Parse(split[1])).ToString()
                    break;
                }*/

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

            /*case (int)Commands.AddNewSchem:
                {
                    result = new string[1];
                    result[0] = DB.AddScheme(int.Parse(split[1])).ToString();
                        break;
                }*/

            case (int)Commands.DeleteSchem:
                {
                    result = new string[1];
                    result[0] = DB.DeleteSchem(int.Parse(split[1])).ToString();
                        break;
                }
            /*case (int)Commands.GiveFreeExhibitID:
                {
                    result = new string[1];
                    result[0] = DB.GiveFreeExhibitID().ToString();
                    break;
                }*/

            /*case (int)Commands.GiveFreeExhibitSpaceID:
                {
                    result = new string[1];
                    result[0] = DB.GiveFreeExhibitSpaceID().ToString();
                        break;
                }*/

           /* case (int)Commands.GiveFreeFloorID:
                {
                    result = new string[1];
                    result[0] = DB.GiveFreeFloorID().ToString();
                        break;
                }*/

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

            /*case (int)Commands.DownloadSheme:
                {
                    result = new string[1];
                    result[0] = DB.GiveScheme(int.Parse(split[1])).ToString();
                        break;
                }*/

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

            default: {
                    Console.Write("Такой команды не существует");
                    break;
                }
        }


        return PutTogether(result);
    }
}
