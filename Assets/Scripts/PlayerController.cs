using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void Update()
	{
		OVRInput.Update ();

		if (OVRInput.Get (OVRInput.Button.DpadUp))
		{
			rb.AddForce (Vector3.forward * speed);
		}
		if (OVRInput.Get (OVRInput.Button.DpadDown))
		{
			rb.AddForce (Vector3.back * speed);
		}
		if (OVRInput.Get (OVRInput.Button.DpadLeft))
		{
			rb.AddForce (Vector3.left * speed);
		}
		if (OVRInput.Get (OVRInput.Button.DpadRight))
		{
			rb.AddForce (Vector3.right * speed);
		}
		if (OVRInput.Get (OVRInput.Button.One))
		{
			rb.AddForce (Vector3.up * speed / 2);
		}
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Debug.Log ("H: " + moveHorizontal + ", V: " + moveVertical);
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) 
		{
			winText.text = "You Win";
		}
	}
}