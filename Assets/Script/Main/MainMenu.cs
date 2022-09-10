using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Hashtable = ExitGames.Client.Photon.Hashtable;

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
        Hashtable roomproperties = new Hashtable();
        roomproperties[PropertiesKey.ROOM_STATE] = RoomState.Setup;
        roomproperties[PropertiesKey.ROOM_READY] = false;

        roomproperties[PropertiesKey.ROOM_GAMEMODE] = currentmatch.Mode.ToString();

        RoomOptions options = new RoomOptions
        {
            MaxPlayers = (byte)currentmatch.MaxPlayer,
            PlayerTtl = 0, 
            CleanupCacheOnLeave = true, 
            CustomRoomProperties = roomproperties,
            PublishUserId = true,
        };

        Debug.Log("CreateRoom");
        string roomname = "Room " + PlayerData.Instance.Username;
        PhotonNetwork.CreateRoom(roomname, options, null);
    }

    public override void OnCreatedRoom()
    {
        Debug.LogFormat("OnCreatedRoom {0} {1}", PhotonNetwork.CurrentRoom.Name,PhotonNetwork.PlayerList.Length);
        CheckPlayerFull();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("{0} enterroom {1} count {2}", newPlayer.NickName,PhotonNetwork.CurrentRoom.Name, PhotonNetwork.PlayerList.Length);
        CheckPlayerFull();
    }

    void CheckPlayerFull()
    {
        Debug.LogFormat("CountOfPlayers {0} == currentmatch.MaxPlayer {1} ? {2}", PhotonNetwork.PlayerList.Length, PhotonNetwork.CurrentRoom.MaxPlayers, PhotonNetwork.PlayerList.Length == PhotonNetwork.CurrentRoom.MaxPlayers);
        LobbyPanel.UpdateRoom(PhotonNetwork.PlayerList.Length, PhotonNetwork.CurrentRoom.MaxPlayers);
        if(PhotonNetwork.PlayerList.Length == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            Debug.LogError("PlayerFull");
            PhotonNetwork.LoadLevel(1);
        }
    }
}
