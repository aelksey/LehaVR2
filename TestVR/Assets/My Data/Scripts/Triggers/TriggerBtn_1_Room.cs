using UnityEngine;

public class TriggerBtn_1_Room : GazeTrigger
{
    public override void Activate()
    {
        transform.Rotate(new Vector3(90f, 0f, 0f));
    }
}
