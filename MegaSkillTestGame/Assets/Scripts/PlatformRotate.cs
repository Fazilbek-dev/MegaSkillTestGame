using UnityEngine;

public class PlatformRotate : MonoBehaviour
{
    [SerializeField] private float _speedRotate = 5f;

    private void Update()
    {
        transform.Rotate(0f, _speedRotate * Time.deltaTime, 0f);
    }
}
