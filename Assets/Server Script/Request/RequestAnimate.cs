using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestAnimate : NetworkRequest
{
	public RequestAnimate()
	{
		request_id = Constants.CMSG_ANIMATE;
	}

	public void send(bool isWalking, bool isCombo)
	{
		packet = new GamePacket(request_id);
		packet.addBool(isWalking);
		packet.addBool(isCombo);
	}
}