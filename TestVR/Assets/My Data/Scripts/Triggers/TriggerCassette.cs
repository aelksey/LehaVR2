using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCassette : GazeTrigger
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject aciveCassette;
    [SerializeField] private GameObject nextObject;
    [SerializeField] private MonoBehaviour _DoorActivatorScript;

    public override void Activate()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(_clip);

        if (nextObject.tag == "Door")
        {
            nextObject.GetComponent<FirstRoomManager>().enabled = true;
        }
        nextObject.SetActive(true);
        aciveCassette.SetActive(true);
        gameObject.SetActive(false);
        _DoorActivatorScript.enabled = true;
    }
}
