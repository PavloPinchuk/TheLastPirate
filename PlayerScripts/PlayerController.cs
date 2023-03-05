using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    public Camera sceneCamera;
    public float moveSpeed = 7;
    private float moveSpeedSaved;
    public Rigidbody2D rb;
    //Weapon weapon;
    private Vector2 moveDirection;
    private Vector2 lastMoveDirection;
    private Vector2 mousePosition;
    public PlayerStats ps;
    private static Vector2 position;
    public DynamicJoystick joystickMove;
    public DynamicJoystick joystickView;
    public bool isJoystick = true;
    public GameObject joysticks;
    private bool isFiring = false;
    //public float fireRate = 0.4f;

    public Animator anim;

    public void Start()
    {
        moveSpeedSaved = moveSpeed;
        //weapon = ps.weapon;
        if(isJoystick)
            Console.WriteLine();
            //InvokeRepeating("AutoFire", 0, gun.fireRate);
        else
        {
            //joystickMove.gameObject.
            joysticks.SetActive(false);
        }
        PlayerStats.OnPlayerKilled += HandlePlayerDefeated;
    }

    private void HandlePlayerDefeated(PlayerStats obj)
    {
        StopMove();
        StopView();
        CancelInvoke("AutoFire");
        isFiring = false;
        PlayerStats.OnPlayerKilled -= HandlePlayerDefeated;
    }

    void Update()
    {
        if (joystickMove.Direction.x != 0 && joystickMove.Direction.y != 0)
        {
            anim.SetBool("is_running", true);
        }
        else
        {
            anim.SetBool("is_running", false);
        }
        //Animate();
    }

    public Weapon getWeapon()
    {
        return ps.weapon;
    }

    public float getSpeed()
    {
        return moveSpeed;
    }

    void FixedUpdate()
    {
        ProcessInputs();
        position = this.transform.position;
        //Move();
        if (isJoystick)
            MoveJoystick();
        else
            Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0) && !isJoystick)
        {
            ps.weapon.Fire();
        }

        //if (Input.GetButtonDown("Shift"))
        //{
        //    Dash();
        //}

        if ((moveX == 0 && moveY == 0) && moveDirection.x != 0 || moveDirection.y != 0)
        {
            lastMoveDirection = moveDirection;
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;

    }

    void MoveJoystick()
    {
        rb.velocity = new Vector2(joystickMove.Direction.normalized.x * moveSpeed, joystickMove.Direction.normalized.y * moveSpeed);
        Vector2 aimDirection = joystickView.Direction;
        if (aimDirection.x != 0 && aimDirection.y != 0)
        {
            if (!isFiring)
            {
                InvokeRepeating("AutoFire", 0, ps.weapon.FireRate);
                isFiring = true;
            }

            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = aimAngle;
        }
        else
        {
            if (isFiring)
            {
                CancelInvoke("AutoFire");
                isFiring = false;
            }

        }


    }

    public void StopMove()
    {
        joystickMove.Resetinput();
        joystickMove.ResetInputDynamic();
        anim.SetBool("is_running", false);
        //moveSpeed = 0;
        //joystickMove.Direction.normalized.Set(0f, 0f);
        //rb.velocity = new Vector2(joystickMove.Direction.normalized.x * moveSpeed, joystickMove.Direction.normalized.y * moveSpeed);
    }

    public void StopView()
    {
        joystickView.Resetinput();
        joystickView.ResetInputDynamic();
    }

    //public void ContinueMove()
    //{
    //    //moveSpeed = moveSpeedSaved;
    //}

    void AutoFire()
    {
        ps.weapon.Fire();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    switch (collision.gameObject.tag)
    //    {
    //        case "Collectable":
    //            AddItemToInventory(collision.gameObject);
    //            collision.gameObject.SetActive(false);
    //            break;
    //        case "Money":
    //            ps.addMoney(collision.gameObject.GetComponent<Money>().value);
    //            collision.gameObject.SetActive(false);
    //            break;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Collectable":
                AddItemToInventory(collision.gameObject);
                collision.gameObject.SetActive(false);
                break;
            case "Money":
                ps.addMoney(collision.gameObject.GetComponent<Money>().value);
                collision.gameObject.SetActive(false);
                break;
        }
    }

    void AddItemToInventory(GameObject gameObject)
    {
        // ...
    }



    //void Animate()
    //{
    //    anim.SetFloat("AnimMoveX", moveDirection.x);
    //    anim.SetFloat("AnimMoveY", moveDirection.y);
    //    anim.SetFloat("AnimMoveMagnitude", moveDirection.magnitude);
    //    anim.SetFloat("AnimLastMoveX", lastMoveDirection.x);
    //    anim.SetFloat("AnimLastMoveY", lastMoveDirection.y);
    //}

    //private async void Dash()
    //{
    //    moveSpeed += 10;
    //    await
    //        Task.Delay(TimeSpan.FromSeconds(1));
    //    moveSpeed -= 10;
    //}


}
