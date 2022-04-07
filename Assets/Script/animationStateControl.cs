using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateControl : MonoBehaviour
{


    Animator animator;
    //better performance
    int ReadyHash;

    private bool isNetConnected;
    private NetworkManager networkManager;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        ReadyHash = Animator.StringToHash("Ready");

        networkManager = GameObject.Find("Network Manager").GetComponent<NetworkManager>();
        MessageQueue msgQueue = networkManager.GetComponent<MessageQueue>();
        msgQueue.AddCallback(Constants.SMSG_ANIMATE, OnResponseAnimate);
    }

    // Update is called once per frame
    void Update()
    {
            processKeyboardControlAnimation();
        
    //    bool isFighting = animator.GetBool("isCombo");
    //    bool Ready = animator.GetBool(ReadyHash);
    //    bool forwardPressed = Input.GetKey("w");
    //    bool fightPressed = Input.GetKey("f");
    //    //Players input
    //    if (!Ready && forwardPressed)
    //    {
    //        //boolean animation to be true
    //        animator.SetBool(ReadyHash, true);
    //    }
    //    //player not pressing
    //    if (Ready && !forwardPressed)
    //    {
    //        //boolean animation to be false
    //        animator.SetBool(ReadyHash, false);
    //    }
    //    if (!isFighting && (forwardPressed && fightPressed)){
    //        animator.SetBool("isCombo", true);

        //    }
        //    if (isFighting && (!forwardPressed || !fightPressed)) {
        //        animator.SetBool("isCombo", false);
        //    }
    }

    public void processKeyboardControlAnimation()
    {
        bool isFighting = animator.GetBool("isCombo");
        bool Ready = animator.GetBool(ReadyHash);
        bool forwardPressed = Input.GetKey("w");
        bool fightPressed = Input.GetKey("f");
        bool animatorReadyToWalk = false;
        bool animatorToCombo = false;


        bool sendRequest = false;
        //Players input
        if (!Ready && forwardPressed)
        {
            //boolean animation to be true
            //animator.SetBool(ReadyHash, true);
            animatorReadyToWalk = true;
            sendRequest = true;
        }
        //player not pressing
        if (Ready && !forwardPressed)
        {
            //boolean animation to be false
            //animator.SetBool(ReadyHash, false);
            animatorReadyToWalk = false;
            sendRequest = true;
        }
        if (!isFighting && (forwardPressed && fightPressed))
        {
            // animator.SetBool("isCombo", true);
            animatorToCombo = true;
            sendRequest = true;
        }
        if (isFighting && (!forwardPressed || !fightPressed))
        {
            //animator.SetBool("isCombo", false);
            animatorToCombo = false;
            sendRequest = true;
        }

        if (sendRequest)
        {
            networkManager.SendAnimateRequest(animatorReadyToWalk, animatorToCombo);
        }
    }


    public void OnResponseAnimate(ExtendedEventArgs eventArgs)
    {
        ResponseAnimateEventArgs args = eventArgs as ResponseAnimateEventArgs;
        bool isWalking = args.isWalking;
        bool isCombo = args.isCombo;

        animator.SetBool(ReadyHash, isWalking);
        animator.SetBool("isCombo", isCombo);

        //if (args.user_id == Constants.OP_ID)
        //{
        //    int pieceIndex = args.piece_idx;
        //    int x = args.x;
        //    int y = args.y;
        //    Hero hero = Players[args.user_id - 1].Heroes[pieceIndex];
        //    gameBoard[hero.x, hero.y] = null;
        //    hero.Move(x, y);
        //    gameBoard[x, y] = hero;
        //}
        //else if (args.user_id == Constants.USER_ID)
        //{
        //    // Ignore
        //}
        //else
        //{
        //    Debug.Log("ERROR: Invalid user_id in ResponseReady: " + args.user_id);
        //}
    }
}


