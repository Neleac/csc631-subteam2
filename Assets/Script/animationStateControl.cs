using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateControl : MonoBehaviour
{

    private Animator animator1;
    private Animator animator2;
    //better performance
    int ReadyHash;

    private bool isNetConnected;
    private NetworkManager networkManager;
    private PlayerManager playerManager;

    void Awake()
    {
        animator1 = GameObject.Find("ybot@Idle").GetComponent<Animator>();
        animator2 = GameObject.Find("ybot@IdleTwo").GetComponent<Animator>();

        ReadyHash = Animator.StringToHash("Ready");
        animator1.SetBool(ReadyHash, false);
        animator2.SetBool(ReadyHash, false);
        animator1.SetBool("isCombo", false);
        animator2.SetBool("isCombo", false);

        networkManager = GameObject.Find("Network Manager").GetComponent<NetworkManager>();

        GameObject.FindObjectOfType<PlayerManager>();
        GameObject obj = GameObject.Find("Player Manager");
        playerManager = obj.GetComponent<PlayerManager>();

        MessageQueue msgQueue = networkManager.GetComponent<MessageQueue>();
        msgQueue.AddCallback(Constants.SMSG_ANIMATE, OnResponseAnimate);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        processKeyboardControlAnimation();

        //bool isFighting = animator.GetBool("isCombo");
        //bool Ready = animator.GetBool(ReadyHash);
        //bool forwardPressed = Input.GetKey("w");
        //bool fightPressed = Input.GetKey("f");
        ////Players input
        //if (!Ready && forwardPressed)
        //{
        //    //boolean animation to be true
        //    animator.SetBool(ReadyHash, true);
        //}
        ////player not pressing
        //if (Ready && !forwardPressed)
        //{
        //    //boolean animation to be false
        //    animator.SetBool(ReadyHash, false);
        //}
        //if (!isFighting && (forwardPressed && fightPressed))
        //{
        //    animator.SetBool("isCombo", true);

        //}
        //if (isFighting && (!forwardPressed || !fightPressed))
        //{
        //    animator.SetBool("isCombo", false);
        //}
    }

    
    public void processKeyboardControlAnimation()
    {
        if (playerManager == null)
        {
            return;
        }
        Animator animator;
        if (playerManager.getPlayerNum() == 1)
        {
            animator = animator1;
        } else {
            animator = animator2;
        }

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
            animatorReadyToWalk = true;
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

        Animator animator;
        if (args.user_id == 1)
        {
            animator = animator1;
        }
        else
        {
            animator = animator2;
        }


        if (animator.GetBool(ReadyHash) != isWalking)
        {
            animator.SetBool(ReadyHash, isWalking);
        }

        if (animator.GetBool("isCombo") != isCombo)
        {
            animator.SetBool("isCombo", isCombo);
        }

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


