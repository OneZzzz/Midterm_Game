using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Event
{
    public class LevelEvent01_friend :ILevelEvent
    {
        public override void LevelEvent()
        {
            gameObject.GetComponent<NPCController>().NPCEvent();
        }

        
    }
}