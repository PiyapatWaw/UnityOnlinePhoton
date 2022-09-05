using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using StarterAssets;

public class ChracterStream : MonoBehaviourPunCallbacks, IPunObservable
{
    public StarterAssetsInputs starterAssetsInputs;

    public Vector3 CurrentPos, NextPos;
    public Quaternion CurrentRot, NextRot;

    public float lerpspeed,lerpdistance,dis;

    private void Awake()
    {
        photonView.Synchronization = ViewSynchronization.Unreliable;
    }

    public override void OnEnable()
    {
        base.OnEnable();
        //PhotonNetwork.NetworkingClient.EventReceived += OnEvent;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        //PhotonNetwork.NetworkingClient.EventReceived -= OnEvent;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //Debug.Log("Stream");
        if (stream.IsWriting)
        {
            Debug.LogError("Write");
            stream.SendNext(CurrentPos);
            stream.SendNext(CurrentRot);
            stream.SendNext(starterAssetsInputs.move);
            stream.SendNext(starterAssetsInputs.look);
            stream.SendNext(starterAssetsInputs.jump);
            stream.SendNext(starterAssetsInputs.sprint);
        }
        //if(stream.IsReading)
        else
        {
            Debug.LogErrorFormat("Read");
            NextPos = (Vector3)stream.ReceiveNext();
            NextRot = (Quaternion)stream.ReceiveNext();
            starterAssetsInputs.move = (Vector2)stream.ReceiveNext();
            starterAssetsInputs.look = (Vector2)stream.ReceiveNext();
            starterAssetsInputs.jump = (bool)stream.ReceiveNext();
            starterAssetsInputs.sprint = (bool)stream.ReceiveNext();
        }
    }

    private void Update()
    {
        CurrentPos = transform.position;
        CurrentRot = transform.rotation;
    }

    private void LateUpdate()
    {
        if (!photonView.IsMine)
        {
            dis = Vector3.Distance(CurrentPos, NextPos);
            if ( Vector3.Distance(CurrentPos, NextPos) >= lerpdistance)
                transform.position = NextPos;
            else
                transform.position = Vector3.Lerp(CurrentPos, NextPos, Time.deltaTime * lerpspeed);
            transform.rotation = Quaternion.Lerp(CurrentRot, NextRot, Time.deltaTime * lerpspeed);
        }
    }
}
