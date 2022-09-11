using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Cinemachine;
using ExitGames.Client.Photon;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager instance;

    public RoomState RoomState;

    public CinemachineVirtualCamera CinemachineCamera;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private Transform Spawnpos;


    private void Awake()
    {
        instance = this;
    }

    private IEnumerator Start()
    {
        object state = null;
        yield return new WaitUntil(()=>PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue(PropertiesKey.ROOM_STATE,out state));
        RoomState = (RoomState)state;

        if (RoomState != RoomState.Play)
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                Hashtable roomproperties = new Hashtable();
                roomproperties.Add(PropertiesKey.ROOM_STATE, RoomState.Play);
                roomproperties.Add(PropertiesKey.ROOM_READY, true);
                PhotonNetwork.CurrentRoom.SetCustomProperties(roomproperties);
            }
        }

        SkinNetwork skinNetwork = new SkinNetwork();
        foreach (var item in PlayerData.Instance.MyColor)
        {
            skinNetwork.Colorlist.Add(item);
        }
        object[] InstantiateInfo = { skinNetwork };
        PhotonNetwork.Instantiate(Player.name, Spawnpos.position, Quaternion.identity, 0, InstantiateInfo);
    }

    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
    {
        if (propertiesThatChanged.ContainsKey(PropertiesKey.ROOM_STATE))
        {
            RoomState = (RoomState)PhotonNetwork.CurrentRoom.CustomProperties[PropertiesKey.ROOM_STATE];
        }
    }
}
