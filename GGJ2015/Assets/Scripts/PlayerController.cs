using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject m_spotLight;
	public GameObject m_pointLight;
	public GameObject m_playerCube;

	public float speedScale = 10.0f;

	//tps
	public float speedX=0;
	public float speedY=0;
	//fps
	public float verticalSpeed=0;
	public float horizonalSpeed=0;

	//not use now
	/*
	private bool lockMoveX=false;
	private bool lockMoveY=false;
	*/

	// other version for fps mode
	public GameCameraMode gameCameraMode = GameCameraMode.UPDOWN_Mode;
	float screenWidth=1600;
	float screenHeight=900;
	float mouseAgiScale = 0.003f;

	void Awake(){
		CameraMgr.getInstance ().gameCameraMode = gameCameraMode;
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		Debug.Log (screenWidth + "x" + screenHeight);
	}

	void Update(){
		switch (CameraMgr.getInstance ().gameCameraMode) {
		case GameCameraMode.UPDOWN_Mode:
			if(Input.GetKeyDown(KeyCode.UpArrow)){
				speedY=1;
			}
			if(Input.GetKeyDown(KeyCode.DownArrow)){
				speedY=-1;
			}
			if(Input.GetKeyDown(KeyCode.LeftArrow)){
				speedX=-1;
			}
			if(Input.GetKeyDown(KeyCode.RightArrow)){
				speedX=1;
			}
			
			if(Input.GetKeyUp(KeyCode.UpArrow) && speedY>0){
				speedY=0;
			}
			if(Input.GetKeyUp(KeyCode.DownArrow) && speedY<0){
				speedY=0;
			}
			if(Input.GetKeyUp(KeyCode.LeftArrow) && speedX<0){
				speedX=0;
			}
			if(Input.GetKeyUp(KeyCode.RightArrow) && speedX>0){
				speedX=0;
			}
			gameObject.rigidbody.velocity = new Vector3(speedX*speedScale, 0 , speedY*speedScale);
			//gameObject.transform.Translate(new Vector3(speedX*speedScale,0,speedY*speedScale));
			//Vector3 currPosition = gameObject.transform.localPosition;
			//gameObject.transform.localPosition=new Vector3(currPosition.x+speedX*speedScale, currPosition.y, currPosition.z+speedY*speedScale);
			
			if(speedY>0){
				if(speedX>0){
					gameObject.transform.rotation= Quaternion.Euler(0,45,0);
				}else if(speedX==0){
					gameObject.transform.rotation= Quaternion.Euler(0,0,0);
				}else{
					gameObject.transform.rotation= Quaternion.Euler(0,-45,0);
				}
			}else if(speedY==0){
				if(speedX>0){
					gameObject.transform.rotation= Quaternion.Euler(0,90,0);
				}else if(speedX==0){
					gameObject.transform.rotation= gameObject.transform.rotation;
				}else{
					gameObject.transform.rotation= Quaternion.Euler(0,-90,0);
				}
			}else{
				if(speedX>0){
					gameObject.transform.rotation= Quaternion.Euler(0,135,0);
				}else if(speedX==0){
					gameObject.transform.rotation= Quaternion.Euler(0,180,0);
				}else{
					gameObject.transform.rotation= Quaternion.Euler(0,-135,0);
				}
			}
			break;
		case GameCameraMode.FPS_Mode:
			if(Input.GetKeyDown(KeyCode.W)){
				verticalSpeed=1;
			}
			if(Input.GetKeyDown(KeyCode.S)){
				verticalSpeed=-1;
			}
			if(Input.GetKeyDown(KeyCode.A)){
				horizonalSpeed=-1;
			}
			if(Input.GetKeyDown(KeyCode.D)){
				horizonalSpeed=1;
			}
			
			if(Input.GetKeyUp(KeyCode.W) && verticalSpeed>0){
				verticalSpeed=0;
			}
			if(Input.GetKeyUp(KeyCode.S) && verticalSpeed<0){
				verticalSpeed=0;
			}
			if(Input.GetKeyUp(KeyCode.A) && horizonalSpeed<0){
				horizonalSpeed=0;
			}
			if(Input.GetKeyUp(KeyCode.D) && horizonalSpeed>0){
				horizonalSpeed=0;
			}

			//gameObject.rigidbody.velocity = new Vector3(verticalSpeed*speedScale/Mathf.Cos(gameObject.transform.eulerAngles.y),0,verticalSpeed*speedScale/Mathf.Sin(gameObject.transform.eulerAngles.y));

			// Detect mouse position diff with center
			float offsetOnVertical = Input.mousePosition.y - screenHeight/2;
			float offsetOnHorizonal = Input.mousePosition.x - screenWidth/2;

			Vector3 currEuler = gameObject.transform.eulerAngles;
			Vector3 nextEuler = new Vector3(0, currEuler.y+offsetOnHorizonal*mouseAgiScale, currEuler.z);
			gameObject.transform.eulerAngles=nextEuler;

			break;
		default:
			break;
		}

	}
//
//	void OnCollisionEnter(Collision collision){
//		Debug.Log("collision");
//		Debug.Log("x:" + collision.contacts[0].normal.x);
//		Debug.Log("z:" + collision.contacts[0].normal.z);
//	}
//
//	void OnCollisionExit(Collision collision){
//		lockMoveX=false;
//		lockMoveY=false;
//	}
}
