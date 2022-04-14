using UnityEngine;

public class TriggerLocker : GazeTrigger
{
    [SerializeField] private Transform _player;
    private Transform _leftDoor;
    private Transform _rightDoor;

    public override void Activate()
    {
        _leftDoor = transform.parent.GetChild(0);
        _rightDoor = transform.parent.GetChild(1);

        _leftDoor.GetComponent<Animation>().Play("DoorLeft");
        _leftDoor.GetComponent<MeshCollider>().enabled = false;

        _rightDoor.GetComponent<Animation>().Play("DoorRight");
        _rightDoor.GetComponent<MeshCollider>().enabled = false;

        _player.GetChild(0).GetChild(2).gameObject.SetActive(false);
        _player.GetChild(0).GetChild(2).SetParent(null);

        _player.GetComponent<Gaze>().Grab = false;
    }
}