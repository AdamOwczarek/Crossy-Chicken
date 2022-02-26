using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseField : MonoBehaviour
{
    [SerializeField] private int index;
    [SerializeField] public bool canEnter;

    public void SetcanEnter(bool value)
    {
     canEnter = value;
    }
    public bool GetcanEnter()
    {
        return canEnter;
    }

}
