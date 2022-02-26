using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour

   
{
    [SerializeField] private Transform target;
    [SerializeField] private float movementSpeed;
    [SerializeField] Vector3 positionDiff;

    private void Start()
    {
        transform.position = target.transform.position + positionDiff;
        transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + positionDiff, Time.deltaTime * movementSpeed);        
    }
}

