using UnityEngine;

public class TriggerGrabToys : GazeTrigger
{
    [SerializeField] private Transform _playerCamera;
    [SerializeField] private Gaze _playerGaze;
    private Transform _object;
    public override void Activate()
    {
        _object = transform;

        if (_playerGaze.Grab == false)
        {
            _object.SetParent(_playerCamera);
            _object.position = _playerCamera.position;
            _object.localPosition = new Vector3(-0.333f, -0.199f, 0.623f);
            _object.localEulerAngles = new Vector3(2.143f, 137.721f, 42.512f);
            GetComponent<Renderer>().material.color = Color.red;
        }
        _playerGaze.Grab = true;
    }
}
