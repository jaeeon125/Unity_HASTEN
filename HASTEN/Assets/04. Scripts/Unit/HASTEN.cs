using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HASTEN : CUnit
{
    private void Start()
    {
        this.StatusInit(100, 0, 0, 0, 0);
    }

    public override IEnumerator die()
    {
        Destroy(this);
        yield return null;
    }
}
