using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 startPos;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        startPos = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false; // Tillåter oss att "se" världen bakom ikonen
        canvasGroup.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Följ muspekaren
        rectTransform.anchoredPosition += eventData.delta / GetComponentInParent<Canvas>().scaleFactor;
    }

    //här under vi kan lägga grejer i andra
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        GameObject hitObject = eventData.pointerCurrentRaycast.gameObject;

        if (hitObject != null && hitObject.CompareTag("Maskin"))
        {
            // Vi sparar svaret från maskinen i en variabel (success)
            ItemSocket socket = hitObject.GetComponent<ItemSocket>();
            bool success = socket.Activate(this.gameObject);

            // Om maskinen sa nej (redan använd), skicka tillbaka ikonen
            if (success == false)
            {
                rectTransform.anchoredPosition = startPos;
            }

            if (success == true)
            {
                socket.Activate(this.gameObject);
                rectTransform.anchoredPosition = startPos;
            }
        }
        else
        {
            // Om vi släppte utanför en maskin, åk tillbaka
            rectTransform.anchoredPosition = startPos;
        }
    }

}
