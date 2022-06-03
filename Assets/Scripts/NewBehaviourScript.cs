using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
           

        var psi = new ProcessStartInfo();
        // point to python virtual env
        // anaconda 안의 python 파일 실행
        psi.FileName = @"C:\Users\9898h\anaconda3\envs\tfgpu2\python.exe";

        // Provide arguments
        // file.py 경로
        var script = @"C:\Users\9898h\SoundMaker\Assets\Scripts\file.py";
        var vidFileIn = "111";
        var inputPath = @"Assets\Sounds";
        var outputPath = @"Assets\Sounds";

        psi.Arguments = string.Format("\"{0}\" -v \"{1}\" -i \"{2}\" -o \"{3}\"",
                                       script, vidFileIn, inputPath, outputPath);

        // Process configuration
        psi.UseShellExecute = false;
        psi.CreateNoWindow = false;
        psi.RedirectStandardOutput = true;
        psi.RedirectStandardError = true;

        // Execute process and get output
        var errors = "nothing";
        var results = "nothing";

        using (var process = Process.Start(psi))
        {
            errors = process.StandardError.ReadToEnd();
            results = process.StandardOutput.ReadToEnd();
        }
        UnityEngine.Debug.Log("[알림] .py file 실행");
    }
}
