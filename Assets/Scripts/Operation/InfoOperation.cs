using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class InfoOperation : BaseOperation
{
    public InfoOperation(GameOperation gameOperation) : base(gameOperation){ }

    public UIDirftInfo uIDirftInfo = new UIDirftInfo();
    public Dictionary<ushort, UIActiveInfo> uIActiveInfoDict = new Dictionary<ushort, UIActiveInfo>();
    public GameProgressInfo gameProgressInfo = new GameProgressInfo();

    public override void Update()
    {
        base.Update();
    }

    public override void Init()
    {
        base.Init();
    }

    public override void Destroy()
    {
        base.Destroy();
    }
}
