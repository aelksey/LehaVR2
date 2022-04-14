using System.Collections;
using UnityEngine;

public class StartCode : GazeTrigger
{
    public GameObject firstNumber;

    public override void Activate()
    {
        firstNumber.GetComponent<Code>().enabled = true;
    }
}
