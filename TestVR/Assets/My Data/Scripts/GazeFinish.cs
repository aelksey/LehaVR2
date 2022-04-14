using UnityEngine;
using UnityEngine.SceneManagement;

public class GazeFinish : MonoBehaviour
{
    public float totalTime = 2.0f;

    bool gvrStatus;
    float gvrTimer;
    void Start()
    {
        GetComponent<AudioSource>().Play();

    }
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
        }
        if (gvrTimer >= totalTime)
        {
            SceneManager.LoadScene(0);
        }
    }
    public void GvrOn()
    {
        gvrStatus = true;
    }

    public void GvrOff()
    {
        gvrStatus = false;
        gvrTimer = 0;
    }
}