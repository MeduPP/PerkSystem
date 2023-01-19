using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _points = 0;
    //Income points per one picked up.
    private int _incomeValue = 1;
    //Called when the points value changes.
    public static Action<int> OnPointsChanged;

    private void Start()
    {
        OnPointsChanged?.Invoke(Points);
    }

    public int Points 
    { 
        get { return _points; } 
        private set { _points = value; } 
    }
    public int IncomeValue 
    {
        get { return _incomeValue; } 
        set { _incomeValue = (value >= 1) ? value : 1; }
    }

    public void ResetBoosts()
    {
        _incomeValue = 1;
    }

    public void AddPoints(int value)
    {
        Points += value;
        OnPointsChanged?.Invoke(Points);
    }

    public bool TrySpendPoints(int cost)
    {
        if(Points >= cost)
        {
            Points -= cost;
            OnPointsChanged?.Invoke(Points);
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Gate"))
        {
            if(other.TryGetComponent(out Point gate))
            {
                AddPoints(_incomeValue);
                gate.SelfDestroy();
            }
        }
    }
}
