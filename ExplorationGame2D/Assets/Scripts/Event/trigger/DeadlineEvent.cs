using System.Collections;
using UnityEngine;

namespace Assets.Scripts.game
{
    public class DeadlineEvent : IGameEvent
    {
        public override void GameEvent()
        {
            PlayerController.instance.LoadPoint();
        }
    }
}