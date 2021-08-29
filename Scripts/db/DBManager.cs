using UnityEngine;
using Mono.Data.Sqlite;
using System.IO;

public abstract class DBManager : MonoBehaviour
{
    protected SqliteConnection dbconn;
    protected SqliteCommand dbcmd;
    protected SqliteDataReader reader;
    protected string DatabaseName = "db.bytes";

    protected void OpenDB_And_CreateCommand()
    {
        string dbPath;
        if (Application.platform != RuntimePlatform.Android) dbPath = Path.Combine(Application.dataPath, DatabaseName);
        else dbPath = Path.Combine(Application.persistentDataPath, DatabaseName);

        if (!File.Exists(dbPath))
        {
            File.Create(dbPath).Dispose();
        }

        string connection = "URI=file:" + dbPath;

        if (File.ReadAllBytes(dbPath).Length == 0)
        {
            CreateSkinsTableInDB(connection);
            AddNewSkinsRowInDB(connection);

            //CreatePlayerTableInDB(connection);
            //AddNewPlayerRowInDB(connection);
        }

        dbconn = new SqliteConnection(connection);
        dbconn.Open();

        dbcmd = dbconn.CreateCommand();
    }

    protected void ExecuteCommand()
    {
        reader = dbcmd.ExecuteReader();
    }

    protected void CloseDB()
    {
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    #region CreatingTables

    private void CreateSkinsTableInDB(string connection)
    {
        string query = "CREATE TABLE IF NOT EXISTS skins(" +
            "Current TEXT," +
            "Standart INTEGER," +
            "Vector INTEGER," +
            "PulpPinup INTEGER," +
            "Fingi INTEGER," +
            "MorandBail INTEGER," +
            "PortraitsLady INTEGER," +
            "GreekMythology INTEGER," +
            "Steampunk INTEGER," +
            "SanyoUkiyo INTEGER," +
            "Vizago INTEGER);";

        dbconn = new SqliteConnection(connection);
        dbconn.Open();
        dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = query;
        dbcmd.ExecuteNonQuery();
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    private void AddNewSkinsRowInDB(string connection)
    {
        dbconn = new SqliteConnection(connection);
        dbconn.Open();
        dbcmd = dbconn.CreateCommand();

        string query1 = "DELETE FROM skins";
        dbcmd.CommandText = query1;
        dbcmd.ExecuteNonQuery();

        string query2 = "INSERT INTO skins(Current, Standart, Vector, SanyoUkiyo, PulpPinup, MorandBail, GreekMythology, Steampunk, PortraitsLady, Fingi, Vizago)" +
            "VALUES('Standart', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0);";
        dbcmd.CommandText = query2;

        dbcmd.ExecuteNonQuery();
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    //private void CreatePlayerTableInDB(string connection)
    //{
    //    string query = "CREATE TABLE IF NOT EXISTS player(" +
    //        "maxStoryLvl INTEGER," +
    //        "currentStoryLvl INTEGER," +
    //        "joystickDeadZone REAL," +
    //        "joystickSize REAL," +
    //        "joystickIsDynamic INTEGER);";

    //    dbconn = new SqliteConnection(connection);
    //    dbconn.Open();
    //    dbcmd = dbconn.CreateCommand();
    //    dbcmd.CommandText = query;
    //    dbcmd.ExecuteNonQuery();
    //    dbcmd.Dispose();
    //    dbcmd = null;
    //    dbconn.Close();
    //    dbconn = null;
    //}

    //private void AddNewPlayerRowInDB(string connection)
    //{
    //    dbconn = new SqliteConnection(connection);
    //    dbconn.Open();
    //    dbcmd = dbconn.CreateCommand();

    //    string query1 = "DELETE FROM player";
    //    dbcmd.CommandText = query1;
    //    dbcmd.ExecuteNonQuery();

    //    string query2 = "INSERT INTO player(maxStoryLvl, currentStoryLvl, joystickDeadZone, joystickSize, joystickIsDynamic)" +
    //        "VALUES(0, 0, 0.5, 0.7, 0);";
    //    dbcmd.CommandText = query2;

    //    dbcmd.ExecuteNonQuery();
    //    dbcmd.Dispose();
    //    dbcmd = null;
    //    dbconn.Close();
    //    dbconn = null;
    //}

    #endregion
}

