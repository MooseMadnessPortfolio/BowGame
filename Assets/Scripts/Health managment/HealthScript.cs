using UnityEngine;
using UnityEngine.Events;

public class HealthScript : MonoBehaviour
{
    public int maxHealth;
    public UnityEvent onDeath;
    public HealthDrawScript healthDraw;
    public DestroyAction destroyAction;
    
    private int currHealth;

    private void Start()
    {
        currHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (currHealth > 0)
        {
            currHealth -= amount;
            if (currHealth <= 0)
            {
                onDeath.Invoke();
                if (destroyAction != null)
                {
                    if (healthDraw != null)
                        healthDraw.ChangeHealthState(0);
                    destroyAction.StartDestroy();
                }
                else
                    Destroy(gameObject);
            }
            else if(healthDraw != null)
            {
                healthDraw.ChangeHealthState((float)currHealth / maxHealth);
            }
        }
    }
}
