using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHpEvent : IGameEvent
{
    public override void GameEvent()
    {
        PlayerController.instance.AddHp();
        AudioManager.instance.PlayAudio(AudioManager.instance.addHp);
        Destroy(gameObject);
    }

    
}
