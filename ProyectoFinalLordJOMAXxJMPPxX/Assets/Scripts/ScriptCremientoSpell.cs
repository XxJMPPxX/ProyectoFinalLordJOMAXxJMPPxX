using UnityEngine;
using DG.Tweening;

public class ScriptCrecimientoSpell : MonoBehaviour
{
    [SerializeField] private float duration ;
    [SerializeField] public AnimationCurve animationCurve = AnimationCurve.Linear(0.12f, 0, 0.39f, 0);
    [SerializeField] private float rotationSpeed;

    private Vector3 originalScale;
    private Vector3 smallScale;

    void Start()
    {
        originalScale = transform.localScale;
        smallScale = originalScale * 0.1f;
        transform.localScale = smallScale;
        transform.DOScale(originalScale, duration).SetEase(animationCurve);
    }

    void Update()
    {
        
        float angle = Time.time * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
