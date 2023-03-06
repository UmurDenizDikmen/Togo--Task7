using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour,IDragHandler
{
    public Transform CurrentPosition;
    public Transform CurrentPosition2;
  
    private float MouseSense = 175f;


    public void OnDrag(PointerEventData eventData)
    {
        Vector3 CurrentVector = CurrentPosition.position;
        CurrentVector.x = Mathf.Clamp(CurrentVector.x+(eventData.delta.x / MouseSense), -3.5f, 0f);
        CurrentPosition.position = new Vector3(CurrentVector.x, CurrentPosition.position.y, CurrentPosition.position.z);

        Vector3 CurrentVector2 = CurrentPosition2.position;
        CurrentVector2.x = Mathf.Clamp(-CurrentVector2.x + (eventData.delta.x / MouseSense), -3.5f, 0f);
        CurrentPosition2.position = new Vector3(-CurrentVector2.x, CurrentPosition2.position.y, CurrentPosition2.position.z);

     


    }



}
