using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")||other.gameObject.CompareTag("Player1"))
        {
            
            other.transform.parent.gameObject.GetComponent<Movement>().FinishLineCollision();
        }
    }
}
