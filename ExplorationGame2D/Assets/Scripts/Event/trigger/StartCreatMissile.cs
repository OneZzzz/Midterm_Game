using System.Collections;
using UnityEngine;

namespace Assets.Scripts.game
{
    public class StartCreatMissile : IGameEvent
    {
        public override void GameEvent()
        {
            UIManager.instance.ShowTips("You enter the missile range!");
            EnemyCreater.instance.StartCreat();
        }
    }
}