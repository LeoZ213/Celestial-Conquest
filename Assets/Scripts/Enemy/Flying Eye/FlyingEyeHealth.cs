using UnityEngine;

public class FlyingEyeHealth : MonoBehaviour, IDamageable
{
    private Animator animator;
    private float currentHealth;
    private float maxHealth = 100;
    private HealthBar healthBar;


    private float healthBarVanishTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<HealthBar>();

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Damage(WeaponTypes.WeaponType weaponType)
    {

        //Damages the enemy
        currentHealth -= 10;

        //Updates the health bar
        healthBar.UpdateHealthBar(maxHealth, currentHealth, healthBarVanishTime);

        if (currentHealth <= 0)
        {
            animator.Play("FlyingEyeDeath");
        }
    }
    private void OnDeathAnimationFinished()
    {
        Destroy(gameObject);
    }
}
