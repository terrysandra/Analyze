using System.IO;
using UnityEditor;
using UnityEngine;

public class CreateAssetBundle : MonoBehaviour
{
    [MenuItem("Build/Build AssetBundles")]
    static void BulidAllAssetBundles()
    {
        string filePath = @"D:/AB";
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
        BuildPipeline.BuildAssetBundles(filePath,
            BuildAssetBundleOptions.ChunkBasedCompression,
            BuildTarget.WebGL);
    }
}