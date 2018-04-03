using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
**   对Dictionaty的扩展
*/
public static class Extension{

    /// 简化字典的解析使用
    public static Tvalue TryGet<TKey,Tvalue>(this Dictionary<TKey,Tvalue> dict,TKey key)
    {
        Tvalue value;
        dict.TryGetValue(key, out value);
      
        return value;
    }
}
