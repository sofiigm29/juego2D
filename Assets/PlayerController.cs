/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {



	public float maxSpeed = 5f;
	public float speed = 2f;
	public bool grounded;
	public float jumpPower = 6.5f;

	private Rigidbody2D rb2d;
	private Animator anim;
	private bool jump;
	private bool doubleJump;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
		anim.SetBool("Grounded", grounded);

		if (grounded){
			doubleJump = true;
		}

		if (Input.GetKeyDown(KeyCode.UpArrow)){
			if (grounded){
				jump = true;
				doubleJump = true;
			} else if (doubleJump){
				jump = true;
				doubleJump = false;
			}
		}
	}

	void FixedUpdate(){

		Vector3 fixedVelocity = rb2d.velocity;
		fixedVelocity.x *= 0.75f;

		if (grounded){
			rb2d.velocity = fixedVelocity;
		}

		float h = Input.GetAxis("Horizontal");

		rb2d.AddForce(Vector2.right * speed * h);

		float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

		if (h > 0.1f) {
			transform.localScale = new Vector3(1f, 1f, 1f);
		} 

		if (h < -0.1f){
			transform.localScale = new Vector3(-1f, 1f, 1f);
		}

		if (jump){
			rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
			rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
			jump = false;
		}

		Debug.Log(rb2d.velocity.x);
	}

	void OnBecameInvisible(){
		transform.position = new Vector3(-1,0,0);
	}

}*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class PlayerController : MonoBehaviour {

SerialPort puerto = new SerialPort("COM4", 9600);
	
	public float vel;

	int dato1;
	int dato2;

	public float maxSpeed = 5f;
	public float speed = 2f;
	public bool grounded;
	public float jumpPower = 6.5f;

	private Rigidbody2D rb2d;
	private Animator anim;
	private bool jump;
	private bool doubleJump;

	// Use this for initialization
	void Start () {

		puerto.Open();
		puerto.ReadTimeout=1;
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		

		if(puerto.IsOpen){
			try{
				prueba(puerto.ReadLine());
				Saltar();
			}
			catch(System.Exception){

			}
		}
		

	}

	public void prueba(string datoAr){
		string[]datosArray=datoAr.Split(char.Parse(","));
		if(datosArray.Length==2){
			dato1=int.Parse(datosArray[0]);
			dato2=int.Parse(datosArray[1]);

		}
	}


	void FixedUpdate(){

		//PARA USARLO CON EL POTENCIOMETRO
		if (dato2 >=700){
			transform.Translate(Vector2.left * vel, Space.Self);
		}
		if (dato2 <300){
			transform.Translate(Vector2.right *vel, Space.Self);
		}

		
		Vector3 fixedVelocity = rb2d.velocity;
		fixedVelocity.x *= 0.75f;

		if (grounded){
			rb2d.velocity = fixedVelocity;
		}

		float h = Input.GetAxis("Horizontal");

		rb2d.AddForce(Vector2.right * speed * h);

		float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);
		
		/*TECLAS->>if (h > 0.1f) {
			transform.localScale = new Vector3(1f, 1f, 1f);
		} 

		if (h < -0.1f){
			transform.localScale = new Vector3(-1f, 1f, 1f);
		}//<<- TECLAS*/



		if (jump){
			rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
			rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
			jump = false;
		}

		Debug.Log(rb2d.velocity.x);
	}

	void OnBecameInvisible(){
		transform.position = new Vector3(-1,0,0);
	}


	public void Saltar ()
	{
		anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
		anim.SetBool("Grounded", grounded);

		if (grounded){
			doubleJump = true;
		}

		if (dato1==1){
			if (grounded){
				jump = true;
				doubleJump = true;
			} else if (doubleJump){
				jump = true;
				doubleJump = false;
			}
		}
	}
}