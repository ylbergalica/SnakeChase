using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MoveSnake : MonoBehaviour
{
    public Tilemap tilemap;

    private Vector3 snakePosition;

    // Start is called before the first frame update
    void Start()
    {
        snakePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)) {
            transform.position += Vector3.left * 1f;
        }
        if(Input.GetKeyDown(KeyCode.D)) {
            transform.position += Vector3.right * 1f;
        }
        if(Input.GetKeyDown(KeyCode.W)) {
            transform.position += Vector3.up * 1f;
        }
        if(Input.GetKeyDown(KeyCode.S)) {
            transform.position += Vector3.down * 1f;
        }

        if(Input.GetKey(KeyCode.Space)) {
            transform.position = tilemap.CellToWorld(new Vector3Int(0, 0, 0));

            Debug.Log(transform.position);
        }
    }

    private Vector3 Translate(Vector3 coords) {
        coords.x -= 0.5f;
        coords.y -= 0.5f;

        return coords;
    }
}
