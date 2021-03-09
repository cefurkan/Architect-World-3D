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
            Vector3 moveRotate = new Vector3(0f, direction.x, 0f).normalized;

            if (Mathf.Abs(deltaTouchPos.y) >= range * .5)
            {
                transform.Translate(moveForward * moveSpeed * Time.deltaTime);
            }

            if (Mathf.Abs(deltaTouchPos.x) >= range)
            {
                transform.Rotate(moveRotate * moveRotateSpeed * Time.deltaTime);
            }
        }
    }
}
  

