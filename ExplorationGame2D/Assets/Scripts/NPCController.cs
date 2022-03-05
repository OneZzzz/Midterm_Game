using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public List<string> message=new List<string>();

    public virtual void NPCEvent()
    {
        UIManager.instance.ShowDialo(message);

    }
}
