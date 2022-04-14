using UnityEngine;

public class TriggerLockerDoor : GazeTrigger
{
    [SerializeField] private Transform _player;

    private Transform _object;

    public override void Activate()
    {
        _object = transform;

        _object.GetComponent<Animation>().Play("f1");
        _object.GetComponent<MeshCollider>().enabled = false;

        _player.GetChild(0).GetChild(2).gameObject.SetActive(false);
        _player.GetChild(0).GetChild(2).SetParent(null);

        _player.GetComponent<Gaze>().Grab = false;
    }
}