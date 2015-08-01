using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	//Spaceshipコンポーネント
	Spaceship spaceship;

	// Update is called once per frame
	IEnumerator Start () {
		//Spaceshipコンポーネントを習得
		spaceship = GetComponent<Spaceship>();

		//ローカル座標のy軸マイナス方向に移動する
		spaceship.Move (transform.up * -1);

		//canShotがfalseの場合、ここでコルーチンを終了させる
		if (spaceship.canShot == false) {
			yield break;
		}

		while (true) {
			//子要素を全て習得する
			for(int i = 0;i < transform.childCount; i++){

				Transform shotPosition = transform.GetChild(i);

				spaceship.Shot (shotPosition);
			}

			//shotDelay秒待つ
			yield return new WaitForSeconds (spaceship.shotDelay);
		}

	}

	void OnTriggerEnter2D(Collider2D c){

		//レイヤー名を習得
		string layerName = LayerMask.LayerToName (c.gameObject.layer);

		//レイヤー名がBullet(player)以外のときは何も行わない
		if (layerName != "Bullet(Player)")
			return;

		//弾の削除
		Destroy (c.gameObject);

		//爆発
		spaceship.Explosion ();

		//エネミー削除
		Destroy (gameObject);

	}
}
