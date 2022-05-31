using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new food menu",menuName = "Createfood/Kinds")]
public class CreateDesireObject : ScriptableObject
{
    public List<DesireDataBase> foodType = new List<DesireDataBase>();
}
