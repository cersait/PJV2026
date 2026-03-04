using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDropItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 startPos;
    private Item currentItem; // The specific data for the item in this slot

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        startPos = rectTransform.anchoredPosition;
    }

    public void SetItem(Item newItem)
    {
        this.currentItem = newItem; 
    }

    public void ResetToHome() => rectTransform.anchoredPosition = startPos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / GetComponentInParent<Canvas>().scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        GameObject hitObject = eventData.pointerCurrentRaycast.gameObject;

        if (hitObject != null)
        {
            ItemSocket socket = hitObject.GetComponent<ItemSocket>();
            if (socket != null && currentItem != null)
            {
                // Try to activate the socket with this item's data
                if (socket.ActivateCog(currentItem))
                {
                    // If successful, the UI Refresh will handle hiding the slot
                    return;
                }
                if (socket.ActivateConvert(currentItem))
                {
                    return;
                }
                if (socket.ActivateKey(currentItem))
                {
                    return;
                }
            }
        }
        ResetToHome();
    }
}
