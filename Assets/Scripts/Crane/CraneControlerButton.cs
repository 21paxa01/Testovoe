using System;
using UnityEngine;

public class CraneControlerButton : MonoBehaviour
{
    public Material active;
    public Material notActive;
    public Direction direction;
    
    
    public static event Action<Direction> OnButtonClicked;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            OnClicked();
            OnButtonClicked?.Invoke(direction);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            ExitClicked();
            OnButtonClicked?.Invoke(Direction.None);
        }
    }

    private void OnClicked()
    {
        GetComponent<MeshRenderer>().material = active;
    }
    
    private void ExitClicked()
    {
        GetComponent<MeshRenderer>().material = notActive;
    }
}
