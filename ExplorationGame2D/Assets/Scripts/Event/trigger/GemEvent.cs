using System.Collections;
using UnityEngine;

namespace Assets.Scripts.game
{
    public class GemEvent : IGameEvent
    {
        public override void GameEvent()
        {
            PlayerController.instance.isFindGem = true;
            AudioManager.instance.PlayAudio(AudioManager.instance.gem);
            Destroy(gameObject);
        }

       
    }
}