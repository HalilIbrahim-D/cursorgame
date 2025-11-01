using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [Header("Game Settings")]
    public float scoreIncreaseInterval = 1f;
    public int pointsPerSecond = 10;
    
    [Header("Level Settings")]
    public int scorePerLevel = 100;
    public float speedIncreasePerLevel = 0.5f;
    public int maxArrowsPerSpawn = 3;
    
    [Header("UI References")]
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public Text scoreText;
    public Text levelText;
    public Text finalScoreText;
    public Button restartButton;
    public Button startButton;
    
    private int score = 0;
    private int currentLevel = 1;
    private float currentArrowSpeed = 5f;
    private int arrowsPerSpawn = 1;
    private bool isGameActive = false;
    private float scoreTimer = 0f;
    
    private ArrowSpawner arrowSpawner;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    
    void Start()
    {
        arrowSpawner = FindObjectOfType<ArrowSpawner>();
        
        // UI başlangıç durumu
        if (startPanel != null) startPanel.SetActive(true);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        
        // Button event'leri
        if (startButton != null)
            startButton.onClick.AddListener(StartGame);
        
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);
        
        UpdateUI();
    }
    
    void Update()
    {
        if (isGameActive)
        {
            // Skor artışı
            scoreTimer += Time.deltaTime;
            if (scoreTimer >= scoreIncreaseInterval)
            {
                AddScore(pointsPerSecond);
                scoreTimer = 0f;
            }
            
            // Level kontrolü
            CheckLevelUp();
        }
    }
    
    public void StartGame()
    {
        isGameActive = true;
        score = 0;
        currentLevel = 1;
        currentArrowSpeed = 5f;
        arrowsPerSpawn = 1;
        
        if (startPanel != null) startPanel.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        
        UpdateUI();
        UpdateArrowSpeed();
    }
    
    public void GameOver()
    {
        isGameActive = false;
        
        if (arrowSpawner != null)
            arrowSpawner.StopSpawning();
        
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        if (finalScoreText != null)
            finalScoreText.text = "Final Score: " + score;
    }
    
    public void RestartGame()
    {
        // Sahne yeniden yükle
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }
    
    void CheckLevelUp()
    {
        int newLevel = (score / scorePerLevel) + 1;
        
        if (newLevel > currentLevel)
        {
            currentLevel = newLevel;
            currentArrowSpeed += speedIncreasePerLevel;
            arrowsPerSpawn = Mathf.Min(maxArrowsPerSpawn, 1 + (currentLevel / 3));
            
            UpdateArrowSpeed();
            UpdateUI();
        }
    }
    
    void UpdateArrowSpeed()
    {
        // Tüm oklara yeni hızı uygula
        Arrow[] arrows = FindObjectsOfType<Arrow>();
        foreach (Arrow arrow in arrows)
        {
            arrow.speed = currentArrowSpeed;
        }
    }
    
    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
        
        if (levelText != null)
            levelText.text = "Level: " + currentLevel;
    }
    
    // Public getter'lar
    public bool IsGameActive() => isGameActive;
    public int GetCurrentLevel() => currentLevel;
    public float GetCurrentArrowSpeed() => currentArrowSpeed;
    public int GetArrowsPerSpawn() => arrowsPerSpawn;
    public int GetScore() => score;
}
