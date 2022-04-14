using UnityEngine;

public class TriggerBox : GazeTrigger
{
    [SerializeField] private GameObject _playerCamera;
    [SerializeField] private Gaze _playerGaze;
    public override void Activate()
    {
        if(_playerGaze.Grab == true)
        {
            _playerCamera.transform.GetChild(2).gameObject.SetActive(false);
            _playerCamera.transform.GetChild(2).SetParent(null);

            _playerGaze.Grab = false;
        }
    }
}
