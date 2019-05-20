using System;
using System.Collections.Generic;
using Npgsql;

public class DataBase
{
    private string conn_param;
    private NpgsqlConnection conn;

    public DataBase()
    {
        conn_param = "Server=127.0.0.1;Port=5432;UserId=postgres;Password=rjnt98xz;Database=Museum;";
        conn = new NpgsqlConnection(conn_param);
    }

	public string[] GetFloor(int number)
    {
        string sql = "SELECT * FROM floors WHERE id_floor = " + number + ";";
        NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
        conn.Open();
        NpgsqlDataReader reader;
        reader = comm.ExecuteReader();
        // Здесь будет обращение к БД
        List<string> answer = new List<string>();
        while (reader.Read())
        {
            try
            {
                answer.Add(reader.GetInt32(0).ToString());  // id
                answer.Add(reader.GetString(1));            // name
                answer.Add(reader.GetInt32(2).ToString());  // scheme_id
            }
            catch
            {
                answer.Add("-1");
                answer.Add("Ошибка");
                answer.Add("-1");
            }
        }

        sql = "SELECT id FROM exhibitspace WHERE floor_id = " + number + ";";
        comm = new NpgsqlCommand(sql, conn);
        reader = comm.ExecuteReader();

        while (reader.Read())
        {
            try
            {
                answer.Add(reader.GetInt32(0).ToString());    // id_space
            }
            catch
            {
                answer.Add("-1");
            }
        }

        string[] res = new string[answer.Count];

        for (int i = 0; i < answer.Count; i++)
        {
            res[i] = answer[i];
        }

        conn.Close();
        Console.Write("Выдаю этаж\n");
        return res;
    }

    public string[] GetESpace(int number)
    {

        string sql = "SELECT x, y FROM exhibitspace WHERE id = " + number + ";";
        NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
        conn.Open();
        NpgsqlDataReader reader;
        reader = comm.ExecuteReader();

        // Здесь будет обращение к БД
        List<string> answer = new List<string>();
        while (reader.Read())
        {
            try
            {
                answer.Add(reader.GetInt32(0).ToString());      // x
                answer.Add(reader.GetInt32(1).ToString());      // y
            }
            catch
            {
                answer.Add("-1");
                answer.Add("-1");
            }
        }

        List<int> hisExhib = new List<int>();
        sql = "SELECT id_exhib FROM existingexhibits WHERE id_point = " + number.ToString() + ";";
        comm = new NpgsqlCommand(sql, conn);
        reader = comm.ExecuteReader();

        while (reader.Read())
        {
            try
            {
                hisExhib.Add(reader.GetInt32(0));       // all id
            }
            catch
            {
                hisExhib.Add(0);
            }
        }
        if (hisExhib.Count == 0) hisExhib.Add(0);

        sql = "SELECT id, name FROM exhibits WHERE id = " + hisExhib[0];
        for (int pos = 1; pos < hisExhib.Count; pos++)           
            sql += "OR id = " + hisExhib[pos];
                sql += ";";
        comm = new NpgsqlCommand(sql, conn);
        reader = comm.ExecuteReader();

        while (reader.Read())
        {
            try
            {
                answer.Add(reader.GetInt32(0).ToString());  // id
                answer.Add(reader.GetString(1));            // name
            }
            catch
            {
                answer.Add("0");
                answer.Add("Ошибка");
            }
        }

        string[] res = new string[answer.Count];

        for (int i = 0; i < answer.Count; i++)
        {
            res[i] = answer[i];
        }

        conn.Close();
        Console.Write("Выдаю Точку\n");
        return res;
    }

    public string[] GetExhibit(int number)
    {
        string sql = "SELECT * FROM exhibits WHERE id = " + number.ToString() + ";";
        NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
        conn.Open();
        NpgsqlDataReader reader;
        reader = comm.ExecuteReader();
        // Здесь будет обращение к БД
        string[] res = new string[3];
        while (reader.Read())
        {
            try
            {
                res[0] = reader.GetString(1);
                res[1] = reader.GetString(2);
            }
            catch
            {
                res[0] = "Ошибка";
                res[1] = "Ошибка";
            };
        }
        sql = "select id_image from image where exhib_id = " + number.ToString() + ";";
        comm = new NpgsqlCommand(sql, conn);
        reader = comm.ExecuteReader();
        string AllImage = "";
        bool flag = false;
        while (reader.Read())
        {
            try
            {
                if (flag)
                {
                    AllImage += "|||" + reader.GetString(0);
                }
                else
                {
                    AllImage += reader.GetString(0);
                }
            }
            catch {
                AllImage = "0";
            };
        }
        if (AllImage.Equals("")) AllImage = "0";
        res[2] = AllImage;

        conn.Close();
        Console.Write("Выдаю экспонат\n");
        return res;
    }

