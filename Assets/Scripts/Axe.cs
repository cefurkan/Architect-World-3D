using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public static Axe Instance => instance;
    private static Axe instance;

    public float Speed = 1f;
    public float Power = 1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
     
    }
}
