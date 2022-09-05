using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AppereancePanel : MainPanel
{
    public SelectColorManager SelectColorManager;
    public ColorList ColorList;


    public override void Initialize()
    {
        List<Color> startcolor = new List<Color>();
        for (int i = 0; i < 4; i++)
        {
            startcolor.Add(PlayerData.Instance.AllColor[Random.Range(0, PlayerData.Instance.AllColor.Length)]);
        }
        PlayerMain.instance.SkinManager.SetupSkin(startcolor);
        ColorList.SetUpList(PlayerData.Instance.AllColor.ToList());
        SelectColorManager.GetColorFromSelectObject(PlayerMain.instance.SkinManager.Color);
    }
}
