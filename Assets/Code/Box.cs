using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public int NumberOrbs = 1;

    public Text NumberOrbsRequiredText;
    public ParticleSystem ParticleSys;

    private void Start()
    {
        NumberOrbsRequiredText.text = NumberOrbs.ToString();
    }

    protected IEnumerator DestroyObjectWithParticles()
    {
        ParticleSys.Play();
        DestroyEverythingExceptParticles();
        yield return new WaitForSeconds(ParticleSys.main.duration * 10);
        Destroy(this.gameObject);
    }

    private void DestroyEverythingExceptParticles()
    {
        Destroy(this.GetComponent<SpriteRenderer>());
        Destroy(this.GetComponent<BoxCollider2D>());
        Destroy(NumberOrbsRequiredText.transform.parent.gameObject);
    }
}
