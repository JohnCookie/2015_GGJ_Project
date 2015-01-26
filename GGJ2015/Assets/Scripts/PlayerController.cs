using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject m_spotLight;
	public GameObject m_pointLight;
	public GameObject m_playerCube;

	public float speedScale = 10.0f;

	public float speedX=0;
	public float speedY=0;

	private bool lockMoveX=false;
	private bool lockMoveY=false;

	void Update(){
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
	}

	void OnCollisionEnter(Collision collision){
		Debug.Log("collision");
		Debug.Log("x:" + collision.contacts[0].normal.x);
		Debug.Log("z:" + collision.contacts[0].normal.z);
	}

	void OnCollisionExit(Collision collision){
		lockMoveX=false;
		lockMoveY=false;
	}
}
