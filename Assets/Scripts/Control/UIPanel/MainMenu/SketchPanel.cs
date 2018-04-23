using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class SketchPanel : BasePanel
{

    private GameObject sketchTools;
    private GameObject mSketchToolsObject;
    private Slider loaderSlider;

    private int nowProgress = 0;

    private AsyncOperation asyncOperation;
    public SketchPanel():base()
    {
        uIPanelType = UIPanelType.Sketch;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        sketchTools = Resources.Load("Prefabs/UIInfoTools/SketchTools") as GameObject;
        loaderSlider = transform.Find("LoadProgress").GetComponent<Slider>();
        loaderSlider.value = 0;
        mSketchToolsObject = GameObject.Instantiate(sketchTools);

        StartCoroutine(LoadScene());
    }

    public override void OnExit()
    {
        base.OnExit();
        Destroy(this.gameObject);
    }

    public override void OnPause()
    {
    }

    public override void OnResume()
    {
    }
    private void Update()
    {
        
        if (asyncOperation != null) {

            ushort toProgress = 0;
            if (asyncOperation.progress < 0.9f){
                toProgress = (ushort)(asyncOperation.progress * 200);
            }
            else {
                toProgress = 200;
            }
            if (nowProgress < toProgress) {
                nowProgress++;
            }
            loaderSlider.value = nowProgress/200f;
            if (nowProgress == 200)
                asyncOperation.allowSceneActivation = true;
        }
    }
    private IEnumerator LoadScene()
    {
        asyncOperation = SceneManager.LoadSceneAsync(1);
        asyncOperation.allowSceneActivation = false;
        yield return asyncOperation;
    }
}
