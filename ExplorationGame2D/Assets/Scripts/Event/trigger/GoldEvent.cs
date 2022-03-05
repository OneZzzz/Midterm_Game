using System.Collections;
using UnityEngine;

namespace Assets.Scripts.game
{
    public class GoldEvent :IGameEvent
    {
        public override void GameEvent()
        {

            PlayerController.instance.score++;
            Destroy(gameObject);
            UIManager.instance.ShowScore(PlayerController.instance.score);
            AudioManager.instance.PlayAudio(AudioManager.instance.coin);
        }

        
    }
}