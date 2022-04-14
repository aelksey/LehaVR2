using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthRoomManager : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject room;
    [SerializeField] private AudioClip roomSound;
    [SerializeField] private AudioClip doorOpenSound;
    [SerializeField] private AudioClip doorCloseSound;
    [SerializeField] private SaveTrigger saveObject;
    [SerializeField] private GameObject firstWord;
    private Transform[] plates;
    private MeshCollider[] platesCollider;
    [SerializeField] private GameObject[] word = new GameObject[13];
    [SerializeField] private GameObject s1;
    [SerializeField] private GameObject s2;
    [SerializeField] private GameObject s3;
    [SerializeField] private GameObject s4;
    [SerializeField] private GameObject w1;
    [SerializeField] private GameObject w2;
    [SerializeField] private GameObject w3;
    [SerializeField] private GameObject w4;
    [SerializeField] private GameObject Cassette;
    [SerializeField] private GameObject podskaz;
    private AudioSource playerSourse;
    private AudioClip corridorSound;
    private AudioSource _doorSourse;
    private Animation _doorAnimation;
    private bool openDoor;
    private bool firstWordF;
    bool endRoom;

    public void HidePodskaz()
    {
        podskaz.SetActive(false);
    }

    void Start()
    {
        playerSourse = _player.GetComponent<AudioSource>();
        playerSourse.Stop();
        corridorSound = playerSourse.clip;
        playerSourse.clip = roomSound;
        playerSourse.Play();

        room.SetActive(true);
        openDoor = true;

        _doorAnimation = GetComponent<Animation>();
        _doorAnimation.Play("Door");

        _doorSourse = GetComponent<AudioSource>();
        _doorSourse.PlayOneShot(doorOpenSound);

        endRoom = false;

        plates = new Transform[word.Length];
        platesCollider = new MeshCollider[plates.Length];

        for (int i = 0; i < plates.Length; i++)
        {
            plates[i] = firstWord.transform.GetChild(i);
            platesCollider[i] = plates[i].GetComponent<MeshCollider>();
        }
    }

    void Update()
    {
        if (openDoor)
        {
            if (_player.position.z > 2)
            {
                _doorAnimation.Play("DoorClose");
                _doorSourse.PlayOneShot(doorCloseSound);
                Invoke("HidePodskaz", 2f);
                openDoor = false;
            }
        }
        else
        {
            if (w1.activeSelf && w2.activeSelf && w3.activeSelf && w4.activeSelf)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    platesCollider[i].enabled = true;
                }

                firstWordF = true;

                for (int i = 0; i < word.Length; i++)
                {
                    if (plates[i].childCount == 1 && plates[i].GetChild(0).gameObject == word[i])
                    {
                        platesCollider[i].enabled = false;
                    }
                    else
                    {
                        firstWordF = false;
                        break;
                    }
                }
            }

            if (!s1.activeSelf)
            {
                w1.SetActive(true);
            }

            if (!s2.activeSelf)
            {
                w2.SetActive(true);
            }

            if (!s3.activeSelf)
            {
                w3.SetActive(true);
            }

            if (!s4.activeSelf)
            {
                w4.SetActive(true);
            }

            if (w1.activeSelf && w2.activeSelf && w3.activeSelf && w4.activeSelf && firstWordF)
            {
                if (!endRoom)
                {
                    _doorAnimation.Play("Door");
                    _doorSourse.PlayOneShot(doorOpenSound);
                    endRoom = true;
                }

                if (_player.position.z < 2)
                {
                    _doorAnimation.Play("DoorClose");
                    _doorSourse.PlayOneShot(doorCloseSound);
                    room.SetActive(false);
                    playerSourse.Stop();
                    playerSourse.clip = corridorSound;
                    playerSourse.Play();

                    saveObject.PassLevel = 4;
                    PlayerPrefs.SetInt("PassLevel", saveObject.PassLevel);
                    Cassette.SetActive(true);
                    transform.GetComponent<FourthRoomManager>().enabled = false;
                }
            }
            
        }
    }
}
