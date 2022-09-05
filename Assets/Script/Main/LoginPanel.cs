using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginPanel : MainPanel
{
    [SerializeField]
    private TMP_InputField UsernameInput;
    [SerializeField]
    private Button ConfirmButton;
    [SerializeField]
    private CanvasGroup CanvasGroup;

    public override void Initialize()
    {
        ConfirmButton.interactable = false;
    }

    public void OnType()
    {
        ConfirmButton.interactable = UsernameInput.text != "";
    }

    public void OnConfirm()
    {
        PlayerData.Instance.Username = UsernameInput.text;
        MainMenu.instance.Connect();
        ConnectResult(false);
    }

    public void ConnectResult(bool t)
    {
        CanvasGroup.interactable = !t;
    }
}
