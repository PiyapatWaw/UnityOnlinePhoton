using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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
        yield return null;
        SkinNetwork skinNetwork = new SkinNetwork();
        foreach (var item in PlayerData.Instance.MyColor)
        {
            skinNetwork.Colorlist.Add(item);
        }
        object[] InstantiateInfo = { skinNetwork };
        PhotonNetwork.Instantiate(Player.name, Spawnpos.position,Quaternion.identity, 0,InstantiateInfo);
    }
}
