using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float speed = 5;
    private Vector3 direction = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Rigidbody body;
    private float jumpPower = 30f;
    private bool isJumpState = false;
    private bool isCrouchState = false;
    private float distToGround;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f))
        {
            isJumpState = false;
        }
            
        ProcessInput();
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Ooouuuccchh!!");
    }

    private void ProcessInput() 
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector3.forward * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector3.back * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotation.y = -2;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotation.y = 2;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            direction *= 2;
        }

        // Jump
        if (Input.GetKey(KeyCode.X) && !isJumpState)
        {
            body.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJumpState = true;
            Debug.Log("Trying to jump.");
        }

        // Crouch
        if (Input.GetKeyDown(KeyCode.C) && !isCrouchState)
        {
            isCrouchState = true;
            speed /= 2;
            transform.localScale = new Vector3(1, 1/3, 1);
        }

        if (Input.GetKeyUp(KeyCode.C) && isCrouchState)
        {
            isCrouchState = false;
            speed *= 2;
            transform.localScale = new Vector3(1, 1, 1);
        }

        var translation = direction * Time.deltaTime;
        transform.Translate(translation);
        direction = Vector3.zero;

        var rotationAngle = rotation * Time.deltaTime;
        transform.Rotate(rotation);
        rotation = Vector3.zero;
    }
}
