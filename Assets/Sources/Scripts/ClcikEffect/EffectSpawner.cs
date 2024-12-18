using System;
using UnityEngine;

[Serializable]
public class EffectSpawner
{
    [SerializeField] private RewardText _rewardText;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private float _spawnPositonY;

    private Transform _transform;

    public void Init(Transform transform)
    {
        _transform = transform;
    }

    public RewardText Spawn()
    {
        Vector2 position = _canvas.ScreenToCanvasPosition(Input.mousePosition);

        RewardText rewardText = GameObject.Instantiate(_rewardText, _transform.parent);
        rewardText.SetPosition(position + new Vector2(0, _spawnPositonY));

        return rewardText;
    }

    public RewardText Spawn(Vector2 position)
    {
        return GameObject.Instantiate(_rewardText, _transform.parent);
    }
}
