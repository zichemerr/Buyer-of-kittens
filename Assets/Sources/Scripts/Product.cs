using System;
using UnityEngine;

[Serializable]
public struct Product
{
    [SerializeField] private int _price;
    [SerializeField] private int _reward;

    public int Price => _price;
    public int Reward => _reward;
}