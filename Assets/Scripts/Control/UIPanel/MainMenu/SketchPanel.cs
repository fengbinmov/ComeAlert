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

    private int progress = 0;

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
            progress = (int)(asyncOperation.progress*100);
            loaderSlider.value = progress;
            //Debug.Log("progress[" + progress+"]");
        }
    }
    private IEnumerator LoadScene()
    {
        asyncOperation = SceneManager.LoadSceneAsync(1);
        yield return asyncOperation;
    }
}
