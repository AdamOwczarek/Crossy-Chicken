using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private MapGenerator mapGenerator;
        [SerializeField] private float speed;
        [SerializeField] PlayerPosition playerPosition;

        private Vector3 targetPosition;

        private void Update()
        {
            HandleInput();
            HandleMovement();
        }

        public void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                mapGenerator.TryMove(1, 0, OnMovementSucess, OnMovementFailed);
                if(playerPosition.score-playerPosition.segmentId<10)
                {
                    mapGenerator.GenerateSegment();
                }
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                mapGenerator.TryMove(-1, 0, OnMovementSucess, OnMovementFailed);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                mapGenerator.TryMove(0, 1, OnMovementSucess, OnMovementFailed);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                mapGenerator.TryMove(0, -1, OnMovementSucess, OnMovementFailed);
            }
        }

        public void HandleMovement()
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
        }

        public void OnMovementSucess(Vector3 newPosition)
        {
            targetPosition = newPosition;
        }

        public void OnMovementFailed()
        {
            Debug.Log("Player Movement :: Sorry dude, Cant enter field");
        }
    }

