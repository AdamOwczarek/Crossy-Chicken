using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    
    [SerializeField] private PlayerPosition positionData;


    void Update()
    {
     if(positionData.score<positionData.segmentId)
     {
        positionData.score=positionData.segmentId;
     }
    }
   
}
