using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float turnSpeed = 1;
    public Collider swordHitCollider;


    private bool ActiveFrames = false;

    void Start()
    {
    }

    void Update()
    {
        Vector3 rotation = new Vector3(0f, (Input.GetAxis("Turning") * turnSpeed * Time.deltaTime), 0f);
        transform.Rotate(rotation);

        if (ActiveFrames)
        {
            Collider[] cols = Physics.OverlapBox(swordHitCollider.bounds.center, swordHitCollider.bounds.extents, swordHitCollider.transform.rotation, LayerMask.GetMask("HittableBody"));
            foreach(Collider c in cols)
            {
                if(c.tag == "Enemy")
                {
                    c.gameObject.GetComponent<EnemyController>().GetHit(10);
                    StartCoroutine(EnemyInvincibilityFrames(c.gameObject));
                }
            }
        }
    }

    //Method is called by animation events
    void StartHitFrames()
    {
        ActiveFrames = true;
    }

    void EndHitFrames()
    {
        ActiveFrames = false;
    }

    IEnumerator EnemyInvincibilityFrames(GameObject enemy)
    {
        enemy.gameObject.layer = 0;
        yield return new WaitForSeconds(0.2f);
        enemy.gameObject.layer = 8;
    }
}
