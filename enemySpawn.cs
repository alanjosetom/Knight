using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class enemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameObj;
    // private Animator playerAnim;
    void Start()
    {
        // playerAnim = gameObj.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator waitsecond()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            // anim = playerObj.GetComponent<Animator>();
            // playerAnim.SetBool("destroy", true);

            StartCoroutine(waitsecond());
        }
    }

}
