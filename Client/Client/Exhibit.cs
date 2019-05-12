using System;
using SocketTcpClient;
using System.Collections.Generic;

public class Exhibit
{
    private int _id;                    // Exponat id
    private string _name;               // Exponat name
    private string _description;        // Exponat description
    private List<string> _links;        // may be it's image (Bitmap)
    
    public Exhibit(int id)                    // For download from server
	{
        _id = id;
        string[] exh = ResiveExhibit(id);        
        _name = exh[0];                 // Exponat name
        _description = exh[1];          // Exponat description

        char[] sep = new char[3];
        sep[0] = sep[1] = sep[2] = '|';
        string[] link = Bridge.ParseStr(exh[2], sep);

        _links = new List<string>();
        for (int count = 0; count < link.Length; count++)
        {
            _links.Add(link[count]);
        }       
       
    }

    public Exhibit(string name, string description, List<string> links, int Xcoord, int Ycoord)
    {
        _id = Bridge.GetNextExhibitId();
        _name = name;                   // Exponat name
        _description = description;     // Exponat description
        _links = links;                 // may be it's image (Bitmap)
}
    
    public string[] ResiveExhibit(int ExhibitId) {
        string[] parameters = new string[1];
        parameters[0] = ExhibitId.ToString();
        string command = Bridge.GetCorrectComandStrings((int)Commands.GetExhibit, parameters);

        command = Speaker.Send(command);    // получаем этот экспонат

        string[] res = Bridge.ParseStr(command, Bridge.separator);//command.Split(Bridge.separator);
        return res;
    }
    public void SendExhibit() { }

    public List<string> GetLinks()
    {
        return _links;
    }

    public bool ChangeDescription(string NEWDescription)
    {
        _description = NEWDescription;
        SendExhibit();
        return true;
    }

    public void ChangeName(string NEWname)
    {
        _name = NEWname;
    }

    public void ChangeLinks(List<string> NEWLinks)
    {
        _links = NEWLinks;
    }

}
