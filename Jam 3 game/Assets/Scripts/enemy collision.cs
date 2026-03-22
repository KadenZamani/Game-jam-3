using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.SceneManagement;

public class enemycollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private StatBlock scriptReference;
    void Start()
    {
        scriptReference = GetComponent<StatBlock>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && scriptReference.isDead == false)
        {
            SceneManager.LoadScene(2);
        }
    }
}
    // Update is called once per frame
    

