using System.Collections;
using UnityEngine;

public class AndroidBundleLoader : MonoBehaviour
{
    IEnumerator Start()
    {
        string bundlePath = Application.streamingAssetsPath + "/AssetBundles/Android/mybundle";

        AssetBundle bundle = AssetBundle.LoadFromFile(bundlePath);

        if (bundle == null)
        {
            Debug.LogError("Failed to load AssetBundle at: " + bundlePath);
            yield break;
        }

        AssetBundleRequest assetRequest = bundle.LoadAssetAsync<GameObject>("Cube");
        yield return assetRequest;

        GameObject prefab = assetRequest.asset as GameObject;

        if (prefab == null)
        {
            Debug.LogError("Failed to load prefab from AssetBundle.");
            yield break;
        }

        Instantiate(prefab);

        bundle.Unload(false);
    }
}
