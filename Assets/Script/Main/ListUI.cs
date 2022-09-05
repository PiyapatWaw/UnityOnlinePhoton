using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class ListUI<Listobject, Scriptable> : MonoBehaviour
    {
        [SerializeField]
        protected Listobject Prefab;
        public Transform content;
        //public ReddotNotification Reddot;
        public List<Listobject> Allobject = new List<Listobject>();



        public virtual void SetUpList(List<Scriptable> objectList)
        {
            Debug.LogError("Implement SetUpList");
        }

        public virtual void ShowNotification(bool show)
        {

        }
        protected virtual IEnumerator ReceivedAllSuccess()
        {
            yield return null;
        }

    }

