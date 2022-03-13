using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Assets.Scripts.game
{
    public class EnemyEvent : IGameEvent
    {
        public override void GameEvent()
        {
            PlayerController.instance.LoadPoint();
        }
    }
}