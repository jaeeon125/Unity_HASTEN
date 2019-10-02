using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningTowerController : CBuilding
{
    // Start is called before the first frame update
    void Start()
    {
        this.BuildingInit(this.gameObject.name, 100, 50, 10);
    }
}
