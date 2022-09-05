using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class SelectColorSlot : SelectOjectSlot<Color_UI,Color>
    {
        public override void Click()
        {
            MainMenu.instance.AppereancePanel.SelectColorManager.SelectSlot(this);
           // MyUI.ColorUIComponent.Select.SetActive(true);
            if(MainMenu.instance.AppereancePanel.ColorList.gameObject.activeInHierarchy == false)
            {
                MainMenu.instance.AppereancePanel.ColorList.gameObject.SetActive(true);
            }
        }

        public override void DeSelect()
        {
            //MyUI.ColorUIComponent.Select.SetActive(false);
        }

        public override void ReturnUIToList()
        {
            base.ReturnUIToList();
        }

        public override void SetSelect(Color_UI select)
        {
            data = select.Color;
            MyUI.Setdata(select.Color);
        }
    }