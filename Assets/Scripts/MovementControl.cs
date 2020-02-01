using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MovementControl : MonoBehaviour
{
    // Start is called before the first frame update
    private bool pressedDash = false;
    private bool dashing = false;
    private Vector3 dashDir;
    public float dashDuration = 0.25f;
    private float dashTimeLeft;
    public float dashSpeed = 2.25f;
    public float dashCooldownTime = 0.5f;
    private float dashCooldownLeft;
    public float speedMultiplier = 0.09f;
    public float timeFromZeroToMax = 0.6f;
    public Vector3 currentSpeed;

    public float deathCooldownTime = 0.2f;
    private float currentDeathCooldown = 0;

    public float pushbackTime = 0.5f;
    private float currentPushbackCooldown;
    private Vector3 pushbackMovement;

    private float moveTowardsX = 0, moveTowardsY = 0;

    void Start()
    {
        currentSpeed = new Vector3(0, 0, 0);
    }

    public void ResetMovement() {
        currentSpeed = new Vector3(0, 0, 0);
        currentDeathCooldown = deathCooldownTime;
    }

    public void Pushback(Vector3 direction)
    {
        pushbackMovement = direction*dashSpeed;
        currentPushbackCooldown = pushbackTime;
        currentSpeed = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (currentDeathCooldown > 0)
        {
            currentDeathCooldown -= Time.deltaTime;
            currentSpeed = new Vector3(0, 0, 0);
            return;
        }

        if (currentPushbackCooldown > 0)
        {
            currentPushbackCooldown -= Time.deltaTime;
            if (dashing)
            {
                transform.Translate(pushbackMovement.x * 2 * Time.deltaTime, pushbackMovement.y * 2 * Time.deltaTime, 0);
            }
            transform.Translate(pushbackMovement.x * Time.deltaTime, pushbackMovement.y * Time.deltaTime, 0);
            
            if (currentPushbackCooldown < 0.1)
            {
                dashing = false;
            }

            return;
        }

        float changeRatePerSecond = 1 / timeFromZeroToMax * Time.deltaTime;
        dashCooldownLeft -= Time.deltaTime;

        if (dashing)
        {
            pressedDash = false;
            dashTimeLeft -= Time.deltaTime;
            currentSpeed = dashDir * dashSpeed;
            if (dashTimeLeft <= 0) { 
                dashing = false;
                dashCooldownLeft = dashCooldownTime;
                currentSpeed = new Vector3(currentSpeed.x/1.5f, currentSpeed.y/1.5f, 0);
            }
        } else
        {
            moveTowardsX = 0;
            moveTowardsY = 0;
            moveTowardsX = Input.GetAxis("Horizontal");
            moveTowardsY = Input.GetAxis("Vertical");

            currentSpeed.x = Mathf.MoveTowards(currentSpeed.x, moveTowardsX, changeRatePerSecond);
            currentSpeed.y = Mathf.MoveTowards(currentSpeed.y, moveTowardsY, changeRatePerSecond);

            pressedDash = false;
            pressedDash = Input.GetButtonDown("Fire1"); /*Esto es joystick button 5 en project settings - input*/
            if (pressedDash && dashCooldownLeft < 0)
            {
                dashDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
                dashTimeLeft = dashDuration;
                dashing = true;
            }
        }
        

        transform.Translate(currentSpeed.x*speedMultiplier * Time.deltaTime, currentSpeed.y*speedMultiplier * Time.deltaTime, 0);

        return;


        /* ***************
         * TESTS: INERTIA 
         * ***************
         * 
         * float moveTowards = 0;
        float changeRatePerSecond = 1 / timeFromZeroToMax * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            moveTowards = -1.0f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveTowards = 1.0f;
        }

        if (Input.GetKey(KeyCode.LeftShift)){
            changeRatePerSecond *= 2;
        }

        speed = Mathf.MoveTowards(speed, moveTowards, changeRatePerSecond);
        transform.Translate(speed, 0, 0);*/

    }
}
