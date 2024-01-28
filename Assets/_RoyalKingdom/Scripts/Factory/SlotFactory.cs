using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoyalKingdom.Factory
{
    public class SlotFactory : MonoBehaviour
    {
        public static SlotFactory Inst => _instance;
        private static SlotFactory _instance;

        private void Awake()
        {
            // singleton
            if (_instance)
            {
                Destroy(this);
            }
            else
            {
                _instance = this;
            }
        }
    }
}
