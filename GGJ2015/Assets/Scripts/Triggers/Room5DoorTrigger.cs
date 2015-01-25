using UnityEngine;
using System.Collections;

public class Room5DoorTrigger : MonoBehaviour
{
	public GameObject door;
	public GameObject prefabParticle;
	public GameObject particleRoot;
	
	void OnTriggerEnter (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			if(PlayerInfo.getInstance().hasRoom5KeyBlue && PlayerInfo.getInstance().hasRoom5KeyRed && PlayerInfo.getInstance().hasRoom5KeyYellow){
				Destroy(door,2);
				GameObject particle = (GameObject) Instantiate(prefabParticle);
				particle.transform.parent=particleRoot.transform;
				particle.transform.localPosition=new Vector3(8675,0,4116);
				particle.transform.localRotation= Quaternion.Euler(90,0,0);
				particle.transform.localScale=new Vector3(360,360,360);
				ParticleSystem system = particle.GetComponent<ParticleSystem>();
				system.Play(true);

				PlayerInfo.getInstance().changePlayerMat(4);
				AudioControler.getInstance().playOpenDoor();
			}else{
				HintMgr.getInstance().showHint("Locked...");
			}
		}
	}
	
	void OnTriggerExit (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			if(PlayerInfo.getInstance().hasRoom5KeyBlue && PlayerInfo.getInstance().hasRoom5KeyRed && PlayerInfo.getInstance().hasRoom5KeyYellow){
				Destroy(gameObject);
			}
			HintMgr.getInstance().hideHint();
		}
	}
}

