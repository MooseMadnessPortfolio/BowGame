using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DamageOnCollScript : MonoBehaviour
{
    public int damageAmount;
    public LayerMask damageLayers;
    public bool destroyOnColl;
    public DestroyAction destroyAction;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (damageLayers == (damageLayers | (1 << coll.gameObject.layer)))
        {
            HealthScript health = coll.GetComponent<HealthScript>();
            if (health != null)
                health.TakeDamage(damageAmount);

            if (destroyOnColl)
            {
                if(destroyAction != null)
                {
                    destroyAction.StartDestroy();
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}