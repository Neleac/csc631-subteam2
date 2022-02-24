using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateControl : MonoBehaviour
{
    Animator animator;
    //better performance
    int ReadyHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        ReadyHash = Animator.StringToHash("Ready");
    }

    // Update is called once per frame
    void Update()
    {
        bool isFighting = animator.GetBool("isCombo");
        bool Ready = animator.GetBool(ReadyHash);
        bool forwardPressed = Input.GetKey("w");
        bool fightPressed = Input.GetKey("f");
        //Players input
        if (!Ready && forwardPressed)
        {
            //boolean animation to be true
            animator.SetBool(ReadyHash, true);
        }
        //player not pressing
        if (Ready && !forwardPressed)
        {
            //boolean animation to be false
            animator.SetBool(ReadyHash, false);
        }
        if (!isFighting && (forwardPressed && fightPressed)){
            animator.SetBool("isCombo", true);
           
        }
        if (isFighting && (!forwardPressed || !fightPressed)) {
            animator.SetBool("isCombo", false);
        }
    }
}
