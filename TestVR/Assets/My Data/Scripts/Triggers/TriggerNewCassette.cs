using UnityEngine;

public class TriggerNewCassette : GazeTrigger
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource audioSource;

    public override void Activate()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(clip);
        GetComponent<AfterRoom>().enabled = true;
        GetComponent<MeshCollider>().enabled = false;
    }
}
