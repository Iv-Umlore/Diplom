using System;

enum Commands
{
    GetFloor = 1,   //                                                  | +
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
    AddNewSchem = 14,           // Добавить новую схему этажа           | ???
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
            case (int)Commands.GetExhibit: {
                    result = DataBase.GetExhibit(int.Parse(split[1]));
                    break;
                }
            /*case (int)Commands.GetImage:
                {
                    result = DataBase.GetImage(int.Parse(split[1]));
                    break;
                }*/
            case (int)Commands.Autorization: {
                    result = new string[1];
                    result[0] = DataBase.Autorization(split[1], split[2]).ToString();
                    break;
                }
            case (int)Commands.AddExponatToDataBase: {
                    result = new string[1];
                    result[0] = DataBase.AddExponatToDataBase(split).ToString();
                    break;
                }
            case (int)Commands.DeleteExhibitFromDataBase: {
                    result = new string[1];
                    result[0] = DataBase.DeleteExhibitFromDataBase(int.Parse(split[1])).ToString();
                    break;
                }
            case (int)Commands.ChangeExhibit: {
                    result = new string[1];
                    result[0] = DataBase.ChangeExhibit(split).ToString();
                    break;
                }
            case (int)Commands.SetExhibit: {
                    result = new string[1];
                    result[0] = DataBase.SetExhibit(int.Parse(split[1]), int.Parse(split[2])).ToString();
                    break;
                }
            case (int)Commands.ResetExhibit: {
                    result = new string[1];
                    result[0] = DataBase.ResetExhibit(int.Parse(split[1])).ToString();
                    break;
                }

            /*case (int)Commands.ChangeSchem: {
                    result = new string[1];
                    result[0] = DataBase.ChangeScheme(int.Parse(split[1])).ToString()
                    break;
                }*/

            case (int)Commands.AddNewExhibitSpace: {
                    result = new string[1];
                    result[0] = DataBase.AddNewExhibitSpace(int.Parse(split[1]), int.Parse(split[2]), int.Parse(split[3])).ToString();
                    break;
                }

            case (int)Commands.DeleteExhibitSpace:
                {
                    result = new string[1];
                    result[0] = DataBase.DeleteExhibitSpace(int.Parse(split[1])).ToString();
                    break;
                }

            /*case (int)Commands.AddNewSchem:
                {
                    result = new string[1];
                    result[0] = DataBase.AddScheme(int.Parse(split[1])).ToString();
                        break;
                }*/

            case (int)Commands.DeleteSchem:
                {
                    result = new string[1];
                    result[0] = DataBase.DeleteSchem(int.Parse(split[1])).ToString();
                        break;
                }
            case (int)Commands.GiveFreeExhibitID:
                {
                    result = new string[1];
                    result[0] = DataBase.GiveFreeExhibitID().ToString();
                    break;
                }

            case (int)Commands.GiveFreeExhibitSpaceID:
                {
                    result = new string[1];
                    result[0] = DataBase.GiveFreeExhibitSpaceID().ToString();
                        break;
                }

            case (int)Commands.GiveFreeFloorID:
                {
                    result = new string[1];
                    result[0] = DataBase.GiveFreeFloorID().ToString();
                        break;
                }

            case (int)Commands.GiveAllValidFloor:
                {
                    result = DataBase.GiveAllValidFloor();
                    break;
                }

            case (int)Commands.GiveAllFloor:
                {
                    result = DataBase.GiveAllFloor();
                    break;
                }

            case (int)Commands.CreateManager:
                {
                    result = new string[1];
                    result[0] = DataBase.CreateManager(split[1], split[2]).ToString();
                        break;
                }

            case (int)Commands.GiveAllManager:
                {
                    result = DataBase.GiveAllManager();
                        break;
                }

            /*case (int)Commands.DownloadSheme:
                {
                    result = new string[1];
                    result[0] = DataBase.GiveScheme(int.Parse(split[1])).ToString();
                        break;
                }*/

            case (int)Commands.AddFloorToValid:
                {
                    result = new string[1];
                    result[0] = DataBase.AddFloorToValid(int.Parse(split[1])).ToString();
                    break;
                }

            case (int)Commands.DeleteFloorFromValid:
                {
                    result = new string[1];
                    result[0] = DataBase.DeleteFloorFromValid(int.Parse(split[1])).ToString();
                        break;
                }

            case (int)Commands.DeleteManager:
                {
                    result = new string[1];
                    result[0] = DataBase.DeleteManager(split[1]).ToString();
                        break;
                }

            case (int)Commands.ChangePassword:
                {
                    result = new string[1];
                    result[0] = DataBase.ChangePassword(split[1],split[2]).ToString();
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
