using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchngUIRPC : MonoBehaviour
{
    [SerializeField]
    private Image image = null;

    [SerializeField]
    private Sprite[] texture2d = null;

    [SerializeField]
    private GameObject[] g = null;

    enum RPC_State
    {
        Rock,
        Parper,
        Caesar,
        LookAway,
    }

    RPC_State state = RPC_State.LookAway;

    public void PushButton_RPC()
    {
        switch (state)
        {
            case RPC_State.Rock:
                state = RPC_State.Parper;
                image.sprite = texture2d[1];
                break;
            case RPC_State.Parper:
                state = RPC_State.Caesar;
                image.sprite = texture2d[0];
                break;
            case RPC_State.Caesar:
                state = RPC_State.LookAway;
                image.sprite = texture2d[3];
                break;
            case RPC_State.LookAway:
                state = RPC_State.Rock;
                image.sprite = texture2d[2];
                break;
            default:
                Debug.Log("Ç¶ÇÁÅ[");
                break;
        }
    }

    public void CreateRPC(Transform t)
    {
        switch (state)
        {
            case RPC_State.Rock:
                Instantiate(g[0],
                        t.position,
                        Quaternion.identity,
                        GameObject.Find("Player").transform).transform.position += 
                        new Vector3(0,0,10);
                break;
            case RPC_State.Parper:
                Instantiate(g[1],
                        t.position,
                        Quaternion.identity,
                        GameObject.Find("Player").transform).transform.position +=
                        new Vector3(0, 0, 10);
                break;
            case RPC_State.Caesar:
                Instantiate(g[2],
                        t.position,
                        Quaternion.identity,
                        GameObject.Find("Player").transform).transform.position +=
                        new Vector3(0, 0, 10);
                break;
            case RPC_State.LookAway:
                break;
            default:
                Debug.Log("Ç¶ÇÁÅ[");
                break;
        }

    }

}
