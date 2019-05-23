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
                else root = 0;
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
        string command = "INSERT INTO exhibits (name, description, isused) VALUES ('" + Exhib[1] + "', '" + Exhib[2] + "', false);";
        NpgsqlCommand cmd3 = new NpgsqlCommand(command, conn);
        conn.Open();
        cmd3.ExecuteNonQuery();
        conn.Close();
        return true;
    }

    public bool DeleteExhibitFromDataBase(int ExhID)
    {
        string command = "DELETE FROM exhibits WHERE id = " + ExhID + ";";
        NpgsqlCommand cmd3 = new NpgsqlCommand(command, conn);
        conn.Open();
        cmd3.ExecuteNonQuery();

        command = "DELETE FROM existingexhibits WHERE id_exhib = " + ExhID + ";";
        cmd3 = new NpgsqlCommand(command, conn);
        cmd3.ExecuteNonQuery();

        conn.Close();
        return true;
    }

    public bool ChangeExhibit(string[] Exhib)
    {
        string command = "UPDATE exhibits SET name = '" + Exhib[2] + "' discription = '" + Exhib[3] + "' WHERE id = " + Exhib[1] +" ;";
        NpgsqlCommand cmd3 = new NpgsqlCommand(command, conn);
        conn.Open();
        cmd3.ExecuteNonQuery();

        return true;
    }

    public bool SetExhibit(int ExhibSpaceID, int ExhibID)
    {
        string command = "INSERT INTO existingexhibits VALUES (" + ExhibID + ", " + ExhibSpaceID + ");";
        NpgsqlCommand cmd3 = new NpgsqlCommand(command, conn);
        conn.Open();
        cmd3.ExecuteNonQuery();
        /* change EXHIBIT for true */
        command = "UPDATE exhibits SET isused = TRUE WHERE id = " + ExhibID + ";";
        cmd3 = new NpgsqlCommand(command, conn);
        cmd3.ExecuteNonQuery();

        conn.Close();

        return true;
    }

    public bool ResetExhibit(int ExhibID)
    {
        string command = "DELETE FROM existingexhibits WHERE id_exhib = " + ExhibID + ";";
        NpgsqlCommand cmd3 = new NpgsqlCommand(command, conn);
        conn.Open();
        cmd3.ExecuteNonQuery();

        command = "UPDATE exhibits SET isused = FALSE WHERE id = " + ExhibID + ";";
        cmd3 = new NpgsqlCommand(command, conn);
        cmd3.ExecuteNonQuery();

        conn.Close();
        return true;
    }

    /*static public bool ChangeSchem(Bitmap BM)
    {

    }*/

    public bool AddNewExhibitSpace(int x, int y, int floorID)
    {
        string command = "INSERT INTO exhibitspace (x, y, floor_id) VALUES (" + x + ", " + y + ", " + floorID +");";
        NpgsqlCommand cmd3 = new NpgsqlCommand(command, conn);
        conn.Open();
        cmd3.ExecuteNonQuery();
        conn.Close();

        return true;
    }

    public bool DeleteExhibitSpace(int ExhibSpaceID)
    {

        List<int> hisExhib = new List<int>();
        string command = "SELECT id_exhib FROM existingexhibits WHERE id_point = " + ExhibSpaceID + ";";
        NpgsqlCommand cmd3 = new NpgsqlCommand(command, conn);
        conn.Open();
        NpgsqlDataReader reader = cmd3.ExecuteReader();

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
        conn.Close();
        for (int i = 0; i < hisExhib.Count; i++)
            ResetExhibit(hisExhib[i]);          // Снимаем все экспонаты принадлежавшие ему
                
        command = "DELETE FROM exhibitspace WHERE id = " + ExhibSpaceID + ";";
        cmd3 = new NpgsqlCommand(command, conn);
        conn.Open();
        cmd3.ExecuteNonQuery();

        conn.Close();
        return true;
    }

    /*static public bool AddNewSchem(Bitmap BM)
    {

    }*/

    public bool DeleteSchem(int SchemeID)
    {
        string command = "DELETE FROM exhibitspace WHERE id_scheme = " + SchemeID + ");";
        NpgsqlCommand cmd3 = new NpgsqlCommand(command, conn);
        conn.Open();
        cmd3.ExecuteNonQuery();
        conn.Close();
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
        string command = "INSERT INTO users VALUES ('" + login + "', '" + pass + "', 1);";
        NpgsqlCommand cmd3 = new NpgsqlCommand(command, conn);
        conn.Open();
        cmd3.ExecuteNonQuery();

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

    public bool AddFloorToValid(int FloorID, int number_floor)
    {
        string command = "UPDATE floors number_of_floor = " + number_floor + " isused = TRUE WHERE id_floor = '" + FloorID + "';";
        NpgsqlCommand cmd3 = new NpgsqlCommand(command, conn);
        conn.Open();
        cmd3.ExecuteNonQuery();
        conn.Close();

        return true;
    }

    public bool DeleteFloorFromValid(int FloorID)
    {
        string command = "UPDATE floors number_of_floor = 0 isused = FALSE WHERE id_floor = '" + FloorID + "';";
        NpgsqlCommand cmd3 = new NpgsqlCommand(command, conn);
        conn.Open();
        cmd3.ExecuteNonQuery();
        conn.Close();
        return true;
    }

    public bool DeleteManager(string login)
    {
        string command = "DELETE FROM users WHERE login = '" + login + "';";
        NpgsqlCommand cmd3 = new NpgsqlCommand(command, conn);
        conn.Open();
        cmd3.ExecuteNonQuery();
        conn.Close();
        return true;
    }

    public bool ChangePassword(string login, string pass)
    {

        string command = "UPDATE users password = '" + pass + "' WHERE login = '" + login + "';";
        NpgsqlCommand cmd3 = new NpgsqlCommand(command, conn);
        conn.Open();
        cmd3.ExecuteNonQuery();
        conn.Close();
        return true;
    }

}
