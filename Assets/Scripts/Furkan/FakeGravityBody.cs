using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bu script'i kullanan gameobje'de muhakkak RigidBody olmalı.
[RequireComponent(typeof(Rigidbody))]
public class FakeGravityBody : MonoBehaviour
{
    public FakeGravityAttractor attractor;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Rigidbody Rotation'larını ve Gravity'sini kapatıyorum
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
        
    }

    private void Update()
    {
        attractor.Attract(transform);
    }
}
