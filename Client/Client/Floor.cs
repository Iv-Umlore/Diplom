using System;
using System.Collections.Generic;

// Целый этаж

public class Floor
{
    private int id;
    string FloorName;
    private List<ExhibitSpace> floor;                  // Список точек экспонатов
    private int _NumberOfFloor;                         // Номер текущего этажа
	public Floor(string[] answer = null)
	{
        id = int.Parse(answer[0]);
        FloorName = answer[1];
        int HowManyExhibitSpace = int.Parse(answer[2]);
        int count = 0;
        int position = 3;
        floor = new List<ExhibitSpace>();
        while (count != HowManyExhibitSpace)                                 // запрашиваем экспонаты
        {
            ExhibitSpace ES = new ExhibitSpace(int.Parse(answer[position]));
            floor.Add(ES);
            position++;
        }
	}

    public List<ExhibitSpace> GetFloore()
    {
        return floor;
    }

    // Добавить к этажу новую точку
    // Удалить её 

}
