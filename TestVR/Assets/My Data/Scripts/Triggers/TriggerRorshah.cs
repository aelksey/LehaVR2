using UnityEngine;

public class TriggerRorshah : GazeTrigger
{
    [SerializeField] private GameObject trueImage;
    [SerializeField] private GameObject number;

    public override void Activate()
    {
        gameObject.SetActive(false);
        trueImage.SetActive(true);
        number.SetActive(true);
        GetComponent<Collider>().enabled = false;
    }
}