    /*static Bitmap GetImage(int ImageID)
    {
        return
    }*/

    public int Autorization(string login, string pass)
    {

        string sql = "SELECT * FROM users WHERE login = '" + login + "';";
        NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
        conn.Open();
        NpgsqlDataReader reader;
        reader = comm.ExecuteReader();
        bool flag = false;
        int root = 0;
        while (reader.Read())
        {
            try
            {
                flag = true;
                if (pass.Equals(reader.GetString(1))) root = reader.GetInt32(2);
            }
            catch
            {
                return -1;      // Error
            }
        }

        if (!flag) return -2;   // login is not correct

        return root;
    }

    public bool AddExponatToDataBase(string[] Exhib)
    {
        /*string sql = "INSERT INTO exhibits (name, description, isused) AS (" + Exhib[1] + ", " + Exhib[2] + ", " + "FALSE)" + ";";
        NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
        conn.Open();
        NpgsqlDataReader reader;
        reader = comm.ExecuteReader();*/
        return true;
    }

    public bool DeleteExhibitFromDataBase(int ExhID)
    {
        return true;
    }

    public bool ChangeExhibit(string[] Exhib)
    {
        return true;
    }

    public bool SetExhibit(int ExhibSpaceID, int ExhibID)
    {
        return true;
    }

    public bool ResetExhibit(int ExhibID)
    {
        return true;
    }

    /*static public bool ChangeSchem(Bitmap BM)
    {

    }*/
    public bool AddNewExhibitSpace(int ExhibSpaceID, int x, int y)
    {
        return true;
    }

    public bool DeleteExhibitSpace(int ExhibSpaceID)
    {
        return true;
    }

    /*static public bool AddNewSchem(Bitmap BM)
    {

    }*/

    public bool DeleteSchem(int SchemeID)
    {
        return true;
    }

    /*public int GiveFreeExhibitID()
    {
        return 1;
    }*/

    /*public int GiveFreeExhibitSpaceID()
    {
        return 1;
    }*/

    /*public int GiveFreeFloorID()
    {
        return 1;
    }*/

    public string[] GiveAllValidFloor()
    {

        string sql = "SELECT id_floor, name FROM floors WHERE isused = TRUE;";
        NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
        conn.Open();
        NpgsqlDataReader reader;
        reader = comm.ExecuteReader();
        List<string> answer = new List<string>();
        while (reader.Read())
        {
            try
            {
                answer.Add(reader.GetInt32(0).ToString());
                answer.Add(reader.GetString(1));
            }
            catch
            {
                answer.Add("0");
                answer.Add("Ошибка");
            }
        }

        string[] res = new string[answer.Count];

        for (int i = 0; i < answer.Count; i++)
        {
            res[i] = answer[i];
        }

        return res;
    }

    public string[] GiveAllFloor()
    {
        string sql = "SELECT id_floor, name FROM floors;";
        NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
        conn.Open();
        NpgsqlDataReader reader;
        reader = comm.ExecuteReader();
        List<string> answer = new List<string>();
        while (reader.Read())
        {
            try
            {
                answer.Add(reader.GetInt32(0).ToString());
                answer.Add(reader.GetString(1));
            }
            catch
            {
                answer.Add("0");
                answer.Add("Ошибка");
            }
        }

        string[] res = new string[answer.Count];

        for (int i = 0; i < answer.Count; i++)
        {
            res[i] = answer[i];
        }
        
        return res;
    }

    public bool CreateManager(string login, string pass)
    {
        return true;
    }
    public string[] GiveAllManager()
    {
        string sql = "SELECT login FROM users WHERE root = 1;";
        NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
        conn.Open();
        NpgsqlDataReader reader;
        reader = comm.ExecuteReader();
        List<string> answer = new List<string>();
        while (reader.Read())
        {
            try
            {
                answer.Add(reader.GetString(0));
            }
            catch
            {
                answer.Add("Ошибка");
            }
        }

        if (answer.Count == 0) answer.Add("Отсутствуют");

        string[] res = new string[answer.Count];

        for (int i = 0; i < answer.Count; i++)
        {
            res[i] = answer[i];
        }

        return res;
    }

    /*static public Bitmap DownloadSheme(int SchemeID)
    {

    }*/

    public bool AddFloorToValid(int FloorID)
    {
        return true;
    }

    public bool DeleteFloorFromValid(int FloorID)
    {
        return true;
    }

    public bool DeleteManager(string login)
    {
        return true;
    }

    public bool ChangePassword(string login, string pass)
    {
        return true;
    }

}
