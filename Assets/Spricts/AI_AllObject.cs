using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_AllObject : MonoBehaviour
{
    public List<GameObject> P = new List<GameObject>();
    public List<GameObject> C = new List<GameObject>();
    public List<GameObject> R = new List<GameObject>();

    [SerializeField]
    private GameObject DisMinObject = null;
    private GameObject temp = null;

    private void Start()
    {
        temp = DisMinObject;
    }

    public GameObject DistanceMin(GameObject g)
    {
        DisMinObject = temp;

        switch (g.tag)
        {
            case "Caesar":
                foreach (GameObject _G in P)
                {
                    var _dis = (_G.transform.position - g.transform.position).magnitude;
                    var old_dis = (DisMinObject.transform.position - g.transform.position).magnitude;
                    if (old_dis > _dis)
                        DisMinObject = _G;
                }
                break;
            case "Paper":
                foreach (GameObject _G in R)
                {
                    var _dis = (_G.transform.position - g.transform.position).magnitude;
                    if (DisMinObject.transform.position.magnitude > _dis)
                        DisMinObject = _G;
                }
                break;
            case "Rock":
                foreach (GameObject _G in C)
                {
                    var _dis = (_G.transform.position - g.transform.position).magnitude;
                    if (DisMinObject.transform.position.magnitude > _dis)
                        DisMinObject = _G;
                }
                break;
            default:Debug.Log("えらー　DistanceMinの因数でおかしなことが起こった");
                break;
        }

        return DisMinObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Caesar":
                C.Add(collision.gameObject);
                break;
            case "Paper":
                P.Add(collision.gameObject);
                break;
            case "Rock":
                R.Add(collision.gameObject);
                break;
            default:
                Debug.Log("えらー");
                break;
        }
    }

    public void Exit2DObject(GameObject g)
    {
        switch (g.tag)
        {
            case "Caesar":
                C.Remove(g);
                break;
            case "Paper":
                P.Remove(g);
                break;
            case "Rock":
                R.Remove(g);
                break;
            default:
                Debug.Log("えらー");
                break;
        }

        DisMinObject = null;
    }
}
