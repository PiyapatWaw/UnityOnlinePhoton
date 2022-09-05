using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class ColorList : ListUISelector<Color_UI,Color>
    {
        /*private void Start()
        {
            SetUpList(PlayerData.Instance.PlayerHaveColor);
        }*/

        public override void SetUpList(List<Color> objectList)
        {
            foreach (var item in objectList)
            {
                Color_UI ui = Instantiate(Prefab, content);
                ui.Setdata(item);
                Allobject.Add(ui);
            }
        }

        public override void SelectToEquipe(Color_UI select)
        {
            if (MainMenu.instance.AppereancePanel.SelectColorManager.SetCurrentSelect(select))
            {
                select.OnSelect();
            }
            else
            {
                select.OnDeselect();
            }
        }

        public override void SelectToEquipe(Color_UI select, int index)
        {
            if (MainMenu.instance.AppereancePanel.SelectColorManager.SetCurrentSelect(select,index))
            {
                select.OnSelect();
            }
            else
            {
                select.OnDeselect();
            }
        }

        public override void ReturnUIToList(Color_UI target)
        {
            target.OnDeselect();
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }

