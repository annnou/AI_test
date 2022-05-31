using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private AI_AllObject aI_AllObject = null;

    [SerializeField]
    private float pushPower = 5;

    private GameObject g = null;

    private Rigidbody2D rb = null;

    private float timeCount = -1;

    public enum State
    {
        Seach,
        Move,
        Stop,
    }

    public State currentState = State.Stop;

    private void OnEnable()
    {
        TryGetComponent(out rb);
        StartCoroutine(SetTarget());
    }

    IEnumerator SetTarget()
    {
        yield return new WaitForSeconds(0.1f);

        g = aI_AllObject.DistanceMin(gameObject);

        yield return null;
    }

    private void SetStopState()
    {
        currentState = State.Stop;

        timeCount = 0;
    }

    private void SetSeachState()
    {
        currentState = State.Seach;

        g = null;

        StartCoroutine(SetTarget());

        timeCount = 0;
    }

    private void SetMoveState()
    {
        currentState = State.Move;
        timeCount = 0;
    }

    void Update()
    {
        switch(currentState)
        {
            case State.Stop:
                UpdateStopState();
                break;
            case State.Seach:
                UpdateSeachState();
                break;
            case State.Move:
                UpdateMoveState();
                break;
        }
    }

    private void UpdateStopState()
    {
        timeCount += Time.deltaTime;

        if (timeCount > 3)
        {
            timeCount = 0;

            switch(Random.Range(0, 3))
            {
                case 0:
                    SetMoveState();
                    break;
                case 1:
                    SetSeachState();
                    break;
                case 2:
                    SetStopState();
                    break;
                default:
                    break;
            }
        }
    }

    private void UpdateSeachState()
    {
        timeCount += Time.deltaTime;

        if (timeCount > 0.5f)
        {
            timeCount = 0;

            SetMoveState();
        }
    }

    private void UpdateMoveState()
    {
        timeCount += Time.deltaTime;

        if (timeCount > 1.5f)
        {
            if(Random.Range(1,50 + 1) >= 10)
            {
                timeCount = 0;
                if (g != null)
                    rb.AddForce((g.transform.position - gameObject.transform.position).normalized * pushPower, ForceMode2D.Impulse);
                else
                    SetSeachState();
            }
            else
            {
                SetStopState();
            }
        }
    }

    [SerializeField]
    private GameObject PrefabObject = null;

    const string c = "Caesar";
    const string p = "Paper";
    const string r = "Rock";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var coll = collision.collider;

        switch (gameObject.tag)
        {
            case c:
                if (coll.CompareTag(p))
                {
                    Instantiate(PrefabObject, 
                        coll.gameObject.transform.position, 
                        Quaternion.identity, 
                        GameObject.Find("Player").transform);

                    aI_AllObject.Exit2DObject(coll.gameObject);
                    Destroy(coll.gameObject);
                    SetSeachState();
                    }
                break;
            case p:
                if (coll.CompareTag(r))
                {
                    Instantiate(PrefabObject, 
                        coll.gameObject.transform.position, 
                        Quaternion.identity,
                        GameObject.Find("Player").transform);

                    aI_AllObject.Exit2DObject(coll.gameObject);
                    Destroy(coll.gameObject);
                    SetSeachState();
                }
                break;
            case r:
                if (coll.CompareTag(c))
                {
                    Instantiate(PrefabObject, 
                        coll.gameObject.transform.position, 
                        Quaternion.identity,
                        GameObject.Find("Player").transform);

                    aI_AllObject.Exit2DObject(coll.gameObject);
                    Destroy(coll.gameObject);
                    SetSeachState();
                }
                break;
            default:
                break;
        }
    }

}
