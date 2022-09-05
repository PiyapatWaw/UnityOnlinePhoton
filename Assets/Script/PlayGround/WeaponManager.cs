using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class WeaponManager : MonoBehaviour
{
    public PlayerManager PlayerManager;
    public GameObject Bullet;
    public Transform[] Bulletout;
    public int indexshoot;
    public float Delay;
    float damage = 10;
    float lifetime = 10;
    float bulletspeed = 20;
    const float DelayShoot = 0.05f;

    public void Shooting(bool isshoot)
    {
        if (Delay > 0)
            Delay -= Time.deltaTime;
        else
        {
            if (isshoot)
            {
                Delay = DelayShoot;
                SpawnBullet();
            }
            else
                Delay = 0;
        }
    }

    void SpawnBullet()
    {
        Transform pos = Bulletout[indexshoot];
        indexshoot = indexshoot + 1 == Bulletout.Length ? 0 : indexshoot + 1;
        object[] bulletdata = new object[] { pos.forward* bulletspeed, lifetime, PlayerManager.photonView.ViewID, PlayerManager.GetFactor_Attack(damage) };
        PhotonNetwork.Instantiate(Bullet.name, pos.position, pos.rotation,0, bulletdata);
    }
}
