using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform player;
    public Transform baseStation;
    public int chunkSize = 100;
    public int activeRadius = 3;

    void Awake() { Instance = this; }
} 