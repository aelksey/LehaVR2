using UnityEngine;

public class FirstRoomManager : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _room;
    [SerializeField] private AudioClip _roomSound;
    [SerializeField] private AudioClip _doorOpenSound;
    [SerializeField] private AudioClip _doorCloseSound;
    [SerializeField] private GameObject _lamp;
    [SerializeField] private SaveTrigger _saveObject;
    [SerializeField] private GameObject _cassette;
    [SerializeField] private GameObject _helper;
    [SerializeField] private Transform[] _arrows = new Transform[5];
    [SerializeField] private GameObject[] _frameNumber = new GameObject[5];
    private BoxCollider[] _arrowCollider;
    private AudioSource _doorSourse;
    private Animation _doorAnimation;
    private int arrowRight;
    private int numberActive;
    private Vector3[] arrowRotate =
    {
        new Vector3(180f, 0f, 0f),
        new Vector3(270f, 0f, 0f),
        new Vector3(0f, 0f, 0f),
        new Vector3(90f, 0f, 0f),
        new Vector3(90f, 0f, 0f),
    };
    private AudioSource _playerSourse;
    private AudioClip _corridorSound;
    private bool openDoor;
    private bool buttonFlag;
    private bool arrowFlag;
    private bool endRoom;

    void Start()
    {
        _playerSourse = _player.GetComponent<AudioSource>();
        _playerSourse.Stop();
        _corridorSound = _playerSourse.clip;
        _playerSourse.clip = _roomSound;
        _playerSourse.Play();

        _room.SetActive(true);

        _doorAnimation = GetComponent<Animation>();
        _doorAnimation.Play("Door");

        _doorSourse = GetComponent<AudioSource>();
        _doorSourse.PlayOneShot(_doorOpenSound);

        openDoor = true;
        arrowFlag = true;
        buttonFlag = true;
        endRoom = false;

        _arrowCollider = new BoxCollider[_arrows.Length];

        for (int i = 0; i < _arrowCollider.Length; i++)
        {
            _arrowCollider[i] = _arrows[i].GetComponent<BoxCollider>();
            _arrowCollider[i].enabled = false;
        }
    }
    public void HelperHide()
    {
        _helper.SetActive(false);
    }

    void Update()
    {
        if (openDoor == true)
        {
            if (_player.position.x < -5)
            {
                _doorAnimation.Play("DoorClose");
                _doorSourse.PlayOneShot(_doorCloseSound);
                _lamp.SetActive(false);
                Invoke("HelperHide", 2f);
                openDoor = false;
                buttonFlag = false;
            }
        }

        if (buttonFlag == false)
        {
            numberActive = 0;

            for (int i = 0; i < _arrowCollider.Length; i++)
            {
                if (_frameNumber[i].activeSelf == true)
                {
                    _arrowCollider[i].enabled = true;
                    numberActive++;
                }
            }

            if (numberActive == 5)
            {
                buttonFlag = true;
                arrowFlag = false;
            }
        }

        if (arrowFlag == false)
        {
            arrowRight = 0;

            for (int i = 0; i < arrowRotate.Length; i++)
            {
                if (_arrows[i].eulerAngles == arrowRotate[i])
                {
                    arrowRight++;
                }
            }

            if (arrowRight == 5)
            {
                if (endRoom == false)
                {
                    for (int i = 0; i < _arrowCollider.Length; i++)
                    {
                        _arrowCollider[i].enabled = false;
                    }

                    _doorAnimation.Play("Door");
                    _doorSourse.PlayOneShot(_doorOpenSound);
                    endRoom = true;
                }

                if (_player.position.x > -5)
                {   
                    _lamp.SetActive(true);
                    _doorAnimation.Play("DoorClose");
                    _doorSourse.PlayOneShot(_doorCloseSound);

                    _room.SetActive(false);

                    _playerSourse.Stop();
                    _playerSourse.clip = _corridorSound;
                    _playerSourse.Play();

                    _saveObject.PassLevel = 1;
                    PlayerPrefs.SetInt("PassLevel", _saveObject.PassLevel);
                    _cassette.SetActive(true);
                    transform.GetComponent<FirstRoomManager>().enabled = false;
                }
            }
        }
    }
}
