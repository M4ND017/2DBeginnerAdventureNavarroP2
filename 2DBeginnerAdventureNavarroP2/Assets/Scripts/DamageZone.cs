using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        DuckoController controller = other.GetComponent<DuckoController>();

        if (controller != null)
        {
            controller.ChangeHealth(-1);
        }
    }  
