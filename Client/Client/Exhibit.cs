using System;
using SocketTcpClient;
using System.Collections.Generic;

public class Exhibit
{
    private int _id;                   // Exponat id
    public string _name;               // Exponat name
    public string _description;        // Exponat description
    private List<int> images_id;       
    
    public Exhibit(int id)                    // For download from server
	{
        _id = id;
        string[] exh = ResiveExhibit(id);        
        _name = exh[0];                 // Exponat name
        _description = exh[1];          // Exponat description

        char[] sep = new char[3];
        sep[0] = sep[1] = sep[2] = '|';
        string[] image_id = Bridge.ParseStr(exh[2], sep);

        images_id = new List<int>();
        for (int count = 0; count < image_id.Length; count++)
        {
            if (int.Parse(image_id[count]) == 0) break;
            images_id.Add(int.Parse(image_id[count]));
        }       
       
    }

    public Exhibit(string name, string description)
    {
        //_id = Bridge.GetNextExhibitId();
        _name = name;                   // Exponat name
        _description = description;     // Exponat description
}
    
    public string[] ResiveExhibit(int ExhibitId) {
        string[] parameters = new string[1];
        parameters[0] = ExhibitId.ToString();
        string command = Bridge.GetCorrectComandStrings((int)Commands.GetExhibit, parameters);

        command = Speaker.Send(command);    // получаем этот экспонат

        string[] res = Bridge.ParseStr(command, Bridge.separator);
        return res;
    }

    public void SendExhibit() {
        string[] parameters = new string[2];
        parameters[0] = _name;
        parameters[1] = _description;
        Speaker.Send(Bridge.GetCorrectComandStrings((int)Commands.AddExponatToDataBase, parameters));
    }

    public void ChangeExhibit()
    {
        string[] parameters = new string[3];
        parameters[0] = _id.ToString();
        parameters[1] = _name;
        parameters[2] = _description;
        Speaker.Send(Bridge.GetCorrectComandStrings((int)Commands.AddNewExhibitSpace, parameters));
    }

    public List<int> GetImagesID()
    {
        return images_id;
    }

    public void ChangeDescription(string NEWDescription)
    {
        _description = NEWDescription;
    }

    public void ChangeName(string NEWname)
    {
        _name = NEWname;
    }
    
}
