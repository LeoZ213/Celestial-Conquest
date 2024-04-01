using UnityEngine;
using UnityEngine.AI;

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

    public void Damage(GunTypes.GunType gunType)
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

    public void Damage(SwordTypes.SwordType swordType)
    {
        //Implement sword attack
    }
    private void OnDeathAnimationFinished()
    {
        Destroy(gameObject);
    }
}
