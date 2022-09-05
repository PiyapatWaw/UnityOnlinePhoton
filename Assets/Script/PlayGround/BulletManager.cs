using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class BulletManager : MonoBehaviourPunCallbacks,IPunInstantiateMagicCallback
{
    public float damage;
    public Rigidbody r;
    public LayerMask LayerMask;

    float lifetime;
    /*void Start()
    {
        r.velocity = transform.forward*speed;
    }*/

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        object[] instantiationData = info.photonView.InstantiationData;
        r.velocity = (Vector3)instantiationData[0];
        lifetime = (float)instantiationData[1];
        damage = (float)instantiationData[3];
    }

    private void Update()
    {
        //public static bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask);
        RaycastHit hitobject;
        Debug.DrawRay(transform.position, transform.forward*1,Color.blue,1);
        if(Physics.Raycast(transform.position, transform.forward, out hitobject, 1))
        {
            Hit(hitobject.collider.gameObject);
        }

        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            DestroyObject();
    }

    void Hit(GameObject hitobject)
    {
        Debug.LogFormat("Bullet hit {0}", hitobject.name);

        if(hitobject.layer == GameData.PlayerLayer)
        {
            PlayerManager p = hitobject.transform.root.GetComponent<PlayerManager>();
            if (photonView.IsMine)
                SendEvent(p);
            Debug.LogFormat("Take damage to {0}", hitobject.name);
        }

        DestroyObject();
    }

    void DestroyObject()
    {
        if(photonView.IsMine)
        {
            PhotonNetwork.Destroy(this.photonView);
        }
       // Destroy(this.gameObject);
    }

    void SendEvent(PlayerManager p)
    {
        object[] content = new object[] {p.photonView.ViewID, damage};
        PhotonNetwork.RaiseEvent(EventCode.TakeDamage, content, new RaiseEventOptions() { Receivers = ReceiverGroup.All }, SendOptions.SendReliable);
    }
   
}
