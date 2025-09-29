using HTC.UnityPlugin.Vive;
using UnityEngine;

public class DeviceChanger : MonoBehaviour
{
    [SerializeField] private GameObject gazAnalizer;
    [SerializeField] private GameObject craneController;

    private bool isCrane;

    private void OnEnable()
    {
        ViveInput.AddPressDown(HandRole.LeftHand, ControllerButton.Grip, Change);
    }

    void Change()
    {
        gazAnalizer.SetActive(!isCrane);
        craneController.SetActive(isCrane);
        isCrane = !isCrane;
    }
}
