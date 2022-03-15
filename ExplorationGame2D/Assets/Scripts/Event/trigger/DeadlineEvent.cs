﻿using System.Collections;
using UnityEngine;

namespace Assets.Scripts.game
{
    public class DeadlineEvent : IGameEvent
    {
        public override void GameEvent()
        {
            AudioManager.instance.PlayAudio(AudioManager.instance.deadline);
            UIManager.instance.ShowLoseUI();
        }
    }
}