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

	void Update (){
		// 右・左
		float x = Input.GetAxisRaw ("Horizontal");
		
		// 上・下
		float y = Input.GetAxisRaw ("Vertical");
		
		// 移動する向きを求める
		Vector2 direction = new Vector2 (x, y).normalized;
		
		// 移動する向きとスピードを代入する
		spaceship.Move (direction);
	}
	//ぶつかった瞬間に瞬間に呼び出される
	void OnTriggerEnter2D(Collider2D c){

		//レイヤー名を習得
		string layerName = LayerMask.LayerToName (c.gameObject.layer);

		//レイヤー名がBullet(Enemy)の時は弾を削除
		if (layerName == "Bullet(Enemy)") {
			//弾を削除
			Destroy(c.gameObject);
		}
		//レイヤー名がBullet(Enemy)またはEnemyの場合は爆発
		if (layerName == "Bullet(Enemy)" || layerName == "Enemy") {
			//爆発する
			spaceship.Explosion ();
			
			//プレイヤー削除
			Destroy (gameObject);
		}
	}
}