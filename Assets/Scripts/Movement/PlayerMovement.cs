using System.Collections;
using System.Collections.Generic;
using UnityEngine;




    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Jumper jumperMechanic;
        [SerializeField] private MapGenerator mapGenerator;
        [SerializeField] private float speed;
        [SerializeField] PlayerPosition playerPosition;
        [SerializeField] private float nextStepwaitingTime;
        [SerializeField] bool canMoveAgain=true;
        private Vector3 targetPosition;
        [SerializeField] Transform playerTransform;
     

        private void Update()
        {
            HandleInput();
            HandleMovement(); 
        }

        public void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                playerTransform.rotation = Quaternion.LookRotation(Vector3.right);
                StartCoroutine(WaitBeforeNextStep());
                if(canMoveAgain==true)
                {
                mapGenerator.TryMove(1, 0, OnMovementSucess, OnMovementFailed);
                if(playerPosition.score-playerPosition.segmentId<6)
                {
                    mapGenerator.GenerateSegment();
                }
                }
                canMoveAgain=false;
                
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                playerTransform.rotation = Quaternion.LookRotation(Vector3.left);
                StartCoroutine(WaitBeforeNextStep());
                if(canMoveAgain==true)
                {
                mapGenerator.TryMove(-1, 0, OnMovementSucess, OnMovementFailed);
                }
                canMoveAgain=false;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                playerTransform.rotation = Quaternion.LookRotation(Vector3.forward);
                StartCoroutine(WaitBeforeNextStep());
                if(canMoveAgain==true)
                {
                mapGenerator.TryMove(0, 1, OnMovementSucess, OnMovementFailed);
                }
                canMoveAgain=false;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                playerTransform.rotation = Quaternion.LookRotation(Vector3.back);
                StartCoroutine(WaitBeforeNextStep());
                if(canMoveAgain==true)
                {
                mapGenerator.TryMove(0, -1, OnMovementSucess, OnMovementFailed);
                }
                canMoveAgain=false;
            }
        }

        public void HandleMovement()
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
            jumperMechanic.JumpToTarget(targetPosition);
            
        }

        public void OnMovementSucess(Vector3 newPosition)
        {
            targetPosition = newPosition;
        }

        public void OnMovementFailed()
        {
            Debug.Log("Player Movement :: Sorry dude, Cant enter field");
        }
        
        private void OnTriggerEnter(Collider other)
        {
            this.transform.position=new Vector3(0,0,0);
            playerPosition.ReturnDefault();
            targetPosition= new Vector3(0,0,0);

    
        }

        public IEnumerator WaitBeforeNextStep()
        {
            yield return new WaitForSeconds(nextStepwaitingTime);
            canMoveAgain=true;
            
        }
    }

