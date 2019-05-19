using System;
using System.Collections.Generic;

// Целый этаж

public class Floor
{
    private int id;
    private int SchemeId;
    //public Scheme
    string FloorName;
    private List<ExhibitSpace> floor;                  // Список точек экспонатов
    private int _NumberOfFloor;                        // Номер текущего этажа
    public Floor() { }
	public Floor(string[] answer)
	{
        id = int.Parse(answer[0]);
        FloorName = answer[1];
        SchemeId = int.Parse(answer[2]);
        
        int position = 3;
        floor = new List<ExhibitSpace>();
        while (position < answer.Length)                                 // запрашиваем экспонаты
        {
            ExhibitSpace ES = new ExhibitSpace(int.Parse(answer[position]));
            floor.Add(ES);
            position++;
        }
        // Scheme = bridge.DownloadScheme(SchemeID)
    }

    public List<ExhibitSpace> GetFloore()
    {
        return floor;
    }
    
}
