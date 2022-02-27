using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{   
    [SerializeField] private Transform jumpBody;
    [SerializeField] private AnimationCurve jumpCurve;
    [SerializeField] private float jumpHeight;    
        

    [Header("Jump by distance")]
    [SerializeField] private float maxJumpDistance;
    [SerializeField] private Vector3 targetPosition;
    

    private float startTime;
    private bool duringJumpByTime;

    private void Update()
    {
       
       JumpByDistance();
       
    }

    public void JumpToTarget(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    private void JumpByDistance()
    {
        float distance = Vector3.Distance(transform.position, targetPosition);
        float lerpedValue = Mathf.InverseLerp(maxJumpDistance, 0, distance);
        jumpBody.transform.localPosition = Vector3.Lerp(Vector3.zero, Vector3.up * jumpHeight, jumpCurve.Evaluate(lerpedValue));
    }
   

 

   


}
