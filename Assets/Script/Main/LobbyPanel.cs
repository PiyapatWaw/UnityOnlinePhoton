using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LobbyPanel : MainPanel
{
    [SerializeField]
    private TextMeshProUGUI Username;
    [SerializeField]
    private MatchSetting MatchSetting;

    [SerializeField]
    private FindingMatch Finding;
    [SerializeField]
    private GameObject SearchButton;

    [System.Serializable]
    struct FindingMatch
    {
        public GameObject GameObject;
        public GameObject CancleButton;
        public TextMeshProUGUI CountText;
    }

    public override void Show()
    {
        Username.text = PlayerData.Instance.Username;
        base.Show();
    }


    public void FindMatch()
    {
        MainMenu.instance.FindMatch(MatchSetting);
        SearchButton.SetActive(false);
        Finding.GameObject.SetActive(true);
        FindingRoom();
    }

    public void Cancle()
    {
        MainMenu.instance.ExitMatch();
        SearchButton.SetActive(true);
        Finding.GameObject.SetActive(false);
    }

    public void FindingRoom()
    {
        Finding.CountText.text = "Finding";
        Finding.CancleButton.SetActive(false);
    }

    public void UpdateRoom(int count,int max)
    {
        Finding.CountText.text = string.Format("{0} / {1}", count, max);
        Finding.CancleButton.SetActive(true);
    }

    public void ShowApperance()
    {
        MainMenu.instance.AppereancePanel.Show();
    }
}
