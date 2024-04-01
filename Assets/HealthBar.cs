using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float timeToDrain = 0.25f;
    private Image healthImage;
    private float target;

    public Coroutine vanishHealthBarCoroutine;
    private Coroutine drainHealthBarCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        healthImage = GetComponent<Image>();
        
        //Sets the alpha to 0 and enables the image
        healthImage.CrossFadeAlpha(0, 0f, false);
        healthImage.enabled = true;
    }
    public void UpdateHealthBar(float maxHealth, float currentHealth, float timeToVanish)
    {
        target = currentHealth / maxHealth;

        //Sets the alpha to the max instantly
        healthImage.CrossFadeAlpha(1, 0f, false);

        drainHealthBarCoroutine = StartCoroutine(DrainHealthBar());
        vanishHealthBarCoroutine = StartCoroutine(VanishHealthBar(timeToVanish));
    }

    private IEnumerator DrainHealthBar()
    {
        float fillAmount = healthImage.fillAmount;

        //Fills the amount in respect to the time elapsed
        float elapsedTime = 0f;
        while (elapsedTime < timeToDrain)
        {
            elapsedTime += Time.deltaTime;

            healthImage.fillAmount = Mathf.Lerp(fillAmount, target, elapsedTime / timeToDrain);
            yield return null;
        }
    }
    private IEnumerator VanishHealthBar(float timeToVanish)
    {
        //Waits for the draining to finish
        yield return new WaitForSeconds(timeToDrain);

        //Starts the healthbar vanishing
        if (healthImage.color.a == 1 && timeToVanish > 0)
        {
            healthImage.CrossFadeAlpha(0, timeToVanish, false);
        }
    }
}
