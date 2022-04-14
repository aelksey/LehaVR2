using UnityEngine;

public class  TriggerTeleport : GazeTrigger
{
    [SerializeField] private GameObject _player;

    public override void Activate()
    {
        _player.transform.position = new Vector3(transform.position.x, transform.position.y + 1.7f, transform.position.z);
    }
}