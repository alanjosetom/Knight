using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evilWizard : MonoBehaviour
{
    public int wizardLife;
    public bool evilWizard_attack = false;
    private Animator anim;
    [SerializeField] private AudioSource wizardAttack;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        InvokeRepeating("attackFunction", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (wizardLife <= 0)
        {
            Destroy(gameObject);
        }
    }
    void attackFunction()
    {
        bool fetchedBool = anim.GetBool("evilWizard_attack");
        if (fetchedBool)
        {
            anim.SetBool("evilWizard_attack", false);
            wizardAttack.Stop();
        }
        else
        {
            anim.SetBool("evilWizard_attack", true);
            wizardAttack.Play();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("fire"))
        {
            wizardLife -= 4;
            Destroy(other.gameObject);
        }
    }
}
