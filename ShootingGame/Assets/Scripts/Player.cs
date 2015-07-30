using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	// Spaceshipコンポーネント
	Spaceship spaceship;

	//startメソッドをコルーチンとして呼び出す
	IEnumerator Start (){
		//Spaceshipコンポーネントを習得
		spaceship = GetComponent<Spaceship>();
		while (true) {
			// 弾をプレイヤーと同じ位置/角度で作成
			spaceship.Shot (transform);
			// shotDelay秒待つ
			yield return new WaitForSeconds (spaceship.shotDelay);
		}
	}

	void Update ()
	{
		// 右・左
		float x = Input.GetAxisRaw ("Horizontal");
		
		// 上・下
		float y = Input.GetAxisRaw ("Vertical");
		
		// 移動する向きを求める
		Vector2 direction = new Vector2 (x, y).normalized;
		
		// 移動する向きとスピードを代入する
		spaceship.Move (direction);
	}
}