using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public Renderer[] Renderer;
    public List<Color> Color;
    public Material Material;

    public void SetupSkin(List<Color> c)
    {
        Color = c;

        foreach (var item in Renderer)
        {

            Material instancemat = Instantiate(Material);

            item.material = instancemat;

            item.material.SetColor(SkinKey.Keys[0], Color[0]);
            item.material.SetColor(SkinKey.Keys[1], Color[1]);
            item.material.SetColor(SkinKey.Keys[2], Color[2]);
            item.material.SetColor(SkinKey.Keys[3], Color[3]);
        }
    }
}
