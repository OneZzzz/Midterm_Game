using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    private float y = 3;

    private float speed = 4;


    private void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        float dis=0;
        while (true)
        {
            dis += speed * 0.02f;
            if (dis <= y)
            {
                transform.Translate(0, speed * 0.02f, 0);
                yield return new WaitForSeconds(0.02f);
            }
            else if (dis <= 2*y){
                transform.Translate(0, -speed * 0.02f, 0);
                yield return new WaitForSeconds(0.02f);
            }
            else
            {
                dis = 0;
                yield return new WaitForSeconds(1);
            }
        }
    }

}
