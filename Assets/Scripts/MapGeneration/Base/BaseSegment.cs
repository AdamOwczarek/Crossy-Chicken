using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BaseSegment : MonoBehaviour
{
   public bool test;
 [SerializeField] protected List<BaseField> fieldList;

[SerializeField] private int id;
public int Id => id;
public virtual void SetID(int id)
{
    this.id=id;
}


    void Start()
{
    if (test)
    {
        InitializeSegment();
    }
}
void Update()
{
if (test)
    {
        UpdateSegment();
    }
}

public virtual void InitializeSegment()
{
    
}
public virtual void UpdateSegment()
{

}
public virtual void DeinitalizeSegment()
{

}
public virtual bool CheckIfAvailable(int index)
{
 return false;
}
public bool CheckFieldEnterable(int index, out Vector3 position)
    {
        bool canEnter = fieldList[index].canEnter;
        position = canEnter ? fieldList[index].transform.position : Vector3.zero;
        return canEnter;
    }


}