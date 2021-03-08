using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    Transform planet;

    float gravity = -9.81f;

    private void Awake()
    {
        planet = GameObject.Find("Planet").GetComponent<Transform>();
    }
    void Start()
    {

        transform.rotation = Quaternion.FromToRotation(transform.up, (transform.position - planet.position.normalized).normalized);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 50.0f))
        {
            print("Found an object - distance: " + hit.distance);

            if(hit.distance >= 0)
            {
                float offSet = transform.position.y - hit.distance;
                transform.position = new Vector3(transform.position.x,offSet,transform.position.z);
            }
        }

    }
}
