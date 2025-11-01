using UnityEngine;
using System.Collections;

public class ArrowSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject arrowPrefab;
    public float spawnInterval = 2f;
    public float minSpawnInterval = 0.5f;
    
    [Header("Spawn Position")]
    public float spawnX = 10f; // Ekranın sağı
    public float spawnYMin = -4f;
    public float spawnYMax = 4f;
    
    private Camera mainCamera;
    private float currentSpawnInterval;
    private bool isSpawning = false;
    
    void Start()
    {
        mainCamera = Camera.main;
        currentSpawnInterval = spawnInterval;
    }
    
    void Update()
    {
        if (!isSpawning && GameManager.Instance != null && GameManager.Instance.IsGameActive())
        {
            StartCoroutine(SpawnArrows());
        }
    }
    
    IEnumerator SpawnArrows()
    {
        isSpawning = true;
        
        while (GameManager.Instance != null && GameManager.Instance.IsGameActive())
        {
            SpawnArrow();
            
            // Level'a göre spawn interval güncelle
            UpdateSpawnInterval();
            
            yield return new WaitForSeconds(currentSpawnInterval);
        }
        
        isSpawning = false;
    }
    
    void SpawnArrow()
    {
        if (arrowPrefab == null || mainCamera == null) return;
        
        // Ekranın sağında rastgele Y pozisyonu
        float spawnY = Random.Range(spawnYMin, spawnYMax);
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);
        
        // Level'a göre kaç ok spawn edilecek
        int arrowCount = GameManager.Instance != null ? GameManager.Instance.GetArrowsPerSpawn() : 1;
        
        for (int i = 0; i < arrowCount; i++)
        {
            // Birden fazla ok için küçük offset ekle
            Vector3 offset = new Vector3(0, Random.Range(-0.5f, 0.5f), 0);
            Instantiate(arrowPrefab, spawnPosition + offset, Quaternion.identity);
        }
    }
    
    void UpdateSpawnInterval()
    {
        if (GameManager.Instance != null)
        {
            int currentLevel = GameManager.Instance.GetCurrentLevel();
            // Level arttıkça spawn interval azalır (daha hızlı spawn)
            currentSpawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - (currentLevel * 0.1f));
        }
    }
    
    public void StopSpawning()
    {
        isSpawning = false;
        StopAllCoroutines();
    }
}
