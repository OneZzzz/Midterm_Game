using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.game
{
    public class DeadlineEvent : IGameEvent
    {
        public override void GameEvent()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}