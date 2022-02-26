using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollider : MonoBehaviour
{
    [SerializeField] Collider carCollider;
   void OnTriggerEnter(Collider collision)
    {
        {
            if(collision.gameObject.tag == "Respawn")
            {
                carCollider.gameObject.transform.localPosition = new Vector3(0,0,-20);
            }
        }
        
    }
}
