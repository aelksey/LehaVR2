using UnityEngine;

public class TriggerCrane : GazeTrigger
{
    private Transform _object;
    public override void Activate()
    {
        _object = transform;
        _object.GetChild(0).GetComponent<Animation>().Play("Box");
        _object.GetComponent<AudioSource>().Play();
        _object.GetComponent<MeshCollider>().enabled = false;
    }
}