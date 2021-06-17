using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 动画事件：该脚本挂在当前添加动画事件的物体身上
/// </summary>
public class AniEvent : MonoBehaviour {
    public void Test(GameObject obj)
    {
        //Instantiate诞生物体的方法   可以将内置资源加载到场景中
        //小括号中可以放入需要创建的资源
        //当动画播放到那一帧的时候 创建个特效
        //1.代表克隆的资源2.克隆的物体位置点3.克隆的物体旋转角度
        //transform.position代表当前挂载脚本对象的位置
        //Quaternion.identity代表默认的旋转都（预测体的角度）
        Instantiate(obj,transform.position,Quaternion.identity);
    }
    public void Test1()
    {
        print("动画事件执行了！");
    }
}
