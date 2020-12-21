using System;
using System.IO;
using System.Text.RegularExpressions;

using UnityEditor;
using UnityEditor.Callbacks;

public class PostBuildActions
{
    [PostProcessBuild]
    public static void OnPostProcessBuild(BuildTarget target, string targetPath)
    {
        string path = Path.Combine(targetPath, "Build/UnityLoader.js");
        string text = File.ReadAllText(path);

        text = text.Replace("UnityLoader.SystemInfo.mobile", "false");
        File.WriteAllText(path, text);
    }
}
