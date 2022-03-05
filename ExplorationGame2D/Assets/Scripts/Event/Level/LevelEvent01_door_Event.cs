using System.Collections;
using UnityEngine;

namespace Assets.Scripts.game
{
    public class LevelEvent01_door_Event : ILevelEvent
    {

        public Transform targetTransform;

        public override void LevelEvent()
        {
            PlayerController.instance.MoveTargetRaw(targetTransform.position);
        }

    }
}