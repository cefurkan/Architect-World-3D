using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bu scriptin olduğu gameobjelerde muhakkak RigidBody olmalı
[RequireComponent(typeof(Rigidbody))]
public class FakeGravityBody : MonoBehaviour
{
    public FakeGravityAttractor attractor;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

     attractor = Resources.Load<FakeGravityAttractor>("Planet");

        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
    }
    private void Update()
    {
        attractor.Attract(transform);
    }
}
