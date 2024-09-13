using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        
    }

    void Update()
    {
        if (GetComponent<CapsuleCollider>()) { }
    }
}
