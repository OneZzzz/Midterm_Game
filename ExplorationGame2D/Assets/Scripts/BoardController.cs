using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    private Vector3 pos1, pos2;
    public float speed = 3;
    private bool isPos1;

    void Start()
    {
        pos1 = transform.GetChild(0).position;
        pos2 = transform.GetChild(1).position;
        transform.position = pos1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPos1)
        {
            if (Vector3.Distance(transform.position, pos2) < 0.1f) isPos1 = !isPos1;
            Vector3 moveDire = (pos2 - pos1).normalized;
            transform.Translate(moveDire * speed * Time.deltaTime);
        }
        else
        {
            if (Vector3.Distance(transform.position, pos1) < 0.1f) isPos1 = !isPos1;
            Vector3 moveDire = (pos1 - pos2).normalized;
            transform.Translate(moveDire * speed * Time.deltaTime);
        }
    }
}
