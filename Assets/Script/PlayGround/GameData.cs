using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoomState
{
    Setup,
    Play,
    End
}

public enum GameMode
{
    FFA
}

public class GameData 
{
    public const int PlayerLayer = 6;
    public const int BulletLayer = 7;
}

public class EventCode
{
    public const int TakeDamage = 0;
}

public class PropertiesKey
{
    public const string ROOM_STATE = "0";
    public const string ROOM_READY = "1";
    public const string ROOM_GAMEMODE = "2";

    public const string HP = "0";
}

public class SkinKey
{
    public static string[] Keys = new string[] { "_C_Mark_Black", "_C_Mark_Red", "_C_Mark_Green", "_C_Mark_Blue", "_ColorEmission", "_ColorEmission_Noise" };
}
