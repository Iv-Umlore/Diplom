using System;
using System.Collections.Generic;
using System.Drawing;

// Целый этаж

public class Floor
{
    private int id;
    public int SchemeId;
    public Bitmap Scheme;
    public string FloorName;
    private List<ExhibitSpace> floor;                  // Список точек экспонатов
    public int _NumberOfFloor;                         // Номер текущего этажа
    // public Floor() { }
	public Floor(string[] answer)
	{
        id = int.Parse(answer[0]);
        FloorName = answer[1];
        SchemeId = int.Parse(answer[2]);
        _NumberOfFloor = int.Parse(answer[3]);
        int position = 4;
        floor = new List<ExhibitSpace>();
        while (position < answer.Length)                                 // запрашиваем точки экспонатов
        {
            ExhibitSpace ES = new ExhibitSpace(int.Parse(answer[position]));
            floor.Add(ES);
            position++;
        }
        Scheme = Bridge.DownloadScheme(SchemeId);
    }

    public List<ExhibitSpace> GetFloore()
    {
        return floor;
    }

    public int GetId()
    {
        return id;
    }
    
}
