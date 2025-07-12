using UnityEngine;

public class Chunk : MonoBehaviour
{
    public Vector2Int coord;
    // Largeur d'une zone en chunks (modifiable dans l'Inspector)
    public static int zoneWidth = 2; // largeur des zones hors base
    public void Init(Vector2Int c)
    {
        coord = c;
        GetComponent<SpaceObjectSpawner>().SpawnObjects(coord);
    }
    public static int GetZone(Vector2Int coord)
    {
        float dist = coord.magnitude;
        if (dist < 1f)
            return 0; // zone de la base
        return 1 + Mathf.FloorToInt((dist - 1f) / zoneWidth);
    }
}
