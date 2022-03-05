using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskNpc : NPCController
{
    public List<string> me;

    public override void NPCEvent()
    {
        base.NPCEvent();
    }
    public void ElseNpcEvent()
    {
        UIManager.instance.ShowDialo(me);
    }
}
