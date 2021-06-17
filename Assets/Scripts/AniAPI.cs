using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 旧版动画API测试脚本：播放 淡入淡出  倒播 加速减速  停止播放 是否在播放当前画面等内容
/// </summary>
public class AniAPI : MonoBehaviour {
	/// <summary>
	/// 旧版动画组件
	/// </summary>
	Animation ani;
	void Start () {
		//查找动画组件 并赋值给ani
		ani = GetComponent<Animation>();
		//Play直接播放动画  参数填一个string类型的需要的是动画名称
		//ani.Play("run");
		//IsPlaying判断动画是否在播放 参数填一个string类型的需要的是动画名称
		//返回值为bool类型 所以一般套用if来进行使用
		//print(ani.IsPlaying("run"));
		//CrossFade淡入淡出播放 从上一个动画到当前需要的动画过程有一些缓慢切换的效果
		//参数填一个String类型的需要的是动画名称
		//ani.CrossFade("attack1");

		//将当前时间帧设置为最后一帧
		//ani["die"].time = ani["die"].length;
		//倒播  负值越大越快   越小越慢
		//ani["die"].speed = -1;
		//播放死亡动画
		//ani.Play("die");
		//播放速度  正值越大越快  0则为暂停动画
		//ani["run"].speed = -1;
		//ani.Play("run");
		//Stop  停止播放当前动画
		//ani.Stop();
	}

	void Update () {
		//获取垂直轴值  W 1  S -1
		float v = Input.GetAxis("Vertical");
		//print(v);
		//获取水平轴值  A -1    D 1
		float h = Input.GetAxis("Horizontal");
		//print(h);
		//如果当前v的值或者h的值 不等于0时
        if (v!=0||h!=0)
        {
			ani.CrossFade("run");
			//说明已经按下了wsad键
			//移动
			//x的位置填写水平轴值  代表左右
			//z的位置填写垂直轴值  代表前后
			transform.Translate(h*Time.deltaTime, 0, v*Time.deltaTime);
        }

		//如果  水平和垂直的值为零
        else
        {
			//播放待机动画
			ani.CrossFade("idle");
        }
		//如果点击鼠标左键
        if (Input.GetMouseButtonDown(0))
        {
			//播放 攻击动画
			ani.Play("attack1");
        }
		//判断是否在播放攻击动画 成立则返回true 取反则返回fasle 就不会进入if的语句中
		//没有播放攻击动画 那么为fasle 然后取反则为true 这时候进入到if语句
		//如果当前没有播放攻击动画 并且没有播放跑步动画
        if (!ani.IsPlaying("attack1") && !ani.IsPlaying("run"))
        {
			//才可以播放待机动画
			ani.Play("idle");
        }
		//如果按下键盘的w键播放跑步动画
        if (Input.GetKey(KeyCode.W))
        {
			//播放跑步动画
			//ani.Play("run");
			ani.CrossFade("run");
			//Transform方法是移动的方法
			//参数需要的是三维向量 xyz 需要朝那个方位移动那么在该方位上写上数值
			//transform.Translate(0, 0, 0.5f*Time.deltaTime);
        }
		//如果抬起W键  则切换  待机的动画
        if (Input.GetKeyUp(KeyCode.W))
        {
			//播放待机动画
			//ani.Play("idle");
			ani.CrossFade("idle");
		}


	}
}
