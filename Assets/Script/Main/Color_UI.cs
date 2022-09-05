using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public struct ColorUIComponent
{
    public GameObject Select;
    public Image Icon;

}
public class Color_UI : ObjectUIInListSelector<Color>
{
    [ColorUsage(true, true)]
    public Color Color;
    public ColorUIComponent ColorUIComponent;

    public override void Setdata(Color data)
    {
        Color = data;
        ColorUIComponent.Icon.color = data;
    }
    public override void SetdataIsSelect(Color data)
    {
        base.SetdataIsSelect(data);
    }
    public override void SetRemoveOrClear(bool clear)
    {
        base.SetRemoveOrClear(clear);
    }
    public override void Click()
    {
        foreach (var item in MainMenu.instance.AppereancePanel.ColorList.Allobject)
        {
            item.OnDeselect();
        }
        switch (inuse)
        {
            case true:
                break;
            case false:
                MainMenu.instance.AppereancePanel.ColorList.SelectToEquipe(this);
                break;
        }
    }
    public override void ShowInformation()
    {
        base.ShowInformation();
    }
    public override void RemoveOrclear()
    {
        base.RemoveOrclear();
    }
    public override void OnSelect()
    {
        inuse = true;
        //ColorUIComponent.Select.SetActive(true);
    }

    public override void OnDeselect()
    {
        inuse = false;
        //ColorUIComponent.Select.SetActive(false);
    }
    public override void OnRemove()
    {
        MainMenu.instance.AppereancePanel.SelectColorManager.RemoveSelectSlot();
    }
    public override void OnClear()
    {
        MainMenu.instance.AppereancePanel.SelectColorManager.RemoveAllSlot();
    }
    public override void emptyObject()
    {
        base.emptyObject();
    }

}
