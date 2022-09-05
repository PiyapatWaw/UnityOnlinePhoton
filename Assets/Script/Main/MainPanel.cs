using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : MonoBehaviour
{
    
    public virtual void Initialize()
    {

    }

    public virtual void Show()
    {
        Debug.LogError(gameObject.name + " show " + (MainMenu.instance.ActivePanel != null));
        if (MainMenu.instance.ActivePanel != null )
        {
            MainPanel target = MainMenu.instance.ActivePanel;
            MainMenu.instance.ActivePanel.Hide();
            MainMenu.instance.Historyactive.Add(target);
        }
        gameObject.SetActive(true);
        MainMenu.instance.ActivePanel = this;
    }

    public virtual void Hide()
    {
        MainMenu.instance.ActivePanel = null;
        int count = MainMenu.instance.Historyactive.Count;
        Debug.LogError(gameObject.name + " Hide " + count 
            /*+ (string.Format("{0} {1}", MainMenu.instance.ActivePanel != this, MainMenu.instance.ActivePanel != null? MainMenu.instance.ActivePanel.name : "") )*/);
        if (count > 0 /*&& MainMenu.instance.ActivePanel != this*/)
        {
            MainPanel target = MainMenu.instance.Historyactive[count - 1];
            MainMenu.instance.Historyactive.RemoveAt(count - 1);
            target.Show();
        }
        gameObject.SetActive(false);
        
    }
}
