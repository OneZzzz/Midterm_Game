using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float force = 330,addForce=55;
    private float creatTime;

    private void Start()
    {
        InvokeRepeating("AddSpeed", 1, 0.5f);
    }

    public void Init()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
        
    }

    private void Update()
    {
        creatTime += Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void AddSpeed()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * addForce);
    }
}
