using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using GameAttrType;

public class BaseMember :MonoBehaviour
{

    public ObjectDataValue selfDataValue = null;

    public virtual void Init() { }
    public virtual void Updata(){ }
    public virtual void Destroy() { }

    public virtual BaseMember Clone() { return null; }

}
