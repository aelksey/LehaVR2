using UnityEngine;

public class TriggerBtnSureExit : GazeTrigger
{
    public override void Activate()
    {
        //Debug.Log("УСПЕШНО ВЫШЛО");
        Application.Quit();
    }
}
