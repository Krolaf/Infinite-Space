using UnityEngine;

public class Resource : MonoBehaviour
{
    public enum ResourceType { Deuterium, Minerai }
    public ResourceType type = ResourceType.Deuterium;

    public int minAmount = 5;
    public int maxAmount = 15;
    [HideInInspector] public int amount;

    public float miningTime = 2f; // temps de collecte (minerai = 2s, deuterium = 0.5s)
    public string displayName = "";

    void Start()
    {
        amount = Random.Range(minAmount, maxAmount + 1);
        if (string.IsNullOrEmpty(displayName))
            displayName = gameObject.name;
        // Si c'est du Deuterium, temps de collecte plus court
        if (type == ResourceType.Deuterium)
            miningTime = 0.5f;
    }

    public void Collect(PlayerInventory inventory)
    {
        inventory.AddResource(type, amount);
        Destroy(gameObject);
    }
} 