using UnityEngine;

public class TriggerLastButton : GazeTrigger
{
    [SerializeField] private AudioSource playerSourse;
    [SerializeField] private GameObject corridor;
    [SerializeField] private GameObject room;
    [SerializeField] private GameObject finishWindow;
    private Transform _object;

    public override void Activate()
    {
        _object = transform;
        _object.GetComponent<Animation>().Play("Button");

        room.SetActive(false);
        finishWindow.SetActive(true);
        corridor.SetActive(false);
        playerSourse.Stop();
    }
}