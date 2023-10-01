using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceUnit : MonoBehaviour, ITap
{
    public GameObject spawnUnit;
    public Transform spawnPosition;
    public void onTapAction()
    {
        Instantiate(spawnUnit, spawnPosition.position, spawnPosition.rotation);
    }
}
