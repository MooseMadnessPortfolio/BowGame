using UnityEngine;
using UnityEngine.Events;

public class ExplosionObjectScript : ArrowTargetScript
{
    public GameObject explosionEffectPrefab;
    public float radius;
    public int damageAmount;
    public LayerMask damageableObjects;
    public UnityEvent onExplosion;

    protected override void InteractWithArrow(ArrowScript arrow)
    {
        Boom();
        base.InteractWithArrow(arrow);
    }

    public void Boom()
    {
        Collider2D[] enemiesColliders = Physics2D.OverlapCircleAll(transform.position, radius, damageableObjects);
        foreach(Collider2D enemyCollider in enemiesColliders)
        {
            HealthScript enemyHealth = enemyCollider.GetComponent<HealthScript>();
            enemyHealth.TakeDamage(damageAmount);
        }
        Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        onExplosion.Invoke();
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}