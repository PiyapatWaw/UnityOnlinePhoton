using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class SelectingObjectManager<UI, Slot> : MonoBehaviour
    {
        public Slot[] AllSlot;
        public Slot currentSelect;

        public virtual bool SetCurrentSelect(UI Select)
        {
            return false;
        }

        public virtual bool SetCurrentSelect(UI Select, int index)
        {
            return false;
        }

        public virtual void ReSetCurrentSelect()
        {

        }

        public virtual void SelectSlot(Slot select)
        {

        }

        public virtual void RemoveSelectSlot()
        {
            
        }

        public virtual void RemoveAllSlot()
        {

        }

        public virtual void Relode()
        {

        }
    }
