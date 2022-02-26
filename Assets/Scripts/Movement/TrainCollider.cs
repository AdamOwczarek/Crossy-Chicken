using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCollider : MonoBehaviour
{
    [SerializeField] Collider trainCollider;
   void OnTriggerEnter(Collider collision)
    {
        {
            if(collision.gameObject.tag == "Respawn")
            {
                trainCollider.gameObject.transform.localPosition = new Vector3(0,0,20);
            }
            else if(collision.gameObject.tag == "RespawnRev")
            {
                trainCollider.gameObject.transform.localPosition = new Vector3(0,0,-20);
            }
        }
        
    }
}
