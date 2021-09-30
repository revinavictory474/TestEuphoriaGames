using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector3 movement;
    private float speed = 5.0f;

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float directionX = Input.GetAxis("Horizontal");
        float directionY = Input.GetAxis("Vertical");
        movement = new Vector3(directionX, 0, directionY);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
