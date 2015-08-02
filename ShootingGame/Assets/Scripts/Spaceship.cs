using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
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

	//アニメーターコンポーネント
	private Animator animator;

	void Start(){
		//アニメーターコンポーネントを取得
		animator = GetComponent<Animator> ();
	}

	//爆殺の作成
	public void Explosion(){
		Instantiate (explosion, transform.position, transform.rotation);
	}

	//弾の作成
	public void Shot (Transform origin){
		Instantiate (bullet, origin.position, origin.rotation);
	}
	//アニメータコンポーネントの取得
	public Animator GetAnimator(){
		return animator;
	}
}
