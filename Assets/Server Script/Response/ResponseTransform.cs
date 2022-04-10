using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseTransformEventArgs : ExtendedEventArgs
{
	public int user_id { get; set; }
	public float x { get; set; }
	public float y { get; set; }
    public float z { get; set; }

	public ResponseTransformEventArgs()
	{
		event_id = Constants.SMSG_TRANSFORM;
	}
}

public class ResponseTransform : NetworkResponse
{
	private int user_id;
	private float x;
	private float y;
    private float z;

	public ResponseTransform()
	{
	}

	public override void parse()
	{
		user_id = DataReader.ReadInt(dataStream);
		x = DataReader.ReadFloat(dataStream);
		y = DataReader.ReadFloat(dataStream);
        z = DataReader.ReadFloat(dataStream);
	}

	public override ExtendedEventArgs process()
	{
		ResponseTransformEventArgs args = new ResponseTransformEventArgs
		{
			user_id = user_id,
			x = x,
			y = y,
            z = z
		};

		return args;
	}
}