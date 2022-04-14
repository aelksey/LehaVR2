using UnityEngine;

public class Code : MonoBehaviour
{
    public Material material;
    public Material materialwrong1;
    public Material materialwrong2;
    public float totalTime = 2f;
    public GameObject nextNumber;
    
    public AudioClip clip;

    float timer;

    void OnEnable()
    {
        
        material.DisableKeyword("_EMISSION");
        materialwrong1.DisableKeyword("_EMISSION");
        materialwrong2.DisableKeyword("_EMISSION");
        timer = 0;
        gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
        material.EnableKeyword("_EMISSION");
        materialwrong1.EnableKeyword("_EMISSION");
        materialwrong2.EnableKeyword("_EMISSION");
        
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= totalTime)
        {
            material.DisableKeyword("_EMISSION");
            materialwrong1.DisableKeyword("_EMISSION");
            materialwrong2.DisableKeyword("_EMISSION");

            if (nextNumber != null)
            {
                nextNumber.GetComponent<Code>().enabled = true;
            }

            GetComponent<Code>().enabled = false;
        }
    }
}
