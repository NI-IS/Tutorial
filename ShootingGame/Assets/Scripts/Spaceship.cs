using UnityEngine;
using System.Collections;

public class Spaceship : MonoBehaviour {

	//移動スピード
	public float speed;

	//弾を撃つ間隔
	public float shotDelay;

	//弾のprefab
	public GameObject bullet;

	//弾を撃つがどうか
	public bool canShot;

	//爆発のprefab
	public GameObject explosion;

	//爆殺の作成
	public void Explosion(){
		Instantiate (explosion, transform.position, transform.rotation);
	}

	//弾の作成
	public void Shot (Transform origin){
		Instantiate (bullet, origin.position, origin.rotation);
	}

	//機体の移動
	public void Move(Vector2 direction){
		GetComponent<Rigidbody2D>().velocity = direction * speed;
	}
}
