using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public Rigidbody2D fireRb;
    public float speed;
    [SerializeField] private Animator anim;
    public bool isGround = false;
    public float fireSpeed;
    private bool gotKey = false;
    public Transform wizardLocation;
    public Animator wizardAnim;
    public Animator finalEvil;
    public Animator doorAni;
    [SerializeField] private AudioSource keyFind;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource fireSound;
    [SerializeField] private AudioSource deathSound;

    public bool FaceingRight;
    private bool aLive = true;
    // public GameObject gameObj;
    // public GameObject myPrefab;
    // Start is called before the first frame update
    void Start()
    {
        // gameObj = GetComponent<GameObject>();
        //rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        FaceingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGround && aLive)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            jumpSound.Play();
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("playerRun_left", true);
            anim.SetBool("playerRun_right", false);
            FaceingRight = false;
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            FaceingRight = true;
            anim.SetBool("playerRun_left", false);
            anim.SetBool("playerRun_right", true);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("playerRun_left", false);
            anim.SetBool("playerRun_right", false);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            // anim.SetBool("player_attack", true);
            if (FaceingRight)
            {
                Rigidbody2D p = Instantiate(fireRb, new Vector3(transform.position.x + 1.0f, transform.position.y, 0), transform.rotation);
                bool fireballSP = fireRb.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                Debug.Log("fireballSP" + fireballSP);
                p.velocity = transform.right * fireSpeed;

                fireSound.Play();
            }
            else
            {
                Rigidbody2D p = Instantiate(fireRb, new Vector3(transform.position.x - 1.0f, transform.position.y, 0), transform.rotation);
                bool fireballSP = fireRb.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                Debug.Log("fireballSP" + fireballSP);
                p.velocity = transform.right * -fireSpeed;
                fireSound.Play();
            }
        }
        // float distance = wizardLocation.transform.position.x - transform.position.x;
        // bool wizardAttack = wizardAnim.GetBool("evilWizard_attack");


    }
    private IEnumerator waitsecond()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);

    }
    private IEnumerator restartGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground") || other.gameObject.CompareTag("wizardzone"))
        {
            isGround = true;
        }
        if (other.gameObject.CompareTag("key"))
        {
            gotKey = true;
            Destroy(other.gameObject);
            keyFind.Play();
        }
        if (other.gameObject.CompareTag("enemyfire"))
        {
            anim.SetBool("destroy", true);
            aLive = false;
            deathSound.Play();
            // Invoke("activeFn", 1f);
            StartCoroutine(waitsecond());
        }
        if (other.gameObject.CompareTag("wizardzone"))
        {
            bool wizardAttack = wizardAnim.GetBool("evilWizard_attack");
            if (wizardAttack)
            {
                anim.SetBool("destroy", true);
                aLive = false;
                deathSound.Play();
                // Invoke("activeFn", 1f);
                StartCoroutine(waitsecond());

            }
        }
        if (other.gameObject.CompareTag("finalenemy"))
        {
            bool finalAttack = finalEvil.GetBool("fireOn");
            if (finalAttack)
            {
                anim.SetBool("destroy", true);
                aLive = false;
                deathSound.Play();
                // Invoke("activeFn", 1f);
                StartCoroutine(waitsecond());

            }
        }
        if (other.gameObject.CompareTag("saws"))
        {
            anim.SetBool("destroy", true);
            aLive = false;
            deathSound.Play();
            StartCoroutine(waitsecond());
        }
        if (other.gameObject.CompareTag("balltrap"))
        {
            anim.SetBool("destroy", true);
            aLive = false;
            deathSound.Play();
            StartCoroutine(waitsecond());
        }
        if (other.gameObject.CompareTag("door"))
        {
            if (gotKey && aLive)
            {
                doorAni.SetBool("gateOpen", true);
                StartCoroutine(restartGame());
            }
        }

    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("wizardzone"))
        {
            bool wizardAttack = wizardAnim.GetBool("evilWizard_attack");
            if (wizardAttack)
            {
                anim.SetBool("destroy", true);
                deathSound.Play();
                // Invoke("activeFn", 1f);
                StartCoroutine(waitsecond());
            }
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isGround = false;
        }
    }
    private void activeFn()
    {

        gameObject.SetActive(false);

    }

}
