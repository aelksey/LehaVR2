using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class GazeTrigger : MonoBehaviour
{
    public abstract void Activate();
}

public class Gaze : MonoBehaviour
{
    [SerializeField] private float _totalTime = 1;
    [SerializeField] private int _distance = 5;
    [HideInInspector] public bool Grab = false;
    private bool _gvrStatus;
    private float _gvrTimer;
    private RaycastHit _hit;

    void Update()
    {
        if (_gvrStatus)
        {
            _gvrTimer += Time.deltaTime;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (_gvrTimer > _totalTime && Physics.Raycast(ray, out _hit, _distance))
        {
            ActivateHit(_hit.transform.GetComponent<GazeTrigger>());
            
            GvrOff();
        }
    }

    public void ActivateHit(GazeTrigger hitObject)
    {
        if (hitObject != null)
        {
            hitObject.Activate();
        }
    }

    public void GvrOn()
    {
        _gvrStatus = true;
        _gvrTimer = 0;
    }

    public void GvrOff()
    {
        _gvrStatus = false;
        _gvrTimer = 0;
    }
}
