using UnityEngine;
using System;

public class GazAnalizerButton : MonoBehaviour
{
    public static event Action<bool> OnButtonClicked;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            OnButtonClicked?.Invoke(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            OnButtonClicked?.Invoke(false);
        }
    }
}
