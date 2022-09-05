using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class ObjectUIInListSelector<Scriptable> : ObjectInListUI<Scriptable>
    {
        public bool inuse;
        public bool Remove, Clear;

        public virtual void SetRemoveOrClear(bool clear)
        {
            Remove = !clear;
            Clear = clear;
        }

        public virtual void SetdataIsSelect(Scriptable data)
        {

        }

        public virtual void RemoveOrclear()
        {
            if (Remove)
            {
                OnRemove();
            }
            else if (Clear)
            {
                OnClear();
            }
        }

        public virtual void OnSelect()
        {
            
        }

        public virtual void OnDeselect()
        {
            
        }

        public virtual void OnRemove()
        {

        }

        public virtual void OnClear()
        {

        }
    }

