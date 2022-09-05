using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkinNetwork
{

    public List<Color> Colorlist = new List<Color>();

    public static byte[] Serialize(object data)
    {
        byte[] result;
        List<byte> allbyte = new List<byte>();

        SkinNetwork skin = (SkinNetwork)data;

        byte[] Colorlist1CountByte = BitConverter.GetBytes(skin.Colorlist.Count);
        List<byte> ColorlistByte = new List<byte>();
        if (skin.Colorlist.Count > 0)
        {
            foreach (var c in skin.Colorlist)
            {
                float r = c.r;
                float g = c.g;
                float b = c.b;
                float a = c.a;
                byte[] rbyte = BitConverter.GetBytes(r);
                byte[] gbyte = BitConverter.GetBytes(g);
                byte[] bbyte = BitConverter.GetBytes(b);
                byte[] abyte = BitConverter.GetBytes(a);
                List<byte> rgbaByte = new List<byte>();
                rgbaByte.AddRange(rbyte.ToList());
                rgbaByte.AddRange(gbyte.ToList());
                rgbaByte.AddRange(bbyte.ToList());
                rgbaByte.AddRange(abyte.ToList());
                ColorlistByte.AddRange(rgbaByte);
            }
        }

        allbyte.AddRange(Colorlist1CountByte.ToList());
        allbyte.AddRange(ColorlistByte);

        result = allbyte.ToArray();
        return result;
    }

    public static object Deserialize(byte[] data)
    {
        SkinNetwork skin = new SkinNetwork();

        int sizeFloat = sizeof(float);
        int sizeInt = sizeof(int);
        int idx = 0;

        int colorlistcount = BitConverter.ToInt32(data, idx);
        idx = idx + sizeInt;
        List<Color> colorlist = new List<Color>();
        for (int i = 0; i < colorlistcount; i++)
        {
            float r = BitConverter.ToSingle(data, idx);
            idx = idx + sizeFloat;
            float g = BitConverter.ToSingle(data, idx);
            idx = idx + sizeFloat;
            float b = BitConverter.ToSingle(data, idx);
            idx = idx + sizeFloat;
            float a = BitConverter.ToSingle(data, idx);
            idx = idx + sizeFloat;

            Color c = new Color(r, g, b, a);
            colorlist.Add(c);
        }
       
        skin.Colorlist.AddRange(colorlist);

        object result = skin;
        return result;
    }
}
