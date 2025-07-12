using UnityEngine;

public class SpaceObjectSpawner : MonoBehaviour
{
    public GameObject[] resourcePrefabs, enemyPrefabs, anomalyPrefabs, merchantPrefabs;
    public void SpawnObjects(Vector2Int chunkCoord)
    {
        int zone = Chunk.GetZone(chunkCoord);
        if (zone == 0) return; // Zone de sécurité

        // Exemple : plus on s'éloigne, plus il y a d'ennemis
        int nbRessources = Mathf.Max(1, 5 - zone);
        int nbEnnemis = Mathf.Max(0, zone - 1);

        for (int i = 0; i < nbRessources; i++)
            Spawn(resourcePrefabs, chunkCoord, "Ressource");
        for (int i = 0; i < nbEnnemis; i++)
            Spawn(enemyPrefabs, chunkCoord, "Ennemi");
        // Idem pour anomalies, marchands...

        Debug.Log($"[Spawner] Généré {nbRessources} ressources, {nbEnnemis} ennemis dans chunk {chunkCoord}, zone {zone}");
    }

    void Spawn(GameObject[] prefabs, Vector2Int chunkCoord, string type)
    {
        if (prefabs.Length == 0) { Debug.LogError($"Aucun prefab pour {type}"); return; }
        var prefab = prefabs[Random.Range(0, prefabs.Length)];
        Vector3 pos = transform.position + (Vector3)(Random.insideUnitCircle * GameManager.Instance.chunkSize / 2f);
        var obj = Instantiate(prefab, pos, Quaternion.identity, transform);
        Debug.Log($"[Spawner] Génère {type} {prefab.name} à {pos} dans chunk {chunkCoord}");
    }
}  