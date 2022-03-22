using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObRotate : MonoBehaviour
{
    private float rotateSpeed = 80f;
    private float t=0.02f;

    private void Start()
    {
        StartCoroutine(Rotate());
    }


    IEnumerator Rotate()
    {
        while (true)
        {
            transform.Rotate(0, 0, rotateSpeed * t);
            yield return new WaitForSeconds(t);
        }
    }


}
