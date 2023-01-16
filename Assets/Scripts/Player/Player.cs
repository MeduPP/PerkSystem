using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Gate"))
        {
            if(other.TryGetComponent(out Point gate))
            {
                gate.SelfDestroy();
            }
        }
    }
}
