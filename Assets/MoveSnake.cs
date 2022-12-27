using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MoveSnake : MonoBehaviour
{
    public Transform movePoint;
    public float snakeSpeed;

    public Transform segmentPrefab;
    private List<Transform> segments;
    private string directionQueue;
    private string snakeDirection;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        segments = new List<Transform>();
        segments.Add(this.transform);
        snakeDirection = "right";
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, snakeSpeed * Time.deltaTime);

        foreach(Transform segment in segments) {
            // segment.position = Vector3.MoveTowards();
        }

        // if(Vector3.Distance(transform.position, movePoint.position) <= .05f) {
        //     if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {
        //         movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        //     }
        //     else if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
        //         movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
        //     }
        // }

        if(Input.GetKeyDown(KeyCode.A) && snakeDirection != "right") {
            directionQueue = "left";
        }
        if(Input.GetKeyDown(KeyCode.D) && snakeDirection != "left") {
            directionQueue = "right";
        }
        if(Input.GetKeyDown(KeyCode.W) && snakeDirection != "down") {
            directionQueue = "up";
        }
        if(Input.GetKeyDown(KeyCode.S) && snakeDirection != "up") {
            directionQueue = "down";
        }

        if(Vector3.Distance(transform.position, movePoint.position) == 0f) {
            snakeDirection = directionQueue;
            switch(snakeDirection) {
                case "left":
                    movePoint.position += new Vector3(-1f, 0f, 0f);
                    break;
                case "right":
                    movePoint.position += new Vector3(1f, 0f, 0f);
                    break;
                case "up":
                    movePoint.position += new Vector3(0f, 1f, 0f);
                    break;
                case "down":
                    movePoint.position += new Vector3(0f, -1f, 0f);
                    break;
            }
        }
    }
}
