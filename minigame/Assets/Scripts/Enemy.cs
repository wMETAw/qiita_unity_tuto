using UnityEngine;
using System.Collections;

public class  Enemy : Token {

	// enemy count
	public static int Count = 0;

	// Use this for initialization
	void Start () {

		// enemy++
		Count++;

		 // size
		SetSize (SpriteWidth / 2, SpriteHeight / 2);
	 
		// random direction
		float dir = Random.Range (0, 359);

		// speed = 2
		float spd = 2;
		SetVelocity (dir, spd);
//		Debug.Log (spd);
	} 

	/// 更新
	void Update()
	{
		// カメラの左下座標を取得
		Vector2 min = GetWorldMin();
		// カメラの右上座標を取得する
		Vector2 max = GetWorldMax();
		
		if (X < min.x || max.x < X)
		{
			// 画面外に出たので、X移動量を反転する
			VX *= -1;
			// 画面内に移動する
			ClampScreen();
		}
		if (Y < min.y || max.y < Y)
		{
			// 画面外に出たので、Y移動量を反転する
			VY *= -1;
			// 画面内に移動する
			ClampScreen();
		}
	}
	 
	/// クリックされた
	public void OnMouseDown()
	{
		// enemy--
		Count--;

		// パーティクルを生成
		for (int i = 0; i < 32; i++)
		{
			Particle.Add(X, Y);
		}

		// 破棄する
		DestroyObj();
	}
}
