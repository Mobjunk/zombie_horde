using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistingScript : MonoBehaviour
{
    PlayerAttack playerAttack => PlayerAttack.instance;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(playerAttack.playerAnimator.GetBool("isPunching")==true)
        {

        }
    }
}
