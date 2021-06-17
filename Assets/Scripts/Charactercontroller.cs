using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色控制脚本：实现通过键盘上下方左右键控制当前脚本对象的移动操作
/// 获取水平垂直轴值
/// 移动时将对应轴转换成三维向量
/// 将移动的三维向量转换成旋转角度
/// 使用四元数中lerp方法实现 缓慢旋转效果
/// 使用Translate方法，使人物朝正前方移动
/// </summary>

public class Charactercontroller : MonoBehaviour {

	/// <summary>
	/// 动画组件
	/// </summary>
	/// 

	Animation ani;
	// Use this for initialization
	void Start () {
		//查找组件并赋值
		ani = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		//获取轴值
		//获取垂直轴值  W 1  S -1
		float v = Input.GetAxis("Vertical");
		//print(v);
		//获取水平轴值  A -1    D 1
		float h = Input.GetAxis("Horizontal");
		//print(h);

		//判断用户是否操作
		if(v!=0||h!=0)
        {
			//播放动画
			ani.Play("run");

			//将垂直和水平获取的值转换成Vector3
			Vector3 v3 =  new Vector3(h, 0, v);

			//欧拉角度
			//Euler将传入的三维向量转换成四元数(角度)，并用q接收
			//Quaternion q = Quaternion.Euler(v3);

			//LookRotation将传入的三维向量转换成四元数(角度)并实现旋转
			Quaternion q = Quaternion.LookRotation(v3);
			//四元数 Lerp 第一个参数：当前角度
			//            第二个参数：目标角度
			//            第三个参数：比例（速度）
			transform.rotation =  Quaternion.Lerp(transform.rotation,q,0.5f);

			//移动 朝人物的z值移动
			transform.Translate(Vector3.forward * 5 * Time.deltaTime);
		}
		else
        {
			//淡入淡出到待机动画
			ani.CrossFade("idel");
        }
		
	}
}
