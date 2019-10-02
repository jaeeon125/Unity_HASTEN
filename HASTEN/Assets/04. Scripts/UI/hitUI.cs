using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hitUI : MonoBehaviour
{
    public IEnumerator hit(int damage)
    {
        string name;
        this.gameObject.GetComponentInChildren<CanvasUI>().enabled = true;
        if (this.tag != "Player")
            name = "Blue_Damage";
        else
            name = "Red_Damage";
        GameObject hitDamage = Resources.Load(name) as GameObject;
        hitDamage.GetComponent<Text>().text = damage.ToString();
        GameObject child = Instantiate(hitDamage, this.gameObject.GetComponentInChildren<Canvas>().transform);
        yield return new WaitForSeconds(1f);
        Destroy(child.gameObject);
        this.gameObject.GetComponentInChildren<CanvasUI>().enabled = false;
    }
}