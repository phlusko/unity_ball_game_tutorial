using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour {
    public float speed = 0;
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start() {
        Debug.Log("Initialize player rigid body");
        rb = GetComponent<Rigidbody>();
    } 

    void FixedUpdate() {
        //Debug.Log("moving player");
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnMove(InputValue movementValue) {
        //Debug.Log("capturing input");
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
        }
    }
}
