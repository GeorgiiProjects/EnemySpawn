using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private float _timeToDestroy = 2f;

    void Update()
    {
        Destroy(gameObject, _timeToDestroy);
    }
}
