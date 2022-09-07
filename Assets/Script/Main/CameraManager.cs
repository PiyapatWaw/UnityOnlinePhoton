using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instanst;

    public const int Lobby = 0;
    public const int Apperance = 1;

    [SerializeField]
    private Transform[] Allpos;
    [SerializeField]
    private float speed;
    private Coroutine moveCoroutine;

    private void Awake()
    {
        instanst = this;
    }

    public void MoveCamera(int index)
    {
        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine);

        moveCoroutine = StartCoroutine(OnMove(Allpos[index]));
    }

    IEnumerator OnMove(Transform target)
    {
        float t = 0;

        Vector3 startposition = Camera.main.transform.position;
        Vector3 starteuler = Camera.main.transform.eulerAngles;

        while (t<1)
        {
            t += Time.deltaTime * speed;

            Camera.main.transform.position = Vector3.Lerp(startposition, target.position,t);
            Camera.main.transform.eulerAngles = Vector3.Lerp(starteuler, target.eulerAngles, t);

            yield return null;
        }


        moveCoroutine = null;
    }
}
