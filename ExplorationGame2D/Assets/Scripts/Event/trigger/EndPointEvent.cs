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

                SceneController co = GetComponent<SceneController>();
                if (co == null) return;
                co.EndPointChangeScene();
            }
            else
            {
                UIManager.instance.ShowTips("You need to find enough apples!");
            }
        }

        
    }
}