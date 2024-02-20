using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public RaceManger manger;
    private void OnTriggerEnter(Collider other)
    {
        manger.addCar(other.gameObject);
    }
}
