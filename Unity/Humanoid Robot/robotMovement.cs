using UnityEngine;
using System.Collections;

public class robotMovement : MonoBehaviour
{
   public float speed = 4.0f;
    //float rotationSpeed = 100.0f;
    public virtualJoystick vj;
    //void Update()
    //{
    //    float v = vj.Vertical() * speed;
    //    float h = vj.Horizontal() * speed;

    //    h *= Time.deltaTime;
    //    v *= Time.deltaTime;

    //    transform.Translate(v, 0, -h);
    //     transform.eulerAngles = new Vector3(0, h, 0);
    //    //transform.Rotate(0,rotation,0);
    //}
    public CharacterController controller;
    public Animation animation;
    Vector3 direction, moveDirection;
    void start() {
        controller = GetComponent<CharacterController>();
        animation = GetComponent<Animation>();
    }

    void Update()
    {
        float h = vj.Vertical();
        float v = -vj.Horizontal();

        if (h != 0 && v != 0)
        {
            animation.CrossFade("Walk");
        } else if (h == 0 && v == 0)
        {
            animation.CrossFade("Idle");

        }
        if (controller.isGrounded)
        { // are we grounded?
            direction = new Vector3(h, 0, v); // set direction
            moveDirection = new Vector3(h, moveDirection.y, v); // set moveDirection

        }
        else
        {
            moveDirection.y -= 0.1f; // apply gravity
        }
        controller.transform.LookAt(transform.position + direction);
        controller.Move((moveDirection * speed) * Time.deltaTime);
    }
}