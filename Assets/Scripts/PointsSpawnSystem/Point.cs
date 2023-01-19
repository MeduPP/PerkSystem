using System;
using UnityEngine;

public class Point : MonoBehaviour
{
    public static Action OnGatePiked;

    public void SelfDestroy()
    {
        OnGatePiked?.Invoke();
        Destroy(gameObject);
    }
}
