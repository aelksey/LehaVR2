using UnityEngine;

public class TriggerBtnMenuBack : GazeTrigger
{
    [SerializeField] private GameObject _exitWindow;

    public override void Activate()
    {
        _exitWindow.SetActive(false);
    }
}
