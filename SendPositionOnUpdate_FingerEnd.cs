using UnityEngine;
using System.Collections;

public class SendPositionOnUpdate_FingerEnd : MonoBehaviour {

	public OSC osc;

    public GameObject L_Palm;
    public GameObject R_Palm;
    public GameObject L_index_end;
    public GameObject L_middle_end;
    public GameObject L_pinky_end;
    public GameObject L_ring_end;
    public GameObject L_thumb_end;

    public GameObject R_index_end;
    public GameObject R_middle_end;
    public GameObject R_pinky_end;
    public GameObject R_ring_end;
    public GameObject R_thumb_end;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	  OscMessage message = new OscMessage();

//----------------------------Palm-----------------------------------//
        message.values.Add(L_Palm.transform.position.x);
        message.values.Add(L_Palm.transform.position.y);
        message.values.Add(L_Palm.transform.position.z);

        message.values.Add(L_Palm.transform.rotation.x);
        message.values.Add(L_Palm.transform.rotation.y);
        message.values.Add(L_Palm.transform.rotation.z);

        message.values.Add(R_Palm.transform.position.x);
        message.values.Add(R_Palm.transform.position.y);
        message.values.Add(R_Palm.transform.position.z);

        message.values.Add(R_Palm.transform.rotation.x);
        message.values.Add(R_Palm.transform.rotation.y);
        message.values.Add(R_Palm.transform.rotation.z);
//----------------------------Palm-----------------------------------//

//----------------------------HAND-----------------------------------//
        message.address = "/wek/leapinputs";
        //L_index_end
        message.values.Add(L_index_end.transform.position.x);
        message.values.Add(L_index_end.transform.position.y);
        message.values.Add(L_index_end.transform.position.z);

        message.values.Add(L_index_end.transform.rotation.x);
        message.values.Add(L_index_end.transform.rotation.y);
        message.values.Add(L_index_end.transform.rotation.z);
        //L_index_end

        //L_middle_end
        message.values.Add(L_middle_end.transform.position.x);
        message.values.Add(L_middle_end.transform.position.y);
        message.values.Add(L_middle_end.transform.position.z);

        message.values.Add(L_middle_end.transform.rotation.x);
        message.values.Add(L_middle_end.transform.rotation.y);
        message.values.Add(L_middle_end.transform.rotation.z);
        //L_middle_end

        //L_pinky_end
        message.values.Add(L_pinky_end.transform.position.x);
        message.values.Add(L_pinky_end.transform.position.y);
        message.values.Add(L_pinky_end.transform.position.z);

        message.values.Add(L_pinky_end.transform.rotation.x);
        message.values.Add(L_pinky_end.transform.rotation.y);
        message.values.Add(L_pinky_end.transform.rotation.z);
        //L_pinky_end

        //L_ring_end
        message.values.Add(L_ring_end.transform.position.x);
        message.values.Add(L_ring_end.transform.position.y);
        message.values.Add(L_ring_end.transform.position.z);

        message.values.Add(L_ring_end.transform.rotation.x);
        message.values.Add(L_ring_end.transform.rotation.y);
        message.values.Add(L_ring_end.transform.rotation.z);
        //L_ring_end

        //L_thumb_end
        message.values.Add(L_thumb_end.transform.position.x);
        message.values.Add(L_thumb_end.transform.position.y);
        message.values.Add(L_thumb_end.transform.position.z);

        message.values.Add(L_thumb_end.transform.rotation.x);
        message.values.Add(L_thumb_end.transform.rotation.y);
        message.values.Add(L_thumb_end.transform.rotation.z);
        //L_thumb_end

//----------------------------HAND-----------------------------------//

        //R_index_end

        message.values.Add(R_index_end.transform.position.x);
        message.values.Add(R_index_end.transform.position.y);
        message.values.Add(R_index_end.transform.position.z);

        message.values.Add(R_index_end.transform.rotation.x);
        message.values.Add(R_index_end.transform.rotation.y);
        message.values.Add(R_index_end.transform.rotation.z);
        //R_index_end

        //R_middle_end
        message.values.Add(R_middle_end.transform.position.x);
        message.values.Add(R_middle_end.transform.position.y);
        message.values.Add(R_middle_end.transform.position.z);

        message.values.Add(R_middle_end.transform.rotation.x);
        message.values.Add(R_middle_end.transform.rotation.y);
        message.values.Add(R_middle_end.transform.rotation.z);
        //R_middle_end

        //R_pinky_end
        message.values.Add(R_pinky_end.transform.position.x);
        message.values.Add(R_pinky_end.transform.position.y);
        message.values.Add(R_pinky_end.transform.position.z);

        message.values.Add(R_pinky_end.transform.rotation.x);
        message.values.Add(R_pinky_end.transform.rotation.y);
        message.values.Add(R_pinky_end.transform.rotation.z);
        //R_pinky_end

        //R_ring_end
        message.values.Add(R_ring_end.transform.position.x);
        message.values.Add(R_ring_end.transform.position.y);
        message.values.Add(R_ring_end.transform.position.z);

        message.values.Add(R_ring_end.transform.rotation.x);
        message.values.Add(R_ring_end.transform.rotation.y);
        message.values.Add(R_ring_end.transform.rotation.z);
        //R_ring_end

        //R_thumb_end
        message.values.Add(R_thumb_end.transform.position.x);
        message.values.Add(R_thumb_end.transform.position.y);
        message.values.Add(R_thumb_end.transform.position.z);

        message.values.Add(R_thumb_end.transform.rotation.x);
        message.values.Add(R_thumb_end.transform.rotation.y);
        message.values.Add(R_thumb_end.transform.rotation.z);
        //R_thumb_end

//----------------------------HAND-----------------------------------//

        osc.Send(message);

       /* message = new OscMessage();
        message.address = "/UpdateX";
        message.values.Add(transform.position.x);
        osc.Send(message);

        message = new OscMessage();
        message.address = "/UpdateY";
        message.values.Add(transform.position.y);
        osc.Send(message);

        message = new OscMessage();
        message.address = "/UpdateZ";
        message.values.Add(transform.position.z);
        osc.Send(message);*/


    }


}
