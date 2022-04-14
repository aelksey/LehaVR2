using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LehaAnimation : GazeTrigger
{
    public GameObject secondruka;
    public override void Activate()
    {
        
        GetComponent<Animator>().enabled = true;
        GetComponent<Animation>().Play("VertetBeskonechno");
        GetComponent<MeshCollider>().enabled = false;
        secondruka.GetComponent<Animator>().enabled = true;
        secondruka.GetComponent<Animation>().Play("VertetBeskonechno");
        secondruka.GetComponent<MeshCollider>().enabled = false;
    }
}
