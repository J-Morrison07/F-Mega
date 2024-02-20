using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        UI.SetActive(true);
        Time.timeScale = time;
    }
}
