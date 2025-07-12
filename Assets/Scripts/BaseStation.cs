using UnityEngine;

public class BaseStation : MonoBehaviour
{
    [Header("Base Station")]
    [SerializeField] private string stationName = "Base Alpha";

    private void Start()
    {
        Debug.Log($"Base station '{stationName}' initialisée à la position {transform.position}");
    }
}
