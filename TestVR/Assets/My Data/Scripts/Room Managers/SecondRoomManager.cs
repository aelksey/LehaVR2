using UnityEngine;

public class SecondRoomManager : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _room;
    [SerializeField] private AudioClip _roomSound;
    [SerializeField] private AudioClip _doorOpenSound;
    [SerializeField] private AudioClip _doorCloseSound;
    [SerializeField] private SaveTrigger _saveObject;
    [SerializeField] private GameObject[] _plate = new GameObject[16];
    [SerializeField] private GameObject[] _plateActive = new GameObject[16];
    private MeshCollider[] _plateCollider = new MeshCollider[16];
    private MeshCollider[] _plateActiveCollider = new MeshCollider[16];
    [SerializeField] private GameObject _cassette;
    [SerializeField] private GameObject _helper;
    private AudioSource _playerSourse;
    private AudioClip _corridorSound;
    private AudioSource _doorSourse;
    private Animation _doorAnimation;
    private float volume;
    private bool plateRight;
    private bool openDoor;
    private bool endRoom;

    void Start()
    {
        _playerSourse = _player.GetComponent<AudioSource>();
        _playerSourse.Stop();
        _corridorSound = _playerSourse.clip;
        _playerSourse.clip = _roomSound;
        volume = _playerSourse.volume;
        _playerSourse.volume = 0.1f;
        _playerSourse.Play();

        plateRight = false;
        openDoor = true;
        endRoom = false;

        _room.SetActive(true);

        _doorAnimation = GetComponent<Animation>();
        _doorAnimation.Play("Door");

        _doorSourse = GetComponent<AudioSource>();
        _doorSourse.PlayOneShot(_doorOpenSound);

        for (int i = 0; i < _plate.Length; i++)
        {
            _plateCollider[i] = _plate[i].GetComponent<MeshCollider>();
            _plateActiveCollider[i] = _plateActive[i].GetComponent<MeshCollider>();
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
            if (_player.position.z > 2)
            {
                _doorAnimation.Play("DoorClose");
                _doorSourse.PlayOneShot(_doorCloseSound);

                Invoke("HelperHide", 2f);
                openDoor = false;
            }
        }
        else
        {
            plateRight = false;

            for (int i = 0; i < _plateCollider.Length; i++)
            {
                if (i == 6 || i == 10 || i == 12 || i == 15)
                {
                    if (_plate[i].activeSelf == false)
                    {
                        plateRight = true;
                    }
                    else
                    {
                        plateRight = false;
                        break;
                    }
                }
                else
                {
                    if (_plate[i].activeSelf == true)
                    {
                        plateRight = true;
                    }
                    else
                    {
                        plateRight = false;
                        break;
                    }
                }
            }

            if (endRoom == false && plateRight == true)
            {
                _doorAnimation.Play("Door");
                _doorSourse.PlayOneShot(_doorOpenSound);

                endRoom = true;
            }

            if (plateRight == true)
            {
                for (int i = 0; i < _plateCollider.Length; i++)
                {
                    _plateCollider[i].enabled = false;
                    _plateActiveCollider[i].enabled = false;
                }

                plateRight = false;
            }

            if (_player.position.z < 2)
            {
                _doorAnimation.Play("DoorClose");
                _doorSourse.PlayOneShot(_doorCloseSound);

                _room.SetActive(false);

                _playerSourse.Stop();
                _playerSourse.clip = _corridorSound;
                _playerSourse.volume = volume;
                _playerSourse.Play();

                _saveObject.PassLevel = 2; 
                PlayerPrefs.SetInt("PassLevel", _saveObject.PassLevel); 
                _cassette.SetActive(true);
                transform.GetComponent<SecondRoomManager>().enabled = false;
            }
        }
    }
}
