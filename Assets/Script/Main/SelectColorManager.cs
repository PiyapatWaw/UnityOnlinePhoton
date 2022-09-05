using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class SelectColorManager : SelectingObjectManager<Color_UI, SelectColorSlot>
{

    public void GetColorFromSelectObject(List<Color> colors)
    {
        for (int i = 0; i < colors.Count; i++)
        {
            AllSlot[i].MyUI.Setdata(colors[i]);
            PlayerMain.instance.ChangeColor(i, colors[i]);
        }
    }

    public override void RemoveAllSlot()
    {
        foreach (var slot in AllSlot)
        {
            slot.ReturnUIToList();
            slot.DeSelect();
        }
    }

    public override void RemoveSelectSlot()
    {
        if (currentSelect != null)
        {
            currentSelect.ReturnUIToList();
            ReSetCurrentSelect();
        }
    }

    public override void ReSetCurrentSelect()
    {
        currentSelect.DeSelect();
    }

    public override void SelectSlot(SelectColorSlot select)
    {
        if (currentSelect != null)
        {
            currentSelect.DeSelect();
            currentSelect = null;
        }

        currentSelect = select;
        foreach (var item in MainMenu.instance.AppereancePanel.ColorList.Allobject)
        {
            if (item.inuse && item.Color != select.MyUI.Color)
                item.OnDeselect();
            if (select.MyUI.Color == item.Color)
                item.OnSelect();
        }
    }

    public override bool SetCurrentSelect(Color_UI Select)
    {
        currentSelect.SetSelect(Select);
        int i = AllSlot.ToList().IndexOf(currentSelect);
        PlayerMain.instance.ChangeColor(i, Select.Color);
        return true;
    }

    public override bool SetCurrentSelect(Color_UI Select, int index)
    {
        if (index < AllSlot.Length)
        {
            AllSlot[index].SetSelect(Select);
            return true;
        }
        else
        {
            return false;
        }
    }

}

