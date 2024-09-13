using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Animator playerAnimator;
    void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        playerAnimator.SetFloat("walk", Input.GetAxis("Vertical"));
    }
}
