using UnityEngine;
using System.Collections;

public class Room2DoorTrigger : MonoBehaviour
{
	public GameObject door3;
	public GameObject prefabParticle;
	public GameObject particleRoot;

	void OnTriggerEnter (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			if(PlayerInfo.getInstance().hasRoom3Key){
				Destroy(door3,2);
				GameObject particle = (GameObject) Instantiate(prefabParticle);
				particle.transform.parent=particleRoot.transform;
				particle.transform.localPosition=new Vector3(2087,0,1714);
				particle.transform.localRotation= Quaternion.Euler(90,0,0);
				particle.transform.localScale=new Vector3(360,360,360);
				ParticleSystem system = particle.GetComponent<ParticleSystem>();
				system.Play(true);

				PlayerInfo.getInstance().changePlayerMat(2);
				AudioControler.getInstance().playOpenDoor();
			}else{
				HintMgr.getInstance().showHint("Something On The Wall! But I can't Open It");
			}
		}
	}
	
	void OnTriggerExit (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			HintMgr.getInstance().hideHint();
			if(PlayerInfo.getInstance().hasRoom3Key){
				Destroy(gameObject);
			}
		}
	}
}

