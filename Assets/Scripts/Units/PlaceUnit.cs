using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceUnit : MonoBehaviour, ITap
{
    public GameObject normalUnit, fastUnit, tankUnit;
    public Transform spawnPosition;
    public Transform spawnUnitPosition;
    public string activeTroop;

    void Update()
    {
        activeTroop = SelectUnit.currentTroop;
    }
    public void onTapAction()
    {
        if (activeTroop == "Basic")
        {
            Instantiate(normalUnit, spawnPosition.position, spawnUnitPosition.rotation);
        }
        if (activeTroop == "Fast")
        {
            Instantiate(fastUnit, spawnPosition.position, spawnUnitPosition.rotation);
        }
        if (activeTroop == "Tank")
        {
            Instantiate(tankUnit, spawnPosition.position, spawnUnitPosition.rotation);
        }
    }
}
