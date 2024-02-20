using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackLimitsEnter : MonoBehaviour
{
    
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject trackLimitsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
            trackLimitsText.SetActive(true);
    }
}
