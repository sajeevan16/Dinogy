using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Mime;
using System.Collections.Generic;

public class JumpAndDuck : MonoBehaviour {
    public static System.Random ran = new System.Random();
    public Level level = null;
	public GameObject ground = null;
	public Collider2D standingCollider = null;
	public Collider2D duckingCollider = null;
	public AudioSource jumpAudioSource = null;
	public AudioClip jumpAudioClip = null;
	private Animator animator;
	private bool grounded = true;
	private bool ducking = false;
	private float jumpVelocity = 0f;
	private float gravity = 144f;
	private Vector3 startVector;
    public UnityEngine.UI.Text textkey;
    public UnityEngine.UI.Text fistkey;
    public string inputkeys1 = "";
    List<string> keyList = new List<string>() { "QAZ","WSX","EDC","RFVTGB","YHNUJM","IK","OL","P"};
    public GameObject f1;
    public GameObject f2;
    public GameObject f3;
    public GameObject f4;
    public GameObject j1;
    public GameObject j2;
    public GameObject j3;
    public GameObject j4;


    void Start() {
		animator = GetComponent<Animator>();
        inputkeys1 = "";
        inputkeys1 += (char)('a' + ran.Next(0, 26));
        inputkeys1 += (char)('a' + ran.Next(0, 26));
        inputkeys1 += (char)('a' + ran.Next(0, 26));
        inputkeys1 += (char)('a' + ran.Next(0, 26));
        inputkeys1 += (char)('a' + ran.Next(0, 26));
        inputkeys1 += (char)('a' + ran.Next(0, 26));
        textkey.text = inputkeys1.Substring(0, 1).ToUpper() + "~" + inputkeys1.Substring(1).ToUpper();
        standingCollider.enabled = true;
		duckingCollider.enabled = false;
        hideall();
        showObj();
        fistkey.text = inputkeys1.Substring(0, 1).ToUpper();
    }

	void Update() {
		if (grounded) {
			if (Input.GetKey(inputkeys1.Substring(0,1).ToLower())) {
                Debug.Log(inputkeys1);
				jump();
                inputkeys1 = inputkeys1.Substring(1) + (char)('a' + ran.Next(0, 26));
                textkey.text = inputkeys1.Substring(0, 1).ToUpper()+ "~" + inputkeys1.Substring(1).ToUpper();
                fistkey.text = inputkeys1.Substring(0, 1).ToUpper();
                hideall();
                showObj();
            }
            //else if (Input.GetAxis("Vertical") < 0) {
				//duck();
			//}
            else {
				stand();
			}
		} else {
			transform.position += jumpVelocity * Vector3.up * Time.deltaTime;
			jumpVelocity -= gravity * Time.deltaTime;

			if (transform.position.y < ground.transform.position.y) {
				grounded = true;
				transform.position = startVector;
				animator.SetBool("jumping", false);
			} else if (3 < transform.position.y && 20 < jumpVelocity) {
				jumpVelocity = 20;
			}
		}
        if (Input.GetKey(KeyCode.Escape))
        {
            UnityEngine.Application.Quit();
        }
    }

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject == ground) {
			grounded = true;
			transform.position = startVector;
			animator.SetBool("jumping", false);
		}
	}


	void OnCollisionExit2D(Collision2D collision) {
		if (collision.gameObject == ground) {
			grounded = false;
			animator.SetBool("jumping", true);
		}
	}

	void jump() {
		if (!grounded) {
			return;
		}

		stand();
		if (jumpAudioSource && jumpAudioClip) {
			jumpAudioSource.PlayOneShot(jumpAudioClip, 1);
		}
		startVector = transform.position;
		jumpVelocity = 40f + level.mainSpeed / 10f;
		grounded = false;
		animator.SetBool("jumping", true);

	}

	void duck() {
		if (ducking || !grounded) {
			return;
		}

		standingCollider.enabled = false;
		duckingCollider.enabled = true;
		ducking = true;
		animator.SetBool("ducking", true);
	}

	void stand() {
		if (!ducking) {
			return;
		}

		standingCollider.enabled = true;
		duckingCollider.enabled = false;
		ducking = false;
		animator.SetBool("ducking", false);
	}

    void hideall() {
        f1.SetActive(false);
        f2.SetActive(false);
        f3.SetActive(false);
        f4.SetActive(false);
        j1.SetActive(false);
        j2.SetActive(false);
        j3.SetActive(false);
        j4.SetActive(false);
    }

    void showObj() {
        if (keyList[0].ToLower().Contains(inputkeys1.Substring(0, 1).ToLower())) {
            f1.SetActive(true);
        }
        else if (keyList[1].ToLower().Contains(inputkeys1.Substring(0, 1).ToLower()))
        {
            f2.SetActive(true);
        }
        else if (keyList[2].ToLower().Contains(inputkeys1.Substring(0, 1).ToLower()))
        {
            f3.SetActive(true);
        }
        else if (keyList[3].ToLower().Contains(inputkeys1.Substring(0, 1).ToLower()))
        {
            f4.SetActive(true);
        }
        else if (keyList[4].ToLower().Contains(inputkeys1.Substring(0, 1).ToLower()))
        {
            j1.SetActive(true);
        }
        else if (keyList[5].ToLower().Contains(inputkeys1.Substring(0, 1).ToLower()))
        {
            j2.SetActive(true);
        }
        else if (keyList[6].ToLower().Contains(inputkeys1.Substring(0, 1).ToLower()))
        {
            j3.SetActive(true);
        }
        else if (keyList[7].ToLower().Contains(inputkeys1.Substring(0, 1).ToLower()))
        {
            j4.SetActive(true);
        }
    }

}
