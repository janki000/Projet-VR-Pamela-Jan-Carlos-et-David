using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public CharacterController CharacterController;
    public float speed = 6;

    void Start()
    {
    }

    void Update()
    {
        Move();
    }
    private void Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove;
        CharacterController.Move(speed * Time.deltaTime * move);
    }
}