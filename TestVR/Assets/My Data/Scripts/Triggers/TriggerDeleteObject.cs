using UnityEngine;

public class TriggerDeleteObject : GazeTrigger
{
    public override void Activate()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}