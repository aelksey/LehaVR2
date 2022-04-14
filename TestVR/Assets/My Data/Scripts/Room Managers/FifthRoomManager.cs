using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifthRoomManager : MonoBehaviour
{
    [SerializeField] private Transform _player;
    public GameObject room;
    public AudioClip roomSound;
    public AudioClip doorOpenSound;
    public AudioClip doorCloseSound;
    public GameObject corridor;
    public GameObject _probka;
    [SerializeField] private MeshCollider[] _lockerDoors = new MeshCollider[2];
    public GameObject puzzle;
    public GameObject water;
    [SerializeField] private Transform _hand;
    public GameObject podskaz;
    public MeshCollider button;
    public MeshCollider shkafvniz;
    private AudioSource playerSourse;
    private GameObject[] tile = new GameObject[9];
    private MeshCollider[] tileCollider;
    private AudioSource _doorSourse;
    private Animation _doorAnimation;

    private bool openDoor;
    private bool key;
    private bool p;
    private bool endRoom;
    private bool last;

    public void HidePodskaz()
    {
        podskaz.SetActive(false);
    }

    void Start()
    {
        playerSourse = _player.GetComponent<AudioSource>();
        playerSourse.Stop();
        playerSourse.clip = roomSound;
        playerSourse.Play();

        endRoom = false;
        key = false;
        last = false;
        room.SetActive(true);

        _doorAnimation = GetComponent<Animation>();
        _doorAnimation.Play("Door");

        _doorSourse = GetComponent<AudioSource>();
        _doorSourse.PlayOneShot(doorOpenSound);

        openDoor = true;

        tileCollider = new MeshCollider[tile.Length];

        for (int i = 0; i < tile.Length; i++)
        {
            tile[i] = puzzle.transform.GetChild(i).gameObject;
            tileCollider[i] = tile[i].GetComponent<MeshCollider>();
        }

        button.enabled = false;
    }

    void Update()
    {
        if (openDoor)
        {
            if (_player.position.z < -1.5)
            {
                _doorAnimation.Play("DoorClose");
                _doorSourse.PlayOneShot(doorCloseSound);

                Invoke("HidePodskaz", 2f);
                openDoor = false;
            }
        }
        else
        {
            if (_player.GetChild(0).childCount > 2)
            {
                if (!key)
                {
                    foreach (var door in _lockerDoors)
                    {
                        door.enabled = true;
                    }

                    key = true;
                }
            }

            if (_probka.activeSelf == false && key)
            {
                for (int i = 0; i < 9; i++)
                {
                    tileCollider[i].enabled = true;
                }
            }

            if (key)
            {
                p = true;

                for (int i = 0; i < 9; i++)
                {
                    if (tile[i].transform.eulerAngles != new Vector3(270f, 0f, 0f))
                    {
                        p = false;
                    }
                }
            }

            if (key && p && !endRoom)
            {
                for (int i = 0; i < 9; i++)
                {
                    tileCollider[i].enabled = false;
                }

                water.GetComponent<Animation>().Play("Water");
                water.GetComponent<AudioSource>().Play();
                _hand.GetComponent<Animation>().Play("ArmWithKey");
                endRoom = true;
                key = false;
            }
            
            if (_hand.childCount == 0 && last == false)
            {
                shkafvniz.enabled = true;
                button.enabled = true;
                last = true;
            }
        }
    }
}
