using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ClickEffect : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Image _imagePrefab;
    [SerializeField] private float _spawnPositonY;
    [SerializeField] private float _endPositionY;
    [SerializeField] private float _duration;

    private ClickerZone _clickerZone;

    public void Init(ClickerZone clickerZone)
    {
        _clickerZone = clickerZone;
        _clickerZone.Clicked += OnSpawn;
    }

    private void OnDisable()
    {
        _clickerZone.Clicked -= OnSpawn;
    }

    private void OnSpawn()
    {
        //Spawn
        Vector2 position = _canvas.ScreenToCanvasPosition(Input.mousePosition);
        Image image = Instantiate(_imagePrefab, this.transform.parent);
        Transform transform = image.transform;
        transform.position = position + new Vector2(0, _spawnPositonY);

        //Animation
        transform.DOMoveY(transform.position.y + _endPositionY, _duration);
        image.DOFade(0, _duration).onComplete += () => Destroy(image.gameObject);
    }
}
