using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Event.trigger
{
    public class SavePointEvent : IGameEvent
    {
        public override void GameEvent()
        {
            PlayerController.instance.SavePoint();
            UIManager.instance.ShowTips("The archive success!");
            GetComponent<SpriteRenderer>().color = Color.red;
            AudioManager.instance.PlayAudio(AudioManager.instance.save);
            Destroy(this);
        }

        
    }
}