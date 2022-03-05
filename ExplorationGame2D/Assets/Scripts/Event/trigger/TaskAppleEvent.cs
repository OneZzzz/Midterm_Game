using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Event.trigger
{
    public class TaskAppleEvent : IGameEvent
    {
        public override void GameEvent()
        {
            UIManager.instance.FindTaskApple();
            Destroy(gameObject);
        }

       
    }
}