using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ApplicationOnAwake : MonoBehaviour
{
    Process proc;

    public void ApplicationStart()
    {
        proc = new Process();
        proc.StartInfo.FileName = "ファイルマネージャー+";
        proc.Start();
        
    }

    void Update()
    {
        
    }
}
