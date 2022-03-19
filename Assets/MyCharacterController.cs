using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    Vector3 LookPosition = Vector3.zero;
    bool isJumping = false;
    bool onGround = false;

    private void Update()
    {
        if (onGround)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                LookPosition = transform.position + -transform.right * 100;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                LookPosition = transform.position + transform.right * 100;
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
                GetComponent<Animator>().SetTrigger("Jump");
            }
        }
        if (LookPosition != Vector3.zero)
        {
            Vector3 direction = (LookPosition - transform.position).normalized;

            Quaternion rotationGoal = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, 5f * Time.deltaTime);

            if (transform.rotation == rotationGoal)
            {
                LookPosition = Vector3.zero;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0f, 300f, 0), ForceMode.Impulse);
            isJumping = false;
            onGround = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Exit")
        {
            onGround = true;

            GetComponent<Animator>().SetTrigger("Land");
            GetComponent<Animator>().SetTrigger("Run");
        }
    }
}
