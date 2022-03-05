using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Event
{
    public class LevelEvent01_tasknpc : ILevelEvent
    {
        public override void LevelEvent()
        {
            if (PlayerController.instance.isFindGem)
            {
                PlayerController.instance.isFindKey = true;
                gameObject.GetComponent<TaskNpc>().ElseNpcEvent();

                AudioManager.instance.PlayAudio(AudioManager.instance.key);
            }
            else
            {
                gameObject.GetComponent<TaskNpc>().NPCEvent();

            }
        }

        
    }
}