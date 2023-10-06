using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    GameManager gameManager;
    [SerializeField] Gradient healthColor;
    [SerializeField] Image healthBar;
    public AudioSource music, heartbeat, fx;
    public CanvasGroup canvasGroup;
    public Canvas canvas;
    public Slider HealthSlider;
    public ShipStats Stats;
    public GameObject DestructionFX;
    public int HealthRegenerationTime, HealthRegenerationMultiplier;
    public bool HealthRegeneration;

    private float regenerateHealth;
    private int maxHealth = 100;
    [HideInInspector] public float currentHealth;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        canvas.worldCamera = Camera.main;
        HealthSlider.maxValue = currentHealth = maxHealth = Stats.MaxHealth;
    }

    public void TakeDamage(int _damageAmount)
    {
        regenerateHealth = 0;
        HealthSlider.value = currentHealth -= _damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Update()
    {
        if (HealthRegeneration)
        {
            regenerateHealth += Time.deltaTime;
            if (regenerateHealth >= HealthRegenerationTime)
            {
                if (currentHealth < maxHealth)
                {
                    UpdateMaxHealth(Time.deltaTime * HealthRegenerationMultiplier);
                }
            }
        }

        healthBar.color = healthColor.Evaluate(currentHealth / maxHealth);
        music.volume = (currentHealth / maxHealth ) * 0.6f;
        heartbeat.volume = canvasGroup.alpha = 1 - currentHealth / maxHealth;
        fx.volume = heartbeat.volume / 2;
    }

    void Die()
    {
        fx.volume = heartbeat.volume = 1;
        music.Pause();
        gameManager.ShowDeathScreen();
        Instantiate(DestructionFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            IDamagable health = collision.gameObject.GetComponent<IDamagable>();
            collision.gameObject.GetComponent<IDamagable>().TakeDamage(collision.gameObject.GetComponent<EnemyHealth>().maxHealth);
            Die();
        }
    }

    public void UpdateMaxHealth(float _value)
    {
        HealthSlider.maxValue = maxHealth = Stats.MaxHealth += (int)_value;

        if (currentHealth + _value >= maxHealth)
        {
            _value = maxHealth - currentHealth;
        }
        HealthSlider.value = currentHealth += _value;
    }
}
