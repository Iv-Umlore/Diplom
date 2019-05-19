﻿using System;
using SocketTcpClient;
using System.Collections.Generic;

public class ExhibitSpace
{
    int pointID;
    List<int> _exhibit_ids;
    List<string> _exhibit_names;
    int XCoord, YCoord;
	public ExhibitSpace(int id)
	{
        pointID = id;
        _exhibit_ids = new List<int>();
        _exhibit_names = new List<string>();
        string[] res = ResiveExhibitSpace(id);
        XCoord = int.Parse(res[0]);
        YCoord = int.Parse(res[1]);
        
        int position = 2;

        while (position < res.Length )                                 // запрашиваем экспонаты
        {
            if (int.Parse(res[position]) == 0) break;
            _exhibit_ids.Add(int.Parse(res[position]));
            position++;
            _exhibit_names.Add(res[position]);
            position++;
        }

    }

    public ExhibitSpace(int x, int y)
    {
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
            string[] parameters = new string[2];
            parameters[0] = XCoord.ToString();
            parameters[1] = YCoord.ToString();
            Speaker.Send(Bridge.GetCorrectComandStrings((int)Commands.AddNewExhibitSpace, parameters));
        // true/false
    }    

}
