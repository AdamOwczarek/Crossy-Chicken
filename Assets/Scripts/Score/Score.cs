using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myText;
    [SerializeField] private PlayerPosition positionData;


    void Update()
    {
     if(positionData.score<positionData.segmentId)
     {
        positionData.score=positionData.segmentId; 
     }
     myText.text= $"Current Highscore: {positionData.score}";
    }
   
}
