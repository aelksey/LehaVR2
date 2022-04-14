using UnityEngine;

public class TriggerBtnExit : GazeTrigger
{
    [SerializeField] private GameObject ExitWindow;
    public override void Activate()
    {
        ExitWindow.SetActive(true);
    }
}
