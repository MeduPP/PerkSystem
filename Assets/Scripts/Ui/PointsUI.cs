using TMPro;
using UnityEngine;

public class PointsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text pointsText;
    [SerializeField] private Player player;
    private void Start()
    {
        SetPointsValue();
    }

    private void SetPointsValue()
    {
        pointsText.SetText($"Points: {player.Points}");
    }
    private void OnEnable()
    {
        player.OnPointsChanged += SetPointsValue;
    }

    private void OnDisable()
    {
        player.OnPointsChanged -= SetPointsValue;
    }
}
