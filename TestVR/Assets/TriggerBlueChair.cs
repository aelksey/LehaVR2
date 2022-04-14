using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBlueChair : GazeTrigger
{
    public override void Activate()
    {
        gameObject.SetActive(false);
    }
}
