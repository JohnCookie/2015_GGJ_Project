using UnityEngine;
using System.Collections;

public class RookieU : MonoBehaviour
{
		public TweenPosition tp;
		public TweenRotation tr;

		// Use this for initialization
		public void startWalk ()
		{
			tp.gameObject.SetActive(true);
			tp.enabled=true;
			tp.ResetToBeginning();
			tp.PlayForward();
		}

	public void tpEnd(){
		tp.enabled=false;
		tr.gameObject.SetActive(true);
		tr.enabled=true;
		tr.ResetToBeginning();
		tr.PlayForward();
	}
	
	public void trEnd(){
		CameraMgr.getInstance().cameraStatus=CameraStatus.FollowPlayer;
	}
}

