using UnityEngine;

public class SpaceObjectSpawner : MonoBehaviour
{
    [Header("Prefabs à générer")]
    public GameObject resourcePrefab;
    public GameObject enemyPrefab;
    public GameObject anomalyPrefab;

    [Header("Quantité aléatoire par chunk")]
    public Vector2Int resourceCount = new Vector2Int(2, 5);
    public Vector2Int enemyCount = new Vector2Int(0, 2);
    public Vector2Int anomalyCount = new Vector2Int(0, 1);

    [Header("Taille du chunk")] 
    public float chunkSize = 20f;

    void Start()
    {
        SpawnObjects(resourcePrefab, Random.Range(resourceCount.x, resourceCount.y + 1));
        SpawnObjects(enemyPrefab, Random.Range(enemyCount.x, enemyCount.y + 1));
        SpawnObjects(anomalyPrefab, Random.Range(anomalyCount.x, anomalyCount.y + 1));
    }

    void SpawnObjects(GameObject prefab, int count)
    {
        if (prefab == null || count <= 0) return;
        for (int i = 0; i < count; i++)
        {
            Vector2 localPos = new Vector2(
                Random.Range(-chunkSize / 2f, chunkSize / 2f),
                Random.Range(-chunkSize / 2f, chunkSize / 2f)
            );
            Vector3 worldPos = transform.position + new Vector3(localPos.x, localPos.y, 0);
            Instantiate(prefab, worldPos, Quaternion.identity, transform);
        }
    }
} 