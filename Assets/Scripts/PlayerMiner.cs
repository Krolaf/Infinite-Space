using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerMiner : MonoBehaviour
{
    public PlayerInventory inventory;
    public InputActionReference interactAction; // À assigner dans l’Inspector (Input System)
    public Image miningBar; // À assigner dans l’Inspector (UI)
    public TextMeshProUGUI miningPrompt; // Message à afficher

    private Resource currentMineral;
    private float miningProgress = 0f;
    private bool isMining = false;
    private bool interactKeyHeld = false;

    void OnEnable() {
        if (interactAction != null) {
            interactAction.action.performed += ctx => interactKeyHeld = true;
            interactAction.action.canceled += ctx => interactKeyHeld = false;
            interactAction.action.Enable();
        }
    }
    void OnDisable() {
        if (interactAction != null) interactAction.action.Disable();
    }

    void Update()
    {
        if (currentMineral != null)
        {
            string nom = string.IsNullOrEmpty(currentMineral.displayName) ? currentMineral.type.ToString() : currentMineral.displayName;
            miningPrompt.text = $"[E Maintenir] Miner {nom}";
            miningPrompt.enabled = true;

            if (interactKeyHeld)
            {
                isMining = true;
                miningProgress += Time.deltaTime;
                miningBar.fillAmount = miningProgress / currentMineral.miningTime;

                if (miningProgress >= currentMineral.miningTime)
                {
                    currentMineral.Collect(inventory);
                    ResetMining();
                }
            }
            else if (isMining)
            {
                ResetMining();
            }
        }
        else
        {
            miningPrompt.enabled = false;
            miningBar.fillAmount = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Resource res = other.GetComponent<Resource>();
        if (res != null)
        {
            currentMineral = res;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Resource res = other.GetComponent<Resource>();
        if (res != null && res == currentMineral)
        {
            ResetMining();
            currentMineral = null;
        }
    }

    void ResetMining()
    {
        miningProgress = 0f;
        miningBar.fillAmount = 0f;
        isMining = false;
    }
} 