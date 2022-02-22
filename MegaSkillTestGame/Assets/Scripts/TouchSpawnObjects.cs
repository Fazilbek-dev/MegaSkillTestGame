using UnityEngine;

public class TouchSpawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject _trajectory;
    [SerializeField] private float _force = 60f;
    [SerializeField] private bool _isColor;
    [SerializeField] private bool _onPlatform;

    private Rigidbody _rb;

    private Vector3 _pointScreen;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && !_onPlatform)
            {
                _pointScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            }
            if(touch.phase == TouchPhase.Moved && !_onPlatform)
            {
                Vector3 curScreenPoint = new Vector3(touch.position.x, touch.position.y, _pointScreen.z);
                Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
                transform.position = curPosition;
            }
            if(touch.phase == TouchPhase.Ended)
            {
                _rb.isKinematic = false;
                _rb.AddForce(transform.up * (_force / 6f));
                _trajectory.SetActive(false);
            }
        }
    }

    private void OnMouseDown()
    {
        _pointScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    }
    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _pointScreen.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        transform.position = curPosition;
    }
    private void OnMouseUp()
    {
        _rb.isKinematic = false;
        _rb.AddForce(transform.up * _force);
        _trajectory.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Platform" && !_isColor)
        {
            transform.parent = collision.transform;
            _onPlatform = true;
        }
        if(collision.gameObject.tag == "Sculpt" && _isColor)
        {
            collision.gameObject.GetComponent<MeshRenderer>().material =
                this.gameObject.GetComponent<MeshRenderer>().material;
            Destroy(this.gameObject);
        }
    }
}
