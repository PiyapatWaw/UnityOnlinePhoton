using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using StarterAssets;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PlayerManager : MonoBehaviourPunCallbacks, IPunInstantiateMagicCallback
{
    public ThirdPersonController thirdPersonController;
    public WeaponManager weaponManager;
    public SkinManager SkinManager;
    [SerializeField]
    private StarterAssetsInputs _input;
    public float hp;
    public float serverhp;
    public string nickname;


    [SerializeField]
    private PhotonView pv;
    [SerializeField]
    private Player player;

    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.NetworkingClient.EventReceived += OnEvent;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.NetworkingClient.EventReceived -= OnEvent;
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        player = info.Sender;
        nickname = player.NickName;
        if (pv.IsMine)
        {
            thirdPersonController.InitialCamera();
        }
        SkinNetwork skinNetwork = (SkinNetwork)info.photonView.InstantiationData[0];
        SkinManager.SetupSkin(skinNetwork.Colorlist);
    }

    private void Update()
    {
        weaponManager.Shooting(_input.shoot);
        if(photonView.IsMine && player!=null)
        {
            Hashtable hash = new Hashtable()
                {
                    { PropertiesKey.HP, hp }
                };
            player.SetCustomProperties(hash);
        }
    }

    public void Takedamage(float value)
    {
        hp -= Getfactor_Damaged(value);
        if(hp<=0)
        {
            thirdPersonController.PlayDie();
        }
    }

    public float GetFactor_Attack(float value)
    {
        float AttackPercent = 100;
        float factor = AttackPercent / 100;

        return value * factor;
    }

    public float Getfactor_Damaged(float value)
    {
        float AttackPercent = 100;
        float factor = AttackPercent / 100;

        return value * factor;
    }


    public void OnEvent(EventData photonEvent)
    {
        byte code = photonEvent.Code;
        if(code == EventCode.TakeDamage)
        {
            object[] data = (object[])photonEvent.CustomData;
            int viewID = (int)data[0];
            float value = (float)data[1];

            if (viewID == photonView.ViewID)
            {
                Takedamage(value);
            }
        }
    }

}
