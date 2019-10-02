using UnityEngine;
using System.Collections;

namespace DigitalRuby.PyroParticles
{
    public interface ICollisionHandler
    {
        void HandleCollision(GameObject obj, Collision c);
    }
    public class FireCollisionForwardScript : MonoBehaviour
    {
        public ICollisionHandler CollisionHandler;

        public void OnCollisionEnter(Collision col)
        {
            Debug.Log(col.gameObject.tag);
            if (col.gameObject.tag.Equals("BaseCamp") || col.gameObject.tag.Equals("Enemy"))
            {
                CollisionHandler.HandleCollision(gameObject, col);
                if (col.gameObject.tag.Equals("Enemy"))
                {
                    col.gameObject.GetComponent<CUnit>().getDamage(70);
                    if (col.gameObject.GetComponent<CUnit>().HP < 0)
                        this.transform.parent.gameObject.transform.GetChild(1).gameObject.GetComponent<BuildingController>().setIsTarget(false);
                }
            }
        }
    }
}
