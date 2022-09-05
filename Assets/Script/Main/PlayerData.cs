using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    static PlayerData instance;
    public static PlayerData Instance { get { return instance ?? (instance = Resources.Load<PlayerData>(path));} }

    [SerializeField]
    private string username;
    private const string path = "ScriptableObjects/PlayerData";

    public string Username { get => username; set => username = value; }

    public Color[] MyColor;
    public Color[] AllColor;
}
