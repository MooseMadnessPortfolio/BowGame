using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HealthDrawScript : MonoBehaviour
{
    private SpriteRenderer sRender;

    private void Awake()
    {
        sRender = GetComponent<SpriteRenderer>();
    }

    public void ChangeHealthState(float newPercent)
    {
        Color newColor = sRender.color;
        newColor.b = newPercent;
        newColor.g = newPercent;
        sRender.color = newColor;
    }
}