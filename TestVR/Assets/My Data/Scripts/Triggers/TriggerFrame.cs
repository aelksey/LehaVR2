using UnityEngine;

public class TriggerFrame : GazeTrigger
{
    [SerializeField] private GameObject _playerCamera;
    [SerializeField] private Gaze _playerGaze;
    public override void Activate()
    {
        if (_playerGaze.Grab == true)
        {
            _playerCamera.transform.GetChild(2).position = gameObject.transform.position;
            _playerCamera.transform.GetChild(2).rotation = gameObject.transform.rotation;

            _playerCamera.transform.GetChild(2).SetParent(null);
        }
        _playerGaze.Grab = false;
    }
}
