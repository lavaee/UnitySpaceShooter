using UnityEngine;
using UnityEngine.UI;
using MilkShake;

public class EnemyHealth: MonoBehaviour, IDamagable
{
    [SerializeField]
    private ShakePreset shakePreset;
    GameManager gameManager;
    public Canvas canvas;
    public Slider HealthSlider;
    public ShipStats Stats;
    public GameObject DestructionFX;

    [HideInInspector] public int maxHealth = 100;
    [HideInInspector] public int currentHealth;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        canvas.worldCamera = Camera.main;
        maxHealth = Stats.MaxHealth + (int)(0.1f * Stats.MaxHealth);

        HealthSlider.value = HealthSlider.maxValue = currentHealth = maxHealth;
    }

    public void TakeDamage(int _damageAmount)
    {
        HealthSlider.value = currentHealth -= _damageAmount;
        if (currentHealth <= 0)
        {
            gameManager.UpdateScore(Stats.Score);
            Die();
        }
    }

    void Die()
    {
        Shaker.ShakeAllSeparate(shakePreset);
        Instantiate(DestructionFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        gameManager.UpdateNumberOfShips();
    }
}
