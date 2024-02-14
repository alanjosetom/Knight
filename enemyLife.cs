using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLife : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemyEnergy;
    public GameObject keyObj;
    public GameObject trapObj;
    public Transform playerPos;
    public Rigidbody2D enemyFireobj;
    private GameObject fireObj;
    public AudioSource roarSound;
    [SerializeField] private AudioSource enemyDeath;
    // public float xpos = 1.84f;
    // public float ypos = 1.57f;
    void Start()
    {

    }
    // IEnumerator enemyFire()
    // {
    //     yield return new WaitForSeconds(2);

    // }
    // Update is called once per frame
    void Update()
    {
        if (enemyEnergy <= 0)
        {
            enemyDeath.Play();
            keyObj.SetActive(true);
            trapObj.SetActive(false);

            Destroy(gameObject);
        }
        if (Vector2.Distance(transform.position, playerPos.position) < 12)
        {
            // StartCoroutine(enemyFire());
            if (GameObject.FindGameObjectWithTag("enemyfire") == null)
            {
                Rigidbody2D p = Instantiate(enemyFireobj, new Vector3(-1.84f, 1.57f, 0), transform.rotation);
                p.velocity = Vector2.left * 10;
                roarSound.Play();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("fire"))
        {
            enemyEnergy -= 5;
            enemyDeath.Play();
            Destroy(other.gameObject);
        }
    }
}
