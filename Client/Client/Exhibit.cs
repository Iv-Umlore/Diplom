using System;
using SocketTcpClient;
using System.Collections.Generic;

public class Exhibit
{
    private int _id;                    // Exponat id
    private string _name;               // Exponat name
    private string _description;        // Exponat description
    private List<string> _links;        // may be it's image (Bitmap)
    private int _Xcoord, _Ycoord;       // Exponat's coord in out Schem

    public Exhibit()                    // For download from server
	{ }

    public Exhibit(string name, string description, List<string> links, int Xcoord, int Ycoord)
    {
        _id = Speaker.GetNextExhibitId();
        _name = name;                   // Exponat name
        _description = description;     // Exponat description
        _links = links;                 // may be it's image (Bitmap)
        _Xcoord = Xcoord;
        _Ycoord = Ycoord;
}

    public void ResiveExhibit() { }
    public void ResiveExhibit(int ExhibitId) { }
    public void SendExhibit() { }

    public bool ChangeDescription(string NEWDescription)
    {
        _description = NEWDescription;
        SendExhibit();
        return true;
    }

}
