using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class MainMenu : MonoBehaviourPunCallbacks
{
    public static MainMenu instance;


    public LoginPanel LoginPanel;
    public LobbyPanel LobbyPanel;
    public AppereancePanel AppereancePanel;

    public MainPanel ActivePanel;
    public List<MainPanel> Historyactive = new List<MainPanel>();


    MatchSetting currentmatch;

    private void Awake()
    {
        instance = this;
    }

    private IEnumerator Start()
    {
        AppereancePanel.Initialize();
        LoginPanel.Initialize();
        yield return null;
        PhotonPeer.RegisterType(typeof(SkinNetwork), (byte)'s', SkinNetwork.Serialize, SkinNetwork.Deserialize);
    }

    public void Connect()
    {
        PhotonNetwork.LocalPlayer.NickName = PlayerData.Instance.Username;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnected()
    {
        Debug.LogFormat("{0} Onconnect", PhotonNetwork.LocalPlayer.NickName);
        LoginPanel.ConnectResult(true);
        LoginPanel.Hide();
        LobbyPanel.Show();
    }

    /*private void OnFailedToConnect(NetworkConnectionError error)
    {
        LoginPanel.ConnectResult(false);
    }*/

    public void FindMatch(MatchSetting setting)
    {
        currentmatch = setting;
        JoinRandomRoom();
    }

    public void ExitMatch()
    {
        PhotonNetwork.LeaveRoom();
    }

    private void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.LogErrorFormat("OnJoinedRoom {0} count {1}", PhotonNetwork.CurrentRoom.Name, PhotonNetwork.PlayerList.Length);
        CheckPlayerFull();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.LogError("OnJoinRandomFailed");
        CreateRoom();
    }

    private void CreateRoom()
    {
        Debug.LogError("CreateRoom");
        string roomname = "Room " + PlayerData.Instance.Username;
        PhotonNetwork.CreateRoom(roomname);
    }

    public override void OnCreatedRoom()
    {
        Debug.LogErrorFormat("OnCreatedRoom {0} {1}", PhotonNetwork.CurrentRoom.Name,PhotonNetwork.PlayerList.Length);
        CheckPlayerFull();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogErrorFormat("{0} enterroom {1} count {2}", newPlayer.NickName,PhotonNetwork.CurrentRoom.Name, PhotonNetwork.PlayerList.Length);
        CheckPlayerFull();
    }

    void CheckPlayerFull()
    {
        Debug.LogErrorFormat("CountOfPlayers {0} == currentmatch.MaxPlayer {1} ? {2}", PhotonNetwork.PlayerList.Length, currentmatch.MaxPlayer, PhotonNetwork.PlayerList.Length == currentmatch.MaxPlayer);
        LobbyPanel.UpdateRoom(PhotonNetwork.PlayerList.Length, currentmatch.MaxPlayer);
        if(PhotonNetwork.PlayerList.Length == currentmatch.MaxPlayer)
        {
            Debug.LogError("PlayerFull");
            PhotonNetwork.LoadLevel(1);
        }
    }
}
