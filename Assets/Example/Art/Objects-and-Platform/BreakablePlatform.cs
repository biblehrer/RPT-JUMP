
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    public ParticleSystem iceBreakEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Penguin"))
        {
            if (iceBreakEffect != null)
            {
                Instantiate(iceBreakEffect, transform.position, Quaternion.identity);
            }
            Destroy(gameObject, 0.5f);
        }
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}