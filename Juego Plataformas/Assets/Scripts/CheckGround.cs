using UnityEngine;
using System.Collections;

public class CheckGround : MonoBehaviour {

    private PlayerController player;

	// Use this for initialization
	private void Start () {
        player = GetComponentInParent<PlayerController>();
        
	}

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            player.grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            player.grounded = false;
        }
    }


}
