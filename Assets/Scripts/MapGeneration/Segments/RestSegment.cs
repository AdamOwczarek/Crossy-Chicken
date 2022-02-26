using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RestSegment : BaseSegment
{   
    [SerializeField] private List<GameObject> blockObjectsList;
   [SerializeField][Range(0,100)] private int freespace;
    public override void InitializeSegment()
    {

        foreach(var field in fieldList)
        {
            int randomNumber = Random.Range(0,101);
            if(randomNumber>freespace)
            {
                field.SetcanEnter(false);
                GameObject newBlock = Instantiate(blockObjectsList[Random.Range(0,blockObjectsList.Count)]);
                newBlock.transform.position=field.transform.position;
                newBlock.transform.SetParent(field.transform);
            }
        }




    }
    public override void UpdateSegment()
    {

    }
    public override void DeinitalizeSegment()
    {
       
    }
    public override void SetID(int id)
    {
        base.SetID(id);
    }
}
