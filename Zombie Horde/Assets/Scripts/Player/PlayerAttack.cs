﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator playerAnimator;
    public static PlayerAttack instance;
    void Start()
    {
        instance = this;
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame


    public void StartSwinging()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Debug.Log("TEST");
            playerAnimator.SetBool("isPunching", true);
            StartCoroutine(waiter());
            IEnumerator waiter()
            {
                //Wait for before performing the following action
                yield return new WaitForSeconds(0.36f);
                playerAnimator.SetBool("isPunching", false);
            }
        }
        
    }
}

