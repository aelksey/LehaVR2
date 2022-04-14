using UnityEngine;

public class TriggerRotation90 : GazeTrigger
{
    public override void Activate()
    {
        transform.Rotate(new Vector3(90f, 0f, 0f));
    }
}