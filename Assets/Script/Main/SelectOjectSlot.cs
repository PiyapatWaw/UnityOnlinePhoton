using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class SelectOjectSlot<UI, Scriptable> : MonoBehaviour
    {
        public UI MyUI;
        protected Scriptable data;
        protected UI uiObjectInList;

        public virtual void Click()
        {

        }

        public virtual void SetSelect(UI select)
        {

        }

        public virtual void DeSelect()
        {

        }

        public virtual void ReturnUIToList()
        {

        }

        public Scriptable GetData()
        {
            return data;
        }

        public bool TryGetData(out Scriptable data)
        {
            data = this.data;
            return this.data != null;
        }

        public bool IsData()
        {
            return this.data != null;
        }
    }
