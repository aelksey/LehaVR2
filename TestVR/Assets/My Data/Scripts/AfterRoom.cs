using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterRoom : MonoBehaviour
{
    public GameObject door;

    public GameObject saveObject;

    void Start()
    {
        if (saveObject.GetComponent<SaveTrigger>().PassLevel == 1)
        {
            door.GetComponent<SecondRoomManager>().enabled = true;
        }

        if (saveObject.GetComponent<SaveTrigger>().PassLevel == 2)
        {
            door.GetComponent<ThirdRoomManager>().enabled = true;
        }

        if (saveObject.GetComponent<SaveTrigger>().PassLevel == 3)
        {
            door.GetComponent<FourthRoomManager>().enabled = true;
        }
        if (saveObject.GetComponent<SaveTrigger>().PassLevel == 4)
        {
            door.GetComponent<FifthRoomManager>().enabled = true;
        }
    }
}
