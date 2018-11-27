using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
public class ProgressBar : MonoBehaviour
{
    Image image;
    public Image filledImage;
    public GameObject filledParent;
    AsyncOperation async;
    public int nowProcess;
    public static string scnenName = "main";
    private IEnumerator Start()
    {
        image = GetComponent<Image>();
        filledParent.SetActive(false);
        //
        image.color = Color.blue;
#if UNITY_EDITOR 
        UnityWebRequest request = UnityWebRequest.GetAssetBundle(@"D:/AB/" + scnenName + ".hx");
#else
          UnityWebRequest request = UnityWebRequest.GetAssetBundle( Application.dataPath+"/AB/" + scnenName+ ".hx");
#endif
        yield return request.Send();
        AssetBundle ab = DownloadHandlerAssetBundle.GetContent(request);
        StartCoroutine(LoadScene());
    }

    private void Update()
    {
        if (async == null)
            return;
        int toProcess;
        if (async.progress < 0.9f)
        {
            toProcess = (int)async.progress * 100;
        }
        else
        {
            toProcess = 100;
        }
        if (nowProcess < toProcess)
        {
            nowProcess++;
        }
        filledImage.fillAmount = nowProcess / 100f;
        if (nowProcess == 100)
        {
            async.allowSceneActivation = true;
        }
    }
    private IEnumerator LoadScene()
    {
        filledParent.SetActive(true);
        image.color = Color.white;

        async = SceneManager.LoadSceneAsync(scnenName);
        async.allowSceneActivation = false;
        yield return async;
    }
}
