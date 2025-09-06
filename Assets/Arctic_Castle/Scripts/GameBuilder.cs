using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameBuilder : MonoBehaviour
{
    [SerializeField] Button sceneAButton;
    [SerializeField] Button sceneBButton;

    private void Awake()
    {
        StartCoroutine(LoadScenesFromBundle());
    }

    private IEnumerator LoadScenesFromBundle()
    {
        string bundleDir = System.IO.Path.Combine(Application.streamingAssetsPath, "AssetBundles");

        var levelBundleRequest = AssetBundle.LoadFromFileAsync(System.IO.Path.Combine(bundleDir, "bundle_scene_a"));
        var level2BundleRequest = AssetBundle.LoadFromFileAsync(System.IO.Path.Combine(bundleDir, "bundle_scene_b"));
        //var uiBundleRequest = AssetBundle.LoadFromFileAsync(System.IO.Path.Combine(bundleDir, "ui scene"));

        yield return new WaitUntil(() => levelBundleRequest.isDone  && level2BundleRequest.isDone);
        sceneAButton.interactable = true;
        sceneBButton.interactable = true;
        AssetBundle bundle = levelBundleRequest.assetBundle;
        if (bundle == null)
        {
            Debug.LogError("Failed to load AssetBundle.");
            yield break;
        }

        //var sceneLoadRequest = SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive);
        //var uiSceneRequest = SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
        //yield return new WaitUntil(() => sceneLoadRequest.isDone && uiSceneRequest.isDone);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.L))
    //    {
    //        Debug.Log("Loading Level 2");
    //        StartCoroutine(LoadLevel2());
    //    }
    //}

    //private IEnumerator LoadLevel2()
    //{
    //    var sceneLoadRequest = SceneManager.UnloadSceneAsync("Level1");
    //    yield return new WaitUntil(() => sceneLoadRequest.isDone);
    //    SceneManager.LoadSceneAsync("Level2", LoadSceneMode.Additive);
    //}

    public void LoadScene(string sceneName)
    {
        var sceneLoadRequest = SceneManager.LoadSceneAsync(sceneName);
    }
}
