using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;
    
    private Transform target; // Top hedefi
    private Vector2 direction;
    private bool hasTarget = false;
    
    void Start()
    {
        // Topu hedef olarak al
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        if (ball != null)
        {
            target = ball.transform;
            CalculateDirection();
            hasTarget = true;
        }
        
        // Sprite'ı topa doğru döndür
        RotateTowardsTarget();
    }
    
    void Update()
    {
        if (hasTarget && target != null)
        {
            // Hedefi güncelle (dinamik takip için)
            CalculateDirection();
            RotateTowardsTarget();
            
            // Hareket et
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else
        {
            // Hedef yoksa düz ilerle
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        
        // Ekran dışına çıktıysa yok et
        Camera mainCam = Camera.main;
        if (mainCam != null)
        {
            Vector3 screenPoint = mainCam.WorldToViewportPoint(transform.position);
            if (screenPoint.x < -0.1f || screenPoint.y < -0.1f || screenPoint.y > 1.1f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            // Camera yoksa basit kontrol
            if (transform.position.x < -15f || transform.position.y < -10f || transform.position.y > 10f)
            {
                Destroy(gameObject);
            }
        }
    }
    
    void CalculateDirection()
    {
        if (target != null)
        {
            Vector2 targetPos = target.position;
            Vector2 currentPos = transform.position;
            
            direction = (targetPos - currentPos).normalized;
        }
    }
    
    void RotateTowardsTarget()
    {
        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            // Topa çarptı - oyun bitişi
            GameManager.Instance?.GameOver();
            Destroy(gameObject);
        }
    }
}
