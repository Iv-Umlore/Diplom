using System;
using SocketTcpClient;
using System.Collections.Generic;

// Целый этаж

public class Floor
{
    private int HowManyExhibit;                         // количество экспонатов на этаже
    private List<Exhibit> floore;                       // Список экспонатов
	public Floor(int NumberOfFloore = 1)
	{
        HowManyExhibit = Speaker.GetExhibitCountAt(NumberOfFloore);     // сколько экспонатов на этаже
        int count = 0;
        while (count != HowManyExhibit)                                 // запрашиваем экспонаты
        {
            Exhibit exh = new Exhibit();
            floore.Add(exh);
            count++;
        }
	}

    public void ChangeFloor(int NumberOfFloore = 1)     // сменить этаж
    {

        HowManyExhibit = Speaker.GetExhibitCountAt(NumberOfFloore);
        int count = 0;
        floore.Clear();
        while (count != HowManyExhibit)
        {
            Exhibit exh = new Exhibit();
            floore.Add(exh);
            count++;
        }
    }

    public List<Exhibit> GetFloore()
    {
        return floore;
    }

}
