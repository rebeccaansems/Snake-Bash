using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public ParticleSystem ParticleSys;

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
        Destroy(this.GetComponentInChildren<Canvas>() ? this.GetComponentInChildren<Canvas>().gameObject : null);
    }
}
