using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class NavigationSounds : MonoBehaviour, IDeselectHandler, ISubmitHandler, IBeginDragHandler, IEndDragHandler, IMoveHandler
{
    // Start is called before the first frame update
    Selectable element;

    void Start()
    {
        element = GetComponent<Selectable>();
    }

    public void OnDeselect(BaseEventData e)
    {
        SoundSystem.soundSystem.Play("buttonSelect");
    }
    public void OnSubmit(BaseEventData e)
    {
        SoundSystem.soundSystem.Play("swordDraw");
    }
    public void OnSubmit()
    {
        SoundSystem.soundSystem.Play("swordDraw");
    }
    public void OnMove(AxisEventData e)
    {
        SoundSystem.soundSystem.Play("buttonSelect");
    }
    public void OnBeginDrag(PointerEventData e)
    {
        SoundSystem.soundSystem.Play("buttonSelect");
    }
    public void OnEndDrag(PointerEventData e)
    {
        SoundSystem.soundSystem.Play("buttonSelect");
    }
}
