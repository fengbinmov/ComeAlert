using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class BaseOperation
{
    private GameOperation gameOperation;
    public BaseOperation(GameOperation gameOperation) {
        this.gameOperation = gameOperation;
    }

    public virtual void Update() { }
    public virtual void Init() { }
    public virtual void Destroy() { }
}
