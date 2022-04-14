using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerFinishBtn : GazeTrigger
{
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }

    public override void Activate()
    {
        SceneManager.LoadScene(0);
    }
}
