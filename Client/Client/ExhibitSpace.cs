using System;
using SocketTcpClient;
using System.Collections.Generic;

public class ExhibitSpace
{
    int pointID;
    List<Exhibit> _exhibits;
    int XCoord, YCoord;
	public ExhibitSpace(int id)
	{
        pointID = id;
        _exhibits = new List<Exhibit>();
        string[] res = ResiveExhibitSpace(id);
        
        int count = 0;
        int position = 1;
        int HowManyExhibit = int.Parse(res[0]);
        while (count != HowManyExhibit)                                 // запрашиваем экспонаты
        {
            Exhibit exb = new Exhibit(int.Parse(res[position]));
            _exhibits.Add(exb);
            position++;
        }


    }

    private string[] ResiveExhibitSpace(int ExhibitSpaceId)
    {
        string[] parameters = new string[1];
        parameters[0] = ExhibitSpaceId.ToString();
        string command = Bridge.GetCorrectComandStrings((int)Commands.GetESpace, parameters);
        string answ = Speaker.Send(command);
        string[] res = Bridge.ParseStr(answ, Bridge.separator);
        return res;
    }
    public void SendExhibitSpace() { }

    // Добавить к точке новый экспонат
    // Удалить его

}
