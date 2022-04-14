using UnityEngine;

public class TriggerTileChange : GazeTrigger
{
    [SerializeField] private GameObject ActiveTile;
    [SerializeField] private GameObject InactiveTile;
    public override void Activate()
    {
        if (ActiveTile.activeSelf)
        {
            ActiveTile.SetActive(false);
            InactiveTile.SetActive(true);
        }
        else
        {
            ActiveTile.SetActive(true);
            InactiveTile.SetActive(false);
        }
    }
}
