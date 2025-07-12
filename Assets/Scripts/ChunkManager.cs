using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [Header("Paramètres des chunks")]
    public GameObject chunkPrefab;
    public int chunkSize = 20;
    public int activeRadius = 1; // 1 = 3x3, 2 = 5x5, etc.
    public int noSpawnRadiusChunks = 1; // Rayon de sécurité autour de la base (en chunks)
    public Transform player;

    // Définition des zones (exemple)
    [Header("Définition des zones (distance en chunks)")]
    public int[] zoneLimits = new int[] { 1, 3, 6 }; // 0=zone base, 1=zone1, 2=zone2, etc.

    private Dictionary<Vector2Int, GameObject> activeChunks = new Dictionary<Vector2Int, GameObject>();
    private Vector2Int lastPlayerChunk;

    void Start()
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null) player = playerObj.transform;
        }
        UpdateChunks(force: true);
    }

    void Update()
    {
        UpdateChunks();
    }

    void UpdateChunks(bool force = false)
    {
        if (player == null) return;
        Vector2 playerPos = player.position;
        Vector2Int playerChunk = new Vector2Int(
            Mathf.FloorToInt(playerPos.x / chunkSize),
            Mathf.FloorToInt(playerPos.y / chunkSize)
        );
        if (!force && playerChunk == lastPlayerChunk) return;
        lastPlayerChunk = playerChunk;

        HashSet<Vector2Int> neededChunks = new HashSet<Vector2Int>();
        for (int dx = -activeRadius; dx <= activeRadius; dx++)
        {
            for (int dy = -activeRadius; dy <= activeRadius; dy++)
            {
                Vector2Int chunkCoord = new Vector2Int(playerChunk.x + dx, playerChunk.y + dy);
                neededChunks.Add(chunkCoord);
                if (!activeChunks.ContainsKey(chunkCoord))
                {
                    Vector3 chunkWorldPos = new Vector3(
                        chunkCoord.x * chunkSize + chunkSize / 2f,
                        chunkCoord.y * chunkSize + chunkSize / 2f,
                        0
                    );
                    GameObject chunk = Instantiate(chunkPrefab, chunkWorldPos, Quaternion.identity, transform);
                    chunk.name = $"Chunk_{chunkCoord.x}_{chunkCoord.y}";

                    // Calcul de la distance à la base (0,0) en chunks
                    int dist = Mathf.RoundToInt(chunkCoord.magnitude);
                    int zone = GetZoneFromDistance(dist);

                    // Transmettre la zone et le rayon de sécurité au spawner
                    var spawner = chunk.GetComponent<SpaceObjectSpawner>();
                    if (spawner != null)
                    {
                        spawner.zone = zone;
                        spawner.noSpawnRadiusChunks = noSpawnRadiusChunks;
                        spawner.chunkCoord = chunkCoord;
                    }

                    activeChunks.Add(chunkCoord, chunk);
                }
            }
        }

        // Détruire les chunks trop éloignés
        List<Vector2Int> toRemove = new List<Vector2Int>();
        foreach (var kvp in activeChunks)
        {
            if (!neededChunks.Contains(kvp.Key))
            {
                Destroy(kvp.Value);
                toRemove.Add(kvp.Key);
            }
        }
        foreach (var coord in toRemove)
        {
            activeChunks.Remove(coord);
        }
    }

    int GetZoneFromDistance(int dist)
    {
        for (int i = 0; i < zoneLimits.Length; i++)
        {
            if (dist <= zoneLimits[i])
                return i;
        }
        return zoneLimits.Length; // Zone la plus éloignée
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        foreach (var kvp in activeChunks)
        {
            Vector3 center = kvp.Value.transform.position;
            Gizmos.DrawWireCube(center, new Vector3(chunkSize, chunkSize, 0));
        }
    }
} 