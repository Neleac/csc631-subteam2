using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestMove : NetworkRequest
{
	public RequestMove()
	{
		request_id = Constants.CMSG_MOVE;
	}

	public void send(float x, float y, float z)
	{
		packet = new GamePacket(request_id);
		packet.addInt32((int) x);
		packet.addInt32((int) y);
		packet.addInt32((int) z);
	}
}