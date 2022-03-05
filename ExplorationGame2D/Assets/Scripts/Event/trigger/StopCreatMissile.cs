using System.Collections;
using UnityEngine;

namespace Assets.Scripts.game
{
    public class StopCreatMissile : IGameEvent
    {
        public override void GameEvent()
        {
            UIManager.instance.ShowTips("You leave the missile area!");
            EnemyCreater.instance.StopCreat();
        }
    }
}