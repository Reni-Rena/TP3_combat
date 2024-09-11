using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouve : MonoBehaviour
{
    private Rigidbody _rb;
    public float speed;
    public float jumpForce;
    private bool onGround;

    private const string SOL = "sol";
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private void Start(){
        _rb = GetComponent<Rigidbody>();
    }

    void Update(){
        float moveHorizontal = Input.GetAxis(HORIZONTAL);
        float moveVertical = Input.GetAxis(VERTICAL);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            _rb.velocity = Vector3.zero;
            _rb.AddForce(new Vector3(0f, 1f, 0f) * jumpForce);
            onGround = false;
        }
    }
    public void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == SOL){
            onGround = true;
        }
    }

}
