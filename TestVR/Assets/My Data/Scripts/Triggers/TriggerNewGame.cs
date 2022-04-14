using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerNewGame : GazeTrigger
{
    public override void Activate()
    {
        PlayerPrefs.SetInt("PassLevel", 0);
        SceneManager.LoadScene(1);
    }
}