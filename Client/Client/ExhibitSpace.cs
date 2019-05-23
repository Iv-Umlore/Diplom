using System;
using SocketTcpClient;
using System.Collections.Generic;

public struct exh
{
    public int exhibit_id;
    public string exhibit_name;
}

public class ExhibitSpace
{
    int pointID;
    List<exh> myExhib;
    int floorid;
    public int XCoord, YCoord;
	public ExhibitSpace(int id)
	{
        pointID = id;
        myExhib = new List<exh>();
        string[] res = ResiveExhibitSpace(id);
        XCoord = int.Parse(res[0]);
        YCoord = int.Parse(res[1]);

        int position = 3;
        exh temp;
        
        while (position < res.Length )                                 // запрашиваем экспонаты
        {
            
            if (int.Parse(res[position]) == 0) break;
            temp.exhibit_id = int.Parse(res[position]);
            position++;
            temp.exhibit_name = res[position];
            position++;
            myExhib.Add(temp);
        }

    }

    public ExhibitSpace(int x, int y, int floor_id)
    {
        floorid = floor_id;
        XCoord = x;
        YCoord = y;
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

    public void SendExhibitSpace() {
            string[] parameters = new string[3];
            parameters[0] = XCoord.ToString();
            parameters[1] = YCoord.ToString();
            parameters[2] = floorid.ToString();
            Speaker.Send(Bridge.GetCorrectComandStrings((int)Commands.AddNewExhibitSpace, parameters));
        // true/false
    }    

    public List<exh> GetExhibits()
    {
        return myExhib;
    }

    public int GetId()
    {
        return pointID;
    }

}
