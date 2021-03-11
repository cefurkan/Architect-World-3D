using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public static Axe Instance => instance;
    private static Axe instance;

    public float power = .5f;
    public float meleeSpeed = 1f;


    public ParticleSystem particleSystem;

    public TreeManager currentTree;

    private void Awake()
    {
        // İleride Axe'ı Scriptable Objectden farklı itemlarla çekebiliriz,
        // O yüzden singleton yazdım. Şu an işimize yaramıyor fakat yarayacaktır.

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            currentTree = other.gameObject.GetComponentInParent<TreeManager>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (currentTree != null)
        {
            PlayerController.Instance.anim.SetBool("Melee", true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //  AwayFromTree();

        PlayerController.Instance.anim.SetBool("Melee", false);

        if (other.gameObject.GetComponentInParent<TreeManager>() == currentTree)
        {
            currentTree = null;
        }
    }

    private void Update()
    {
        TreeDestroyed();
    }

    private void OnNearTree()
    {
        if (currentTree != null)
        {
            currentTree.DecreaseWoodCount(power);
            particleSystem.Play();
        }
    }

    private void TreeDestroyed()
    {
        if (currentTree != null && currentTree.TreeWoodCount <= 0)
        {
            currentTree = null;
            PlayerController.Instance.anim.SetBool("Melee", false);
        }
    }

}
