using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Assets.Scripts.game
{
    public class EnemyEvent : IGameEvent
    {
        public override void GameEvent()
        {
            AudioManager.instance.PlayAudio(AudioManager.instance.enemy);
            GameObject go= Resources.Load<GameObject>("enemy-death");
            Destroy( Instantiate(go,transform.position,Quaternion.identity),1.0f);
            PlayerController.instance.BeInjured();
            Destroy(gameObject);
        }
    }
}