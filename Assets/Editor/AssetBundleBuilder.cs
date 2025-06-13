using UnityEditor;
using System.IO;
using UnityEngine;

public class AssetBundleBuilder
{
    [MenuItem("Assets/Build and Copy AssetBundle to StreamingAssets")]
    static void BuildAndCopy()
    {
        string buildPath = "AssetBundles/Android";
        string copyPath = "Assets/StreamingAssets/AssetBundles/Android";

        if (!Directory.Exists(buildPath)) Directory.CreateDirectory(buildPath);
        if (!Directory.Exists(copyPath)) Directory.CreateDirectory(copyPath);

        BuildPipeline.BuildAssetBundles(buildPath,
            BuildAssetBundleOptions.None,
            BuildTarget.Android);

        File.Copy(Path.Combine(buildPath, "mybundle"), Path.Combine(copyPath, "mybundle"), true);
        Debug.Log("AssetBundle copied to StreamingAssets.");
    }

}
