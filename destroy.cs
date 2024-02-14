using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class destroy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator playerObj;
    // [SerializeField] private GameManager gameManager;
    // private Animator anim;
    public GameObject gameObj;
    private Animator playerAnim;
    public AudioClip playerAudio;
    void Start()
    {
        playerAnim = gameObj.GetComponent<Animator>();
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
        if (other.gameObject.CompareTag("Player"))
        {
            // anim = playerObj.GetComponent<Animator>();
            playerObj.SetBool("destroy", true);
            AudioSource.PlayClipAtPoint(playerAudio, transform.position, 2);
            // Destroy(other.gameObject, 1f);
            Invoke("activeFn", 1f);
            StartCoroutine(waitsecond());
        }
    }
    private void activeFn()
    {
        gameObj.SetActive(false);
    }


}
