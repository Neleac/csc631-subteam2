using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestTransform : NetworkRequest
{
	public RequestTransform()
	{
		request_id = Constants.CMSG_TRANSFORM;
	}

	public void send(float x, float y, float z)
	{
		packet = new GamePacket(request_id);
		packet.addFloat32(x);
		packet.addFloat32(y);
        packet.addFloat32(z);
	}
}