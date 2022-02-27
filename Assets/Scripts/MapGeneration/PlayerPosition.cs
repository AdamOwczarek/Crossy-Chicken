using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Position", menuName = "Player/Position")]
public class PlayerPosition : ScriptableObject
{
    public int segmentId;
    public int field;
    public int score=0;

    public UnityAction OnPositionChanged;
    public UnityAction<int, int> OnPositionChangedData;

    public void UpdatePlayerPosition(int segmentId, int field)
    {
        this.segmentId = segmentId;
        this.field = field;

        SendUpdate();
    }

    private void SendUpdate()
    {
        OnPositionChanged?.Invoke();
        OnPositionChangedData?.Invoke(segmentId, field);
    }

    public void ReturnDefault()
    {
        segmentId = 0;
        field = 4;
    
    }

    private void OnValidate()
    {
        SendUpdate();
    }
}
