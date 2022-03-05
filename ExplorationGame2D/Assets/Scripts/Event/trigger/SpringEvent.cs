using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringEvent : IGameEvent
{
    public float force = 1000;
    public override void GameEvent()
    {
        Rigidbody2D rg = PlayerController.instance.GetComponent<Rigidbody2D>();
        float add =Mathf.Abs( rg.velocity.y*0.2f) + 1;
        add = (add > 2f) ? 2 : add;
        rg.AddForce(Vector3.up * force*add);
        transform.GetComponent<Animator>().SetTrigger("go");
    }
}
