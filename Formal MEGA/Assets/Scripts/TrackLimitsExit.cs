using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackLimitsExit : MonoBehaviour
{
    
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject trackLimitsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerExit(Collider collision)
    {
        trackLimitsText.SetActive(true);
    }
}
