using UnityEngine;

public class UIButton : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private GameObject _colorButtons;
    [SerializeField] private GameObject _sculptButtons;

    public void Capsule(GameObject _gameObject)
    {
        Instantiate<GameObject>(_gameObject, null);
        _gameObject.transform.position = _spawnPoint.position;
    }

    public void ColorButton()
    {
        _colorButtons.SetActive(true);
        _sculptButtons.SetActive(false);
    }
    public void SculptButton()
    {
        _colorButtons.SetActive(false);
        _sculptButtons.SetActive(true);
    }
}
