using System.Collections.Generic;

public class TableSkins : DBManager
{
    #region Singleton
    public static TableSkins Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    private string _tableName = "skins";
    public enum SkinName
    {
        Default,
        Vector,
        PulpPinup,
        Fingi,
        Vizago,
        MorandBail,
        PortraitsLady,
        GreekMythology,
        Steampunk,
        SanyoUkiyo,
        BristolPack,
    }
    Dictionary<SkinName, string> _skinToDB = new Dictionary<SkinName, string>
    {
        {SkinName.Default, "Standart" },
        {SkinName.Vector, "Vector" },
        {SkinName.PulpPinup, "PulpPinup" },
        {SkinName.Fingi, "Fingi" },
        {SkinName.Vizago, "Vizago" },
        {SkinName.MorandBail, "MorandBail" },
        {SkinName.PortraitsLady, "PortraitsLady" },
        {SkinName.GreekMythology, "GreekMythology" },
        {SkinName.Steampunk, "Steampunk" },
        {SkinName.SanyoUkiyo, "SanyoUkiyo" },
        {SkinName.BristolPack, "BristolPack" },
    };
    Dictionary<string, SkinName> _DBToskin = new Dictionary<string, SkinName>
    {
        { "Standart", SkinName.Default},
        { "Vector", SkinName.Vector},
        { "PulpPinup", SkinName.PulpPinup},
        { "Fingi", SkinName.Fingi},
        { "Vizago", SkinName.Vizago},
        { "MorandBail", SkinName.MorandBail},
        { "PortraitsLady", SkinName.PortraitsLady},
        { "GreekMythology", SkinName.GreekMythology},
        { "Steampunk", SkinName.Steampunk},
        { "SanyoUkiyo", SkinName.SanyoUkiyo},
        { "BristolPack", SkinName.BristolPack},
    };

    public void UnlockSkin(SkinName name)
    {
        OpenDB_And_CreateCommand();
        dbcmd.CommandText = $"UPDATE {_tableName} SET {_skinToDB[name]} = 1";
        ExecuteCommand();
        CloseDB();
    }

    public bool IsSkinAvailable(SkinName name)
    {
        OpenDB_And_CreateCommand();
        dbcmd.CommandText = $"SELECT {_skinToDB[name]} FROM {_tableName}";
        ExecuteCommand();

        reader.Read();
        bool value = reader.GetBoolean(0);

        CloseDB();
        return value;
    }

    public void SetSkin(SkinName name)
    {
        OpenDB_And_CreateCommand();
        dbcmd.CommandText = $"UPDATE {_tableName} SET Current = '{_skinToDB[name]}'";
        ExecuteCommand();
        CloseDB();
    }

    public SkinName GetSkin()
    {
        OpenDB_And_CreateCommand();
        dbcmd.CommandText = $"SELECT Current FROM {_tableName}";
        ExecuteCommand();

        reader.Read();
        string value = reader.GetString(0);
        SkinName name = _DBToskin[value];

        CloseDB();
        return name;
    }
}
