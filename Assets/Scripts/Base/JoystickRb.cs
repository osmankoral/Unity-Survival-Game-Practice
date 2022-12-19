using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickRb : MonoBehaviour
{
    private Joystick joystick;
    private Rigidbody rb;
    private Animator animator;
    private GameObject mr;
    [SerializeField] private float MoveSpeed = 10f;
    Camera camera;

    private bool isGround;

    private void Awake()
    {
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        mr = transform.GetChild(0).GetChild(0).gameObject;
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void SetJoystick(float value)
    {
        MoveSpeed = value;

        rb.isKinematic = false;
        rb.useGravity = true;
       // rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    private void TouchFunction()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        rb.angularVelocity = Vector3.zero;

        if (Input.GetMouseButton(0))
        {
            if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
            {
                animator.SetBool("run", true);
                transform.rotation = Quaternion.Euler(0f, (Mathf.Atan2(horizontal * 180, vertical * 180) * Mathf.Rad2Deg), 0f);
                rb.velocity = MoveSpeed * Time.fixedDeltaTime * transform.forward;
            }
        }
        else
        {
            animator.SetBool("run", false);
            rb.velocity = Vector3.zero;
        }
    }

    public float playerSpeed = 8f;
    public float sprintSpeed = 4f;
    public float walkSpeed = 2f;
    public float mouseSensitivity = 2f;
    public float jumpHeight = 1f;
    private bool isMoving = false;
    private bool isSprinting = false;
    private float yRot;
    private float xRot;
    private void PlayerMovment()
    {
        if(!GameManager.Instance.IsCursorOff)
        {
           yRot += Input.GetAxis("Mouse X") * mouseSensitivity;
           xRot -= Input.GetAxis("Mouse Y") * mouseSensitivity;
           transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, yRot, transform.localEulerAngles.z);
            Vector3 a = camera.transform.localEulerAngles;
            a.x = xRot;
            camera.transform.localEulerAngles = a;
        }

            isMoving = false;

            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                //transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed);
                rb.velocity += transform.right * Input.GetAxisRaw("Horizontal") * playerSpeed * Time.fixedDeltaTime;
                isMoving = true;
            }
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                //transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed);
                rb.velocity += transform.forward * Input.GetAxisRaw("Vertical") * playerSpeed * Time.fixedDeltaTime;
                isMoving = true;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.Translate(Vector3.up * jumpHeight);
            }

            /*if (Input.GetAxisRaw("Sprint") > 0f)
            {
                playerSpeed = sprintSpeed;
                isSprinting = true;
            }
            else if (Input.GetAxisRaw("Sprint") < 1f)
            {
                playerSpeed = walkSpeed;
                isSprinting = false;
            }

            animator.SetBool("isMoving", isMoving);
            animator.SetBool("isSprinting", isSprinting);*/

    }

    public void FixedUpdate()
    {
        PlayerMovment();
        if(isGround && isMoving) animator.SetBool("run", true);
        else animator.SetBool("run", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            mr.SetActive(false);
            isGround = true;
        }

        if (other.gameObject.layer == 4)
        {
            mr.SetActive(true);
            isGround = false;
        }
    }
}
