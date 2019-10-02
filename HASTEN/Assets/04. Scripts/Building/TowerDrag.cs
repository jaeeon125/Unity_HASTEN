using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TowerDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject BuildGroup;

    public GameObject[] Build = new GameObject[3];
    private GameObject _tower;

    private RaycastHit raycastHit;
    private int tower_index;
    public void OnBeginDrag(PointerEventData eventData)
    {
        tower_index = transform.GetSiblingIndex();
        GameObject[] tower = GameObject.FindGameObjectsWithTag("Tower");
        _tower = Instantiate(Build[tower_index], new Vector3(0, 0, 0), Build[tower_index].transform.rotation);
        foreach (GameObject ob in tower)
            ob.transform.Find("Trigger").gameObject.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        Physics.Raycast(ray, out raycastHit, 100f);
        if (raycastHit.collider.gameObject.tag.Equals("TowerGround"))
            _tower.gameObject.transform.position = raycastHit.point;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (raycastHit.collider.gameObject.tag.Equals("TowerGround"))
        {
            _tower.transform.parent = BuildGroup.transform;
            _tower.gameObject.isStatic = true;
            Rigidbody rigidbody = _tower.GetComponent<Rigidbody>();

            rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
        else
            Destroy(_tower.gameObject);
        GameObject[] towerList = GameObject.FindGameObjectsWithTag("Tower");
        foreach (GameObject ob in towerList)
            ob.transform.Find("Trigger").gameObject.SetActive(true);
    }
}
