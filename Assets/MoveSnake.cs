using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MoveSnake : MonoBehaviour
{
    public Tilemap tilemap;
    public float snakeSpeed;

    private Vector3 snakePosition;
    private string snakeDirection;

    // Start is called before the first frame update
    void Start()
    {
        snakePosition = transform.position;
        snakeDirection = "right";
        snakeSpeed *= 0.001f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)) {
            snakeDirection = "left";
        }
        if(Input.GetKeyDown(KeyCode.D)) {
            snakeDirection = "right";
        }
        if(Input.GetKeyDown(KeyCode.W)) {
            snakeDirection = "up";
        }
        if(Input.GetKeyDown(KeyCode.S)) {
            snakeDirection = "down";
        }

        if(Input.GetKey(KeyCode.Space)) {
            transform.position = tilemap.CellToWorld(new Vector3Int(0, 0, 0));

            Debug.Log(transform.position);
        }

        switch(snakeDirection) {
            case "left":
                transform.position += Vector3.left * snakeSpeed;
                break;
            case "right":
                transform.position += Vector3.right * snakeSpeed;
                break;
            case "up":
                transform.position += Vector3.up * snakeSpeed;
                break;
            case "down":
                transform.position += Vector3.down * snakeSpeed;
                break;
        }
    }

    private Vector3 Translate(Vector3 coords) {
        coords.x -= 0.5f;
        coords.y -= 0.5f;

        return coords;
    }
}
