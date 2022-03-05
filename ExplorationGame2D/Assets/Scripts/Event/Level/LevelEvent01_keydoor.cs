using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEvent01_keydoor : ILevelEvent
{
    public override void LevelEvent()
    {
        if (PlayerController.instance.isFindKey)
        {
            Destroy(gameObject);
            AudioManager.instance.PlayAudio(AudioManager.instance.openDoor);
        }
        else
        {
            UIManager.instance.ShowTips("You need find key!");
        }
    }

   
}
