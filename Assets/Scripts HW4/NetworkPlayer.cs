using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : MonoBehaviour
{
    private NetworkManager networkManager;

    void Start()
    {
        networkManager = GameObject.Find("Network Manager").GetComponent<NetworkManager>();

        MessageQueue msgQueue = networkManager.GetComponent<MessageQueue>();
        msgQueue.AddCallback(Constants.SMSG_TRANSFORM, OnResponseTransform);
    }

    void Update()
    {
        Vector3 pos = transform.position;
        networkManager.SendTransformRequest(pos.x, pos.y, pos.z);
    }

    public void OnResponseTransform(ExtendedEventArgs eventArgs)
    {
        ResponseTransformEventArgs args = eventArgs as ResponseTransformEventArgs;
        float x = args.x;
        float y = args.y;
        float z = args.z;

        transform.position = new Vector3(x, y, z);
    }
}
