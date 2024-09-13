using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouve : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _animator;
    public float speed;
    public float jumpForce;
    public bool onGround;

    private const string SOL = "sol";
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private void Start(){
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update(){
        float moveHorizontal = Input.GetAxis(HORIZONTAL);
        float moveVertical = Input.GetAxis(VERTICAL);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            _animator.SetBool("jump", true);
            _rb.velocity = Vector3.zero;
            _rb.AddForce(new Vector3(0f, 1f, 0f) * jumpForce);
            onGround = false;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            
        }
        _animator.SetFloat("walk", Input.GetAxis("Vertical")); 
    }
    public void LateUpdate()
    {
        _animator.SetBool("jump", false);
    }
    public void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == SOL){
            onGround = true;
        }
    }

}
