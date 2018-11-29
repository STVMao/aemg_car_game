using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

	public float MovementSpeed;
	public float RotationSpeed;
	
	public WheelJoint2D BackWheel;
	public WheelJoint2D FrontWheel;
	
	public Rigidbody2D CarBody;
	
	private float Movement;
	private float Rotation;
	private float JumpForce;
	
	private void Start()
	{
		CarBody = GetComponent<Rigidbody2D>();
		JumpForce = 1000f;
	}
	
	private void Update()
	{
		Movement = Input.GetAxisRaw("Vertical") * MovementSpeed;
		Rotation = Input.GetAxisRaw("Horizontal");
		
		/*if(Input.GetKeyDown(KeyCode.Space))
		{
			CarBody.AddForce(new Vector2(0,JumpForce));
			CarBody.velocity = new Vector2(Movement,CarBody.velocity.y);
		}*/
	}	
	
	private void FixedUpdate()
	{
		if(Movement == 0)
		{
		    BackWheel.useMotor = false;
		    FrontWheel.useMotor = false;
		}
		else
		{
			BackWheel.useMotor = true;
		    FrontWheel.useMotor = true;
			
			JointMotor2D motor2D = new JointMotor2D{ motorSpeed = Movement, maxMotorTorque = 10000 };
			BackWheel.motor = motor2D;
			FrontWheel.motor = motor2D;
		}
		
		CarBody.AddTorque(Rotation * RotationSpeed * Time.deltaTime);
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			CarBody.AddForce(new Vector2(0,JumpForce));
			CarBody.velocity = new Vector2(Movement,CarBody.velocity.y);
		}
	}
}
