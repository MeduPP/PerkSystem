using System.Collections.Generic;
using UnityEngine;

public class LinkDrower : MonoBehaviour
{
    public RectTransform[] target;
    public GameObject linePrefab;
    public Transform lineParent;

    private List<GameObject> _lines = new List<GameObject>();

    [ContextMenu("Drow")]
    private void LineDrower()
    {
        for (int i = 0; i < target.Length; i++)
        {
            _lines.Add(Instantiate(linePrefab, transform));
        }

        int index  = 0;

        foreach (var line in _lines)
        {
            RectTransform reactTransform = line.GetComponent<RectTransform>();
            RectTransform selfRectTransform = GetComponent<RectTransform>();

            Vector3 posSelf = new Vector3(selfRectTransform.transform.localPosition.x, selfRectTransform.transform.localPosition.y, 0);
            Vector3 posTarget = new Vector3(target[index].transform.localPosition.x, target[index].transform.localPosition.y, 0);

            Vector2 difference = posTarget - posSelf;

            float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            line.transform.rotation = Quaternion.Euler(0,0, angle - 90);
            
            Rect rect = reactTransform.rect;  
            reactTransform.sizeDelta = new Vector2(rect.width, difference.magnitude);

            line.transform.SetParent(lineParent);
            index++;
        }
    }
}
