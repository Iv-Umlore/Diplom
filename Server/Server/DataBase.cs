using System;
using System.Collections.Generic;
using Npgsql;
using NpgsqlTypes;

public class DataBase
{
    private string conn_param;
    private NpgsqlConnection conn;

    public int width;
    public int height;

    private int lastExhibID;
    private int lastScheme;

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
                answer.Add(reader.GetInt32(3).ToString());  // number_of_floor 
            }
            catch
            {
                answer.Add("-1");
                answer.Add("Ошибка");
                answer.Add("-1");
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
        sql = "SELECT id_image FROM image WHERE exhib_id = " + number.ToString() + ";";
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
                    AllImage += "|||" + reader.GetInt32(0).ToString();
                }
                else
                {
                    AllImage += reader.GetInt32(0).ToString();
                    flag = true;
                }
            }
            catch {
                AllImage = "0";
            };
        }
        if (AllImage.Equals("")) AllImage = "0";
        res[2] = AllImage;

        conn.Close();
        return res;
    }

    public byte[] GetImage(int ImageID)
    {
        NpgsqlCommand comm = new NpgsqlCommand("SELECT image, width, height FROM image WHERE id_image = " + ImageID + ";", conn);
        conn.Open();
        NpgsqlDataReader reader = comm.ExecuteReader();
        byte[] result;

        if (reader.Read())
        {
            result = (byte[])reader[0];
            width = reader.GetInt32(1);
            height = reader.GetInt32(2);
        }
        else
        {
            result = null;
            width = 0;
            height = 0;
        }
        conn.Close();
        return result;
    }

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

        conn.Close();
        return root;
    }

    public bool AddExponatToDataBase(string[] Exhib)
    {
        string command = "INSERT INTO exhibits (name, description, isused) VALUES ('" + Exhib[1] + "', '" + Exhib[2] + "', false);";
        NpgsqlCommand cmd3 = new NpgsqlCommand(command, conn);
        conn.Open();
        cmd3.ExecuteNonQuery();

        command = "SELECT id FROM exhibits WHERE name = '" + Exhib[1] + "';";
        cmd3 = new NpgsqlCommand(command, conn);

        NpgsqlDataReader reader = cmd3.ExecuteReader();

        while (reader.Read())
        {
            try
            {
                lastExhibID = reader.GetInt32(0);       // all id
            }
            catch
            {
                Console.Write("\nНе удалось запомнить последний экспонат\n");
                lastExhibID = 0;
            }
        }

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

        command = "DELETE FROM image WHERE exhib_id = " + ExhID + ";";
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
        conn.Close();
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

    public bool ChangeSchem(byte[] schem, int schemID)
    {
        string sql;
        sql = "UPDATE schems SET scheme = :binaryData WHERE id = " + schemID + ";";
        NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
        NpgsqlParameter param = new NpgsqlParameter("binaryData", NpgsqlDbType.Bytea);
        param.Value = schem;
        comm.Parameters.Add(param);
        conn.Open();
        comm.ExecuteNonQuery();
        conn.Close();
        return true;
    }

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

    public bool DeleteSchem(int SchemeID)
    {
        // Удаление самих точек происходит при удалении этажа
        string command = "DELETE FROM schems WHERE id = " + SchemeID + ";";
        NpgsqlCommand cmd3 = new NpgsqlCommand(command, conn);
        conn.Open();

        cmd3.ExecuteNonQuery();

        conn.Close();

        return true;
    }
    
    public string[] GiveAllFreeExhibit()
    {
        string sql = "SELECT id, name FROM exhibits WHERE isused = FALSE;";
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

        conn.Close();

        return res;
    }

    public string[] GiveAllValidFloor()
    {
        string sql = "SELECT id_floor, number_of_floor, name FROM floors WHERE isused = TRUE;";
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
                answer.Add(reader.GetInt32(1).ToString());
                answer.Add(reader.GetString(2));
            }
            catch
            {
                answer.Add("0");
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

        return res;
    }

    public string[] GiveUnvalidFloor()
    {
        string sql = "SELECT id_floor, name FROM floors WHERE isused = FALSE;";
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

        if (answer.Count == 0)
        {
            answer.Add("0");
            answer.Add("Недействующие этажи отсутсвуют");
        }

        string[] res = new string[answer.Count];

        for (int i = 0; i < answer.Count; i++)
        {
            res[i] = answer[i];
        }

        conn.Close();

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

        conn.Close();

        return res;
    }

    public bool CreateManager(string login, string pass)
    {
        string command = "INSERT INTO users VALUES ('" + login + "', '" + pass + "', 1);";
        NpgsqlCommand cmd3 = new NpgsqlCommand(command, conn);
        conn.Open();
        cmd3.ExecuteNonQuery();
        conn.Close();
        return true;
    }

    public bool AddFloor(string name)
    {
        string command = "INSERT INTO floors (name, id_scheme, number_of_floor,isused) VALUES ('" + name + "', "+ lastScheme + ", 0, FALSE);";
        NpgsqlCommand cmd3 = new NpgsqlCommand(command, conn);
        conn.Open();
        cmd3.ExecuteNonQuery();
        conn.Close();
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
        conn.Close();
        return res;
    }

    public byte[] DownloadSheme(int SchemeID)
    {
        NpgsqlCommand comm = new NpgsqlCommand("SELECT scheme, width, height FROM schems WHERE id = " + SchemeID + ";", conn);
        conn.Open();
        NpgsqlDataReader reader = comm.ExecuteReader();
        byte[] result;

        if (reader.Read())
        {
            result = (byte[])reader[0];
            width = reader.GetInt32(1);
            height = reader.GetInt32(2);
        }
        else
        {
            result = null;
            width = 0;
            height = 0;
            Console.Write("Ошибка загрузки");
        }
        conn.Close();
        return result;
    }

    public bool AddFloorToValid(int FloorID, int number_floor)
    {
        string command = "UPDATE floors SET number_of_floor = " + number_floor + " , isused = TRUE WHERE id_floor = " + FloorID + ";";
        NpgsqlCommand cmd3 = new NpgsqlCommand(command, conn);
        conn.Open();
        cmd3.ExecuteNonQuery();
        conn.Close();

        return true;
    }

    public bool DeleteFloorFromValid(int FloorID)
    {
        string command = "UPDATE floors SET number_of_floor = 0 , isused = FALSE WHERE id_floor = '" + FloorID + "';";
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

        string command = "UPDATE users SET password = '" + pass + "' WHERE login = '" + login + "';";
        NpgsqlCommand cmd3 = new NpgsqlCommand(command, conn);
        conn.Open();
        cmd3.ExecuteNonQuery();
        conn.Close();
        return true;
    }

    public void DeleteFloor(int FloorID)
    {
        string sql = "SELECT id FROM exhibitspace WHERE floor_id = " + FloorID + ";";
        NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
        List<int> answer = new List<int>();

        conn.Open();

        NpgsqlDataReader reader = comm.ExecuteReader();
        
        while (reader.Read())
        {
            try
            {
                answer.Add(reader.GetInt32(0));    // id_space
            }
            catch
            {
                answer.Add(-1);
            }
        }
        conn.Close();
        for (int i = 0; i < answer.Count; i++)
            DeleteExhibitSpace(answer[i]);
        conn.Open();
        answer.Clear();
        sql = "SELECT id_scheme FROM floors WHERE id_floor = " + FloorID + ";";
        comm = new NpgsqlCommand(sql, conn);
        answer = new List<int>();

        reader = comm.ExecuteReader();

        while (reader.Read())
        {
            try
            {
                answer.Add(reader.GetInt32(0));    // id_scheme
            }
            catch
            {
                answer.Add(-1);
            }
        }
        conn.Close();
        for (int i = 0; i < answer.Count; i++)
            DeleteSchem(answer[i]);
        conn.Open();
        sql = "DELETE FROM floors WHERE id_floor = " + FloorID + ";";
        comm = new NpgsqlCommand(sql, conn);
        comm.ExecuteNonQuery();

        conn.Close();

    }

    public bool AddScheme(byte[] image, int width, int height)
    {
        string sql;
        sql = "INSERT INTO schems (scheme, width, height) VALUES (:binaryData, " + width + ", " + height + ");";
        NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
        NpgsqlParameter param = new NpgsqlParameter("binaryData", NpgsqlDbType.Bytea);
        param.Value = image;
        comm.Parameters.Add(param);
        conn.Open();
        comm.ExecuteNonQuery();

        sql = "SELECT id FROM schems WHERE scheme = :binaryData;";
        comm = new NpgsqlCommand(sql, conn);
        param = new NpgsqlParameter("binaryData", NpgsqlDbType.Bytea);
        param.Value = image;
        comm.Parameters.Add(param);
        NpgsqlDataReader reader = comm.ExecuteReader();

        while (reader.Read())
        {
            try
            {
                lastScheme = reader.GetInt32(0);       // all id
            }
            catch
            {
                Console.Write("\nНе удалось запомнить последний экспонат\n");
                lastScheme = 0;
            }
        }

        conn.Close();
        return true;
    }

    public bool SaveImage(byte[] image, int width, int height, int exhibitID = 0 )
    {
        try
        {            
            string sql;
            if (exhibitID == 0)
                sql = "INSERT INTO image (image, exhib_id, width, height) VALUES (:binaryData, " + lastExhibID + ", " + width +", " + height + ");";
            else
                sql = "INSERT INTO image (image, exhib_id, width, height) VALUES (:binaryData, " + exhibitID + ", " + width + ", " + height + ");";
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            NpgsqlParameter param = new NpgsqlParameter("binaryData", NpgsqlDbType.Bytea);
            param.Value = image;
            comm.Parameters.Add(param);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    public void ChangeFloor(int floorID, string name)
    {
        string sql = "UPDATE floors SET name = '" + name + "' WHERE id_floor = " + floorID + ";";
        NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
        conn.Open();
        comm.ExecuteNonQuery();
        conn.Close();
    }

}
