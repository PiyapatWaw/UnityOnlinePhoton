using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public static PlayerMain instance;
    public SkinManager SkinManager;

    private void Awake()
    {
        instance = this;
    }

    public void ChangeColor( int i, Color c)
    {
        PlayerData.Instance.MyColor[i] = c;

        SkinManager.Renderer[0].materials[0].SetColor(SkinKey.Keys[i], c);
        SkinManager.Color[i] = c;
    }
}
