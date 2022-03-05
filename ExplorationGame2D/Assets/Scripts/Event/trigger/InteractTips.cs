using System.Collections;
using UnityEngine;

namespace Assets.Scripts.game
{
    public class InteractTips : IGameEvent
    {
        public override void GameEvent()
        {
            UIManager.instance.ShowTips("Press the J key to interact");
        }

        
    }
}