using UnityEngine;

public class TriggerPlate : GazeTrigger
{
    [SerializeField] private Transform _player;
    private Transform _object;
    private Gaze _playerGaze;
    private Transform _wordInHend;

    public override void Activate()
    {
        _object = transform;
        _playerGaze = _player.GetComponent<Gaze>();

        if (_playerGaze.Grab == true)
        {
            _wordInHend = _player.GetChild(0).GetChild(2);

            _wordInHend.SetParent(_object);
            _wordInHend.localPosition = new Vector3(0f, -0.0002f, 0f);
            _wordInHend.localRotation = Quaternion.Euler(0f, 0f, 0f);

            _playerGaze.Grab = false;
            
            if (_object.childCount > 1)
            {
                _object.GetChild(0).GetComponent<TriggerGrabToys>().Activate();
            }
        }
        else
        {
            if (_object.childCount > 0)
            {
                _object.GetChild(0).GetComponent<TriggerGrabToys>().Activate();
            }
        }
    }
}
