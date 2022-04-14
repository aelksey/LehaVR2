using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeTeleport : MonoBehaviour
{
    public void Blue()
    {
        GetComponent<Renderer>().material.color = new Color32(152, 242, 255, 1);
    }

    public void White()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
}
