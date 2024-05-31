using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject leftWall, rightWall, upWall, botWall;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            Vector3 direction = touchPosition - transform.position;
            rb.velocity = new Vector2(direction.x, direction.y) * 15f;
            

            if (touch.phase == TouchPhase.Ended)
                rb.velocity = Vector2.zero;

            Vector3 newPosition = transform.localPosition;
            if (transform.localPosition.x - 26.5f <= leftWall.transform.localPosition.x) newPosition.x = leftWall.transform.localPosition.x + 26.5f;
            else if (transform.localPosition.x + 26.5f >= rightWall.transform.localPosition.x) newPosition.x = rightWall.transform.localPosition.x - 26.5f;
            if (transform.localPosition.y + 26.5f >= upWall.transform.localPosition.y) newPosition.y = upWall.transform.localPosition.y - 26.5f;
            else if (transform.localPosition.y - 26.5f <= botWall.transform.localPosition.y) newPosition.y = botWall.transform.localPosition.y + 26.5f;

            newPosition.z = -2;
            transform.localPosition = newPosition;
        }
    }
}
