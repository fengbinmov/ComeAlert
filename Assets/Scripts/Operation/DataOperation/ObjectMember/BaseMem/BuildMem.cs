using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using GameAttrType;

public class BuildMem:BaseMember
{
    protected List<BaseMember> makeObjectList = new List<BaseMember>();
    protected UInt16 countryID;
    
    public virtual void BuildMakeObject() {
    }
    public virtual void AddMakeObject(UInt16 countryID, BaseMember mem)
    {
        this.countryID = countryID;
        makeObjectList.Add(mem);
    }
}
