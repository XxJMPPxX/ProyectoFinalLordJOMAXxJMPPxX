using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class UIButtonEffects : MonoBehaviour
{
    private RectTransform rectTransform;
    private Button button;
    private EventTrigger eventTrigger;

    private Vector3 originalScale = new Vector3(2.36244798f, 2.36244798f, 2.36244798f);
    private Vector3 hoveredScale = new Vector3(2.36244798f * 1.2f, 2.36244798f * 1.2f, 2.36244798f * 1.2f);

    private void Awake()
    {
        eventTrigger = gameObject.AddComponent<EventTrigger>();
    }

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        button = GetComponent<Button>();

        // Asegurar que el botón tenga el tamaño original
        rectTransform.localScale = originalScale;

        button.onClick.AddListener(OnButtonClick);

        EventTrigger.Entry pointerEnter = new EventTrigger.Entry();
        pointerEnter.eventID = EventTriggerType.PointerEnter;
        pointerEnter.callback.AddListener((eventData) => { OnPointerEnter(); });
        eventTrigger.triggers.Add(pointerEnter);

        EventTrigger.Entry pointerExit = new EventTrigger.Entry();
        pointerExit.eventID = EventTriggerType.PointerExit;
        pointerExit.callback.AddListener((eventData) => { OnPointerExit(); });
        eventTrigger.triggers.Add(pointerExit);
    }

    public void OnPointerEnter()
    {
        rectTransform.DOScale(hoveredScale, 0.2f).SetEase(Ease.OutBack);
        // GameManager.Instance.TriggerButtonHover();
        // GetComponent<Image>().DOColor(Color.red, 0.2f);
    }

    public void OnPointerExit()
    {
        rectTransform.DOScale(originalScale, 0.2f).SetEase(Ease.OutBack);
        // GetComponent<Image>().DOColor(Color.white, 0.8f);
    }

    private void OnButtonClick()
    {
        rectTransform.DOPunchScale(Vector3.one * 0.1f, 0.3f, 10, 1);
    }
}
