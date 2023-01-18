using TMPro;
using UnityEngine;

public class PointsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text pointsText;
    [SerializeField] private Player player;
    private void Start()
    {
        pointsText.SetText($"Points: {player.Points}");
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
