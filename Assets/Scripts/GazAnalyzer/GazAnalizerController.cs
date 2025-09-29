using System;
using UnityEngine;
using UnityEngine.UI;

public class GazAnalizerController : MonoBehaviour
{

    [SerializeField] private GameObject display;
    [SerializeField] private Image loadingImage;
    [SerializeField] private Text distanceText;
    [SerializeField] private float loadingTime;


    private bool isActive;
    private bool isLoading;
    private float time;
    private Transform dangerZone;

    private void Start()
    {
        dangerZone = GameObject.FindWithTag("DangerZone").transform;
    }

    private void OnEnable()
    {
        GazAnalizerButton.OnButtonClicked += SetLoading;
    }

    private void OnDisable()
    {
        GazAnalizerButton.OnButtonClicked -= SetLoading;
    }
    
    void SetLoading(bool load)
    {
        loadingImage.gameObject.SetActive(load);
        isLoading = load;
        time = 0;

        if (isLoading) loadingImage.color = isActive ? Color.black : Color.white;
    }


    private void Update()
    {
        if (isLoading)
        {
            time += Time.deltaTime;
            loadingImage.fillAmount = time / loadingTime;

            if (time >= loadingTime)
            {
                isLoading = false;
                isActive = !isActive;
                display.SetActive(isActive);
                loadingImage.gameObject.SetActive(false);
            }
        }

        if (isActive)
        {
           var distance = Math.Round(Vector3.Distance(transform.position,dangerZone.position),2);
           distanceText.text = distance + "м";
        }
    }
}
