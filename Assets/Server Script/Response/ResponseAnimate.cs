using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseAnimateEventArgs : ExtendedEventArgs
{
	public int user_id { get; set; }
	public bool isWalking { get; set; }
	public bool isCombo { get; set; }


	//public int user_id { get; set; } // The user_id of whom who sent the request
	//public int piece_idx { get; set; } // The index of the piece to move. Belongs to player with id user_id
	//public int x { get; set; } // The x coordinate of the target location
	//public int y { get; set; } // The y coordinate of the target location

	public ResponseAnimateEventArgs()
	{
		event_id = Constants.SMSG_ANIMATE;
	}
}

public class ResponseAnimate : NetworkResponse
{
	private int user_id;
	private bool isWalking;
	private bool isCombo;

	public ResponseAnimate()
	{
	}

	public override void parse()
	{
		user_id = DataReader.ReadInt(dataStream);
		isWalking = DataReader.ReadBool(dataStream);
		isCombo = DataReader.ReadBool(dataStream);
	}

	public override ExtendedEventArgs process()
	{
		ResponseAnimateEventArgs args = new ResponseAnimateEventArgs
		{
			user_id = user_id,
			isWalking = isWalking,
			isCombo = isCombo
		};

		return args;
	}
}