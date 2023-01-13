using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    public void Open(GameObject target)
    {
        target.SetActive(true);
    }

    public void Close(GameObject target)
    {
        target.SetActive(false);
    }
}
