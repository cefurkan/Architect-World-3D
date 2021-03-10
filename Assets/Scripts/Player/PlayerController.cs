using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;
    public static PlayerController Instance => instance;

    [Space]
    private float moveSpeed = 7.5f;

    [Space]
    [SerializeField]
    private float moveRotateSpeed = 50f;

    Vector3 firstTouchPos = Vector3.zero;
    Vector3 deltaTouchPos = Vector3.zero;
    Vector3 direction = Vector3.zero;

    public Animator anim;

    public ResourcesSO wood;

    public Transform modelRoot;

    [SerializeField]
    float range = 50f;

    void Start()
    {
        instance = this;
    }


    void Update()
    {
        Move();
    }

    private void Move()
    {
        float svermingSpeedz = direction.z * .003f;
        float svermingSpeedx = direction.x * .003f;


        if (Input.GetMouseButtonDown(0))
        {
            firstTouchPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {

            deltaTouchPos = Input.mousePosition - firstTouchPos;
            direction = new Vector3(deltaTouchPos.x, 0f, deltaTouchPos.y);

            Vector3 moveForward = new Vector3(0f, 0f, direction.z).normalized;
            Vector3 moveRight = new Vector3(direction.x, 0f, 0f).normalized;

            direction.z = Mathf.Abs(direction.z);
            if (direction.z >= range * .5)
            {
                moveSpeed = svermingSpeedz * 2.5f;
                modelRoot.transform.localRotation = Quaternion.Euler(0, 0f, 0);
                transform.Translate(moveForward * moveSpeed * Time.deltaTime);
                anim.SetFloat("MoveSpeed", svermingSpeedz);
            }
            if (moveForward.z == -1f)
            {
                modelRoot.transform.localRotation = Quaternion.Euler(0, 180f, 0);
            }


            if (Mathf.Abs(deltaTouchPos.x) >= range)
            {

                transform.Translate(moveRight * moveSpeed * Time.deltaTime);
                if (deltaTouchPos.x > range)
                {
                    moveSpeed = svermingSpeedx * 3;

                    modelRoot.transform.localRotation = Quaternion.Euler(0, 90f, 0);
                    anim.SetFloat("MoveSpeed", svermingSpeedx);

                }
                else if (deltaTouchPos.x < range)
                {
                    moveSpeed = -svermingSpeedx * 3;
                    anim.SetFloat("MoveSpeed", -svermingSpeedx);
                    modelRoot.transform.localRotation = Quaternion.Euler(0, -90f, 0);
                }

            }
        }
        else
        {
            anim.SetFloat("MoveSpeed", 0);
        }


    }
}


