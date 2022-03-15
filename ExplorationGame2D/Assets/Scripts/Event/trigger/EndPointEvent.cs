using System.Collections;
using UnityEngine;

namespace Assets.Scripts.game
{
    [RequireComponent(typeof(SceneController))]
    public class EndPointEvent : IGameEvent
    {
        public override void GameEvent()
        {
            if (UIManager.instance.currentTaskNumber >= UIManager.instance.taskNumber)
            {
                UIManager.instance.ShowWinUI();
            }
            else
            {
                UIManager.instance.ShowTips("You need to find enough apples!");
            }
        }

        
    }
}