using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MapGenerator : MonoBehaviour
{
    [SerializeField] public List<BaseSegment> availableSegments;
        [SerializeField] private PlayerPosition positionData;

        [SerializeField] private List<BaseSegment> segmentsToGenerate;
        [SerializeField] private List<BaseSegment> segmentsGenerated;

        public void TryMove(int segmentDiff, int fieldDiff, UnityAction<Vector3> OnMovementPossible, UnityAction OnMovementFailed)
        {
            //add validation for segment exit

            var segmentToEnter = availableSegments.Find(c => c.Id == positionData.segmentId + segmentDiff);
            if(segmentToEnter != null)
            {
                if(segmentToEnter.CheckFieldEnterable(positionData.field + fieldDiff, out Vector3 position))
                {
                    OnMovementPossible?.Invoke(position);
                    positionData.field += fieldDiff;
                    positionData.segmentId += segmentDiff;
                }
                else
                {
                    OnMovementFailed?.Invoke();
                }
            }
        }

        private void OnApplicationQuit()
        {
            positionData.ReturnDefault();
        }
    
        public void GenerateSegment()
        {
           
             BaseSegment newsegment = Instantiate(segmentsToGenerate[Random.Range(0,segmentsToGenerate.Count)]);
             int newID= availableSegments[availableSegments.Count-1].Id+1;
            Vector3 newPosition = availableSegments[availableSegments.Count-1].transform.position+ Vector3.right;
             segmentsGenerated.Add(newsegment);
             newsegment.transform.position= newPosition;
            newsegment.SetID(newID);
            availableSegments.Add(newsegment);
             
                
           
        }
        
}
