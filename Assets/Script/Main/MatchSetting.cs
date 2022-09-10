using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MatchSetting", menuName = "ScriptableObjects/MatchSetting", order = 2)]
public class MatchSetting : ScriptableObject
{

    public GameMode Mode;
    public int MaxPlayer;
    public int MaxLife;
}
