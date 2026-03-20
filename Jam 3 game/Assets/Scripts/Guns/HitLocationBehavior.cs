using UnityEngine;
using System.Collections;

public class HitLocationBehavior : MonoBehaviour
{
    [SerializeField] float existenceDuration = 0.3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(nameof(WaitAndDestroy));
    }

  IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(existenceDuration);
        Destroy(gameObject);
    }
}
