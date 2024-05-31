using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DIRECTION { LEFT, RIGHT, UP, DOWN}

public class MoveTriangle : MonoBehaviour
{
    [SerializeField] private GameOver gameOver;
    public DIRECTION direction;

    private void Start()
    {
        gameOver = GameObject.Find("GameManager").GetComponent<GameOver>();
    }
    void Update()
    {
        Vector3 newPos = transform.position;
        if (direction == DIRECTION.RIGHT)
            newPos.x += 5f * Time.deltaTime;
        else if (direction == DIRECTION.LEFT)
            newPos.x -= 5f * Time.deltaTime;
        else if (direction == DIRECTION.DOWN)
            newPos.y -= 5f * Time.deltaTime;
        transform.position = newPos;
        if (transform.localPosition.x <= -1500f || transform.localPosition.x >= 1500f || transform.localPosition.y <= -1000f) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameOver.endTheGame();
    }
}
