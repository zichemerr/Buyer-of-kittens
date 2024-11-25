using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Start()
    {
        _player.Init();
    }
}