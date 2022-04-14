using UnityEngine;

public class ThirdRoomManager : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _room;
    [SerializeField] private AudioClip _roomSound;
    [SerializeField] private AudioClip _doorOpenSound;
    [SerializeField] private AudioClip _doorCloseSound;
    [SerializeField] private SaveTrigger _saveObject;
    [SerializeField] private GameObject[] toys = new GameObject[3];

    [SerializeField] private MeshCollider _boxCollider;

    [SerializeField] private GameObject _framesForSpace;
    [SerializeField] private Transform[] _frame = new Transform[3];

    [SerializeField] private GameObject[] space = new GameObject[3];

    [SerializeField] private Material emissionMaterial;

    [SerializeField] private GameObject roomLight;

    [SerializeField] private GameObject deleteToys;

    [SerializeField] private GameObject Cassette;
    [SerializeField] private GameObject _helper;
    private AudioSource _doorSourse;
    private Animation _doorAnimation;
    private AudioSource playerSourse;
    private AudioClip corridorSound;
    private bool openDoor;
    private bool position;
    private bool endRoom;
    private bool toyF;
    private bool time;

    float timer = 0;

    public void HidePodskaz()
    {
        _helper.SetActive(false);
    }

    void Start()
    {
        playerSourse = _player.GetComponent<AudioSource>();
        playerSourse.Stop();
        corridorSound = playerSourse.clip;
        playerSourse.clip = _roomSound;
        playerSourse.Play();

        emissionMaterial.DisableKeyword("_EMISSION");

        _framesForSpace.SetActive(false);
        _room.SetActive(true);
        position = false;
        openDoor = true;
        endRoom = false;
        time = true;

        _doorAnimation = GetComponent<Animation>();
        _doorAnimation.Play("Door");

        _doorSourse = GetComponent<AudioSource>();
        _doorSourse.PlayOneShot(_doorOpenSound);

    }

    void Update()
    {
        if (openDoor)
        {
            if (_player.position.z < -1.5)
            {
                _doorAnimation.Play("DoorClose");
                _doorSourse.PlayOneShot(_doorCloseSound);

                Invoke("HidePodskaz", 2f);
                openDoor = false;
            }
        }
        else
        {
            toyF = true;

            foreach (var toy in toys)
            {
                if (toy.activeSelf == true)
                {
                    toyF = false;
                    break;
                }
            }

            if (toyF)
            {
                roomLight.SetActive(false);
                _boxCollider.enabled = false;

                timer += Time.deltaTime;
            }

            if (timer >= 1f && time)
            {
                deleteToys.SetActive(false);

                emissionMaterial.EnableKeyword("_EMISSION");

                _framesForSpace.SetActive(true);

                foreach (var element in space)
                {
                    EnebleElement(element, true);
                }

                time = false;
            }

            if (!position)
            {
                position = true;

                for (int i = 0; i < space.Length; i++)
                {
                    if (space[i].transform.position == _frame[i].position)
                    {
                        EnebleElement(space[i], false);
                        _frame[i].gameObject.SetActive(false);
                    }
                    else
                    {
                        position = false;
                    }
                }
            }
            else
            {
                _framesForSpace.SetActive(false);
                roomLight.SetActive(true);

                foreach (var element in space)
                {
                    EnebleElement(element, false);
                }

                if (!endRoom)
                {
                    _doorAnimation.Play("Door");
                    _doorSourse.PlayOneShot(_doorOpenSound);
                    endRoom = true;
                }

                if (_player.position.z > -1.5)
                {
                    _doorAnimation.Play("DoorClose");
                    _doorSourse.PlayOneShot(_doorCloseSound);
                    _room.SetActive(false);

                    foreach (var item in space)
                    {
                        item.SetActive(false);
                    }
                    
                    playerSourse.Stop();
                    playerSourse.clip = corridorSound;
                    playerSourse.Play();

                    _saveObject.PassLevel = 3;
                    PlayerPrefs.SetInt("PassLevel", _saveObject.PassLevel);
                    Cassette.SetActive(true);
                    transform.GetComponent<ThirdRoomManager>().enabled = false;
                }
            }
        }
    }

    private void EnebleElement(GameObject element, bool status)
    {
        element.transform.GetChild(0).gameObject.SetActive(status);
        element.GetComponent<MeshCollider>().enabled = status;
    }
}
