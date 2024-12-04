using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject door;
    public bool isOpen = false;
    // Update is called once per frame
    void Update()
    {
        if (isOpen == true)
        {
            door.SetActive(false);
        }
        else
        {
            door.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            isOpen = true;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            isOpen = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isOpen = false;
    }
}
