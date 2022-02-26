using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private List<GameObject> carsList;
    [SerializeField] private float waitTime;
    [SerializeField] private Vector3 forceVector= new Vector3(4,0,0);
    
    void Start()
    {
        StartCoroutine(WaitToMove());
        

        
    }

   private IEnumerator WaitToMove()
    {
        
         ConstantForce carForceComponent;
         while(true)
         {

         
         foreach(var car in carsList)
        {
            yield return new WaitForSeconds(waitTime);
            int randomNumber = Random.Range(0,2);
            if(randomNumber==0)
            {
                carForceComponent=car.GetComponent<ConstantForce>();
               carForceComponent.relativeForce=forceVector;
            }
        }
        }
    }

     
    
    
}
