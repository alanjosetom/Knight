using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemyLife;
    public AudioSource screamAudio;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        InvokeRepeating("attackFunction", 1.5f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator waitsecond()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);

    }
    void attackFunction()
    {
        bool fetchedBool = anim.GetBool("fireOn");
        if (fetchedBool)
        {
            anim.SetBool("fireOn", false);

        }
        else
        {
            anim.SetBool("fireOn", true);

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("fire"))
        {
            enemyLife -= 5;
            Destroy(other.gameObject);
        }
        if (enemyLife <= 0)
        {
            screamAudio.Play();
            anim.SetBool("destroy", true);
            StartCoroutine(waitsecond());

        }

    }
}
