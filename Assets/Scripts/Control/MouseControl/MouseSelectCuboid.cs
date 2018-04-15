using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelectCuboid : MonoBehaviour {

    private List<Transform> readySelectList = new List<Transform>();
    private float St_X, st_Y,paintW = 1f, rectW,rectH;
    private bool isPaint = false;

    private Vector3 forward;
    private Vector3 right;
    private Vector3 backward;
    private Vector3 left;

    private void Start()
    {
    }
    private void Update()
    {
        DebugShowRect();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RedGroup")
        {
            Debug.Log(other.transform.name);
            readySelectList.Add(other.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "RedGroup")
        {
            readySelectList.Remove(other.transform);
        }
    }
    private void OnDestroy()
    {
        GameControl.gameControl.SetNewCommand.AddSelectCube(readySelectList);
        GameControl.gameControl.SetNewCommand.SetTargetPostion(Vector3.zero);
    }
    private void OnGUI()
    {
        if (isPaint)
        {
            MakeSelectRect();
        }
    }
    //设置选择框的起始位置与宽高
    public void SetSelectPaintRect(float startX, float startY, float rectWidth,float rectHeight)
    {
        St_X = startX;
        st_Y = startY;
        rectW = rectWidth;
        rectH = -rectHeight;
        isPaint = true;
    }
    //设置选择体的宽和高
    public void SetTwoPoint(Vector3 start, Vector3 end)
    {
        InitFourVector();
        Vector3 width;
        Vector3 height;
        float angleWithCol = Vector3.Angle((forward), (end - start));
        float angleWithRow = Vector3.Angle((right), (end - start));
        //Debug.Log(angleWithCol + " " + angleWithRow);
        if (angleWithRow < 90f)           //右
        {
            if (angleWithCol < 90f)
            {
                width = Vector3.Project(end - start, right);
                height = Vector3.Project(end - start, forward);
                MakeSelectRectT(width.magnitude, height.magnitude);
            }   //右上
            else
            {
                width = Vector3.Project(end - start, right);
                height = Vector3.Project(end - start, backward);
                MakeSelectRectT(width.magnitude, -height.magnitude);
            }                   //右下
        }
        else if (angleWithRow > 90f)
        {                        //左
            if (angleWithCol < 90f)
            {
                width = Vector3.Project(end - start, right);
                height = Vector3.Project(end - start, forward);
                MakeSelectRectT(-width.magnitude, height.magnitude);
            }   //左上
            else
            {
                width = Vector3.Project(end - start, right);
                height = Vector3.Project(end - start, backward);
                MakeSelectRectT(-width.magnitude, -height.magnitude);
            }                   //左下
        }
        else
        {
            width = Vector3.Project(end - start, right);
            height = Vector3.Project(end - start, backward);
            MakeSelectRectT(-width.magnitude, -height.magnitude);
        }       //横纵重合
    }
    //生成选择体
    private void MakeSelectRectT(float width, float height)
    {
        float xBei = width;
        float zBei = height;
        GetComponent<BoxCollider>().center = new Vector3(xBei / 2, 0, zBei / 2);
        GetComponent<BoxCollider>().size = new Vector3(Mathf.Abs(xBei), 1, Mathf.Abs(zBei));
    }
    //生成选择框
    private void MakeSelectRect() {
        GUI.color = Color.grey;
        GUI.DrawTexture(new Rect(St_X, st_Y, paintW, rectH), new Texture2D(5, 100));
        GUI.DrawTexture(new Rect(St_X, st_Y, rectW, paintW), new Texture2D(5, 100));
        GUI.DrawTexture(new Rect(St_X + rectW - paintW, st_Y, paintW, rectH), new Texture2D(5, 100));
        GUI.DrawTexture(new Rect(St_X, st_Y + rectH - paintW, rectW, paintW), new Texture2D(5, 100));


        GUI.DrawTexture(new Rect(St_X, st_Y, paintW, paintW), new Texture2D(5, 100));
        GUI.DrawTexture(new Rect(St_X + rectW - paintW, st_Y, paintW, paintW), new Texture2D(5, 100));
        GUI.DrawTexture(new Rect(St_X, st_Y + rectH - paintW, paintW, paintW), new Texture2D(5, 100));
        GUI.DrawTexture(new Rect(St_X + rectW - paintW, st_Y + rectH - paintW, paintW, paintW), new Texture2D(5, 100));
    }

    //初始化四个方向向量
    private void InitFourVector()
    {
        forward = transform.TransformDirection(Vector3.forward);
        right = transform.TransformDirection(Vector3.right);
        backward = transform.TransformDirection(Vector3.back);
        left = transform.TransformDirection(Vector3.left);
    }

    private void DebugShowRect()
    {
        Debug.DrawLine(transform.position + forward, transform.position + backward, Color.black);
        Debug.DrawLine(transform.position + right, transform.position + left, Color.red);
    }
}
