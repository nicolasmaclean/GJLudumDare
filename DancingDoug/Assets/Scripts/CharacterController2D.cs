using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour // thank you Brackeys :)
{
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	public LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	public int maxJumps;
	public int jumpsLeft;

	const float k_GroundedRadius = .1f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;

	[Header("Events")]
	[Space]
	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }
	public BoolEvent OnCrouchEvent;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();
	}

	void OnTriggerEnter2D(Collider2D other) {
		bool notPlayerCollider = true;
		if(other.isTrigger) return; // ignores trigger colliders, old bug let trigger around the head to reset jumps

		if(other.gameObject.Equals(gameObject))
			notPlayerCollider = false;

		if(notPlayerCollider) {
			m_Grounded = true;
			OnLandEvent.Invoke();
			jumpsLeft = maxJumps;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		bool notPlayerCollider = true;
		if(other.isTrigger) return;

		if(other.gameObject.Equals(gameObject))
			notPlayerCollider = false;

		if(notPlayerCollider) {
			m_Grounded = false;
		}
	}


	public void Move(float move, bool crouch, bool jump)
	{
		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{
			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (jump && (jumpsLeft > 0 || m_Grounded))
		{
			// Add a vertical force to the player.
			m_Grounded = false;

			if(m_Rigidbody2D.velocity.y < 0)
				m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 0);

			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			jumpsLeft--;
		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
