using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class Human : MonoBehaviour
{
    [SerializeField]
    private Transform livingRoom = null;

    private NavMeshAgent navMesh = null;

    enum DesireState
    {
        Donothing,
        Sleep,
        Eat,
        Excretion,
    }

    class Desire
    {
        public DesireState desireState { get; private set; }

        public float value;

        public Desire(DesireState _state)
        {
            desireState = _state;

            value = 1;
        }
    }

    class Desires
    {
        public List<Desire> desireList { get; private set; } = new List<Desire>();

        public Desires()
        {
             int desireCount = Enum.GetNames(typeof(DesireState)).Length;

            for(int i = 0; i < desireCount; i++)
            {
                DesireState type = (DesireState)Enum.ToObject(typeof(DesireState), i);
                Desire desire = new Desire(type);

                desireList.Add(desire);
            }
        }

        public Desire GetDesire(DesireState _type)
        {
            foreach(Desire d in desireList)
            {
                if(d.desireState == _type)
                {
                    return d;
                }
            }
            return null;
        }

        public void SortDesire()
        {
            desireList.Sort((desire1, desire2) => desire2.value.CompareTo(desire1.value));
        }
    }

    Desires desires = new Desires();

    private void Start()
    {
        TryGetComponent(out navMesh);

        foreach(Desire d in desires.desireList)
        {
            Debug.Log(d.desireState);
        }
    }

    private void Update()
    {
        navMesh.SetDestination(livingRoom.position);
    }
}
