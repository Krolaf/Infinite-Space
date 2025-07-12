using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int deuterium = 100;
    public int minerai = 0;

    public void AddResource(Resource.ResourceType type, int amount)
    {
        if (type == Resource.ResourceType.Deuterium) deuterium += amount;
        if (type == Resource.ResourceType.Minerai) minerai += amount;
        // Affichage ou feedback à ajouter ici
    }


} 