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
        if (Input.GetKey(KeyCode.Space))
        {
            playerAnimator.SetBool("isPunching", true);
            StartCoroutine(waiter());
          
        }
        IEnumerator waiter()
        {
            //Wait for before performing the following action
            yield return new WaitForSeconds(0.35f);
            playerAnimator.SetBool("isPunching", false);
        }

    }
}

