using UnityEngine;
using UnityEngine.EventSystems;

public class HoverInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    public void OnPointerEnter(PointerEventData p_info)
    {
        SoundManager.Instance.PlayOnce(AudioClipName.HOVER_MENU);
        Debug.Log("patata in");
    }

    public void OnPointerExit(PointerEventData p_info)
    {
        Debug.Log("patata out");
    }

    public void OnSelect(BaseEventData p_info)
    {
        Debug.Log("bravas in");
        SoundManager.Instance.PlayOnce(AudioClipName.HOVER_MENU);
    }

    public void OnDeselect(BaseEventData p_info)
    {
        Debug.Log("bravas out");
    }
}

