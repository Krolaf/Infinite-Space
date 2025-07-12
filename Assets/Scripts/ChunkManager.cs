using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public GameObject chunkPrefab;
    Dictionary<Vector2Int, GameObject> activeChunks = new();

    void Update()
    {
        if (GameManager.Instance == null || GameManager.Instance.player == null)
        {
            Debug.LogWarning("[ChunkManager] GameManager ou player non assigné !");
            return;
        }
        Vector2Int playerChunk = GetChunkCoord(GameManager.Instance.player.position);
        for (int x = -GameManager.Instance.activeRadius; x <= GameManager.Instance.activeRadius; x++)
        for (int y = -GameManager.Instance.activeRadius; y <= GameManager.Instance.activeRadius; y++)
        {
            Vector2Int coord = playerChunk + new Vector2Int(x, y);
            if (!activeChunks.ContainsKey(coord))
            {
                Vector3 pos = new(coord.x * GameManager.Instance.chunkSize, coord.y * GameManager.Instance.chunkSize, 0);
                var chunk = Instantiate(chunkPrefab, pos, Quaternion.identity, transform);
                chunk.GetComponent<Chunk>().Init(coord);
                activeChunks.Add(coord, chunk);
                Debug.Log($"[ChunkManager] Génère chunk {coord} à la position {pos}, zone {Chunk.GetZone(coord)}");
            }
        }
        // Détruire les chunks trop éloignés (à implémenter)
    }

    Vector2Int GetChunkCoord(Vector3 pos)
    {
        int size = GameManager.Instance.chunkSize;
        return new Vector2Int(Mathf.FloorToInt(pos.x / size), Mathf.FloorToInt(pos.y / size));
    }
}