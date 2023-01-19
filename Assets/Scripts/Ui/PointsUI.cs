using TMPro;
using UnityEngine;

public class PointsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text pointsText;

    private void SetPointsValue(int value)
    {
        pointsText.SetText($"Points: {value}");
    }
    private void OnEnable()
    {
        Player.OnPointsChanged += SetPointsValue;
    }

    private void OnDisable()
    {
        Player.OnPointsChanged -= SetPointsValue;
    }
}
