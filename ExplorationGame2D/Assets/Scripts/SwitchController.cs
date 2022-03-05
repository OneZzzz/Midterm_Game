using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public Transform switchCheckPoint;

    public Transform door;
    public BoxCollider2D doorBoxCollider;
    private bool isOpen;
    
    void Update()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(switchCheckPoint.position, Vector2.up, 0.1f);
        if (raycastHit2D)
        {
            if(!isOpen)            AudioManager.instance.PlayAudio(AudioManager.instance.openDoor);
            isOpen = true;
            doorBoxCollider.enabled = false;
            door.eulerAngles = new Vector3(0, 0, 0);

        }
        else
        {
            isOpen = false;
            doorBoxCollider.enabled = true;
            door.eulerAngles = new Vector3(0, 75, 0);

        }
        
    }
}
