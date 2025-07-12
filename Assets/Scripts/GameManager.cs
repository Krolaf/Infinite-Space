using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Références")]
    [SerializeField] private GameObject playerShip;
    [SerializeField] private GameObject baseStation;
    [SerializeField] private Camera mainCamera;
    
    [Header("Paramètres du jeu")]
    [SerializeField] private bool gamePaused = false;
    [SerializeField] private float gameTime = 0f;
    
    private static GameManager instance;
    
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    instance = go.AddComponent<GameManager>();
                }
            }
            return instance;
        } 
    }
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        InitializeGame();
    }
    
    private void Update()
    {
        if (!gamePaused)
        {
            gameTime += Time.deltaTime;
        }
        
        // Pause avec la touche Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    
    private void InitializeGame()
    {
        Debug.Log("Initialisation du jeu d'exploration spatiale...");
        
        // Trouver les objets si pas assignés
        if (playerShip == null)
            playerShip = GameObject.Find("PlayerShip");
            
        if (baseStation == null)
            baseStation = GameObject.Find("BaseStation");
            
        if (mainCamera == null)
            mainCamera = Camera.main;
        
        // Vérifier que tout est en place
        if (playerShip == null)
            Debug.LogError("PlayerShip non trouvé !");
        else
            Debug.Log("Vaisseau joueur trouvé et configuré");
            
        if (baseStation == null)
            Debug.LogError("BaseStation non trouvée !");
        else
            Debug.Log("Base station trouvée et configurée");
            
        if (mainCamera == null)
            Debug.LogError("Caméra principale non trouvée !");
        else
            Debug.Log("Caméra principale configurée");
    }
    
    public void TogglePause()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused ? 0f : 1f;
        Debug.Log($"Jeu {(gamePaused ? "mis en pause" : "repris")}");
    }
    
    public void RestartGame()
    {
        gameTime = 0f;
        gamePaused = false;
        Time.timeScale = 1f;
        
        // Remettre le vaisseau à sa position initiale
        if (playerShip != null)
        {
            playerShip.transform.position = new Vector3(0, 2, 0);
            playerShip.transform.rotation = Quaternion.identity;
            
            Rigidbody2D rb = playerShip.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }
        }
        
        Debug.Log("Jeu redémarré");
    }
    
    public float GetGameTime()
    {
        return gameTime;
    }
    
    public bool IsGamePaused()
    {
        return gamePaused;
    }
    
    public GameObject GetPlayerShip()
    {
        return playerShip;
    }
    
    public GameObject GetBaseStation()
    {
        return baseStation;
    }
} 