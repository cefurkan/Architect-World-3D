using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;
    public static PlayerController Instance => instance;

    [Space]
    [SerializeField]
    private float moveSpeed = 1f;

    [Space]
    [SerializeField]
    private float moveRotateSpeed = 50f;

    Vector3 firstTouchPos = Vector3.zero;
    Vector3 deltaTouchPos = Vector3.zero;
    Vector3 direction = Vector3.zero;

    public Animator anim;

    public ResourcesSO wood;

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

            Vector3 moveRotate = new Vector3(0f, direction.x, 0f).normalized;

            direction.z = Mathf.Abs(direction.z);

            if (direction.z >= range * .5)
            {
                transform.Translate(moveForward * moveSpeed * Time.deltaTime);
                anim.SetFloat("MoveSpeed", direction.z);
            }


            if (Mathf.Abs(deltaTouchPos.x) >= range)
            {
                transform.Translate(moveRight * moveSpeed * Time.deltaTime);
                if (deltaTouchPos.x > range)
                {
                    // TODO yüzü sağa baksın
                }
                else if (deltaTouchPos.x < range)
                {
                    // TODO yüzü sola baksın
                }

            }
        }
        else
        {
            anim.SetFloat("MoveSpeed", 0);

        }


    }
}


