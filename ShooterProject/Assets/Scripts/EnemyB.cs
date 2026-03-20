using UnityEngine;

public class EnemyB : MonoBehaviour {
  // set in inspector
  public float speed;
  public GameObject expoPrefab;

    void Update() {
    transform.Translate(Vector3.left * speed * Time.deltaTime);
  }

  private void OnCollisionEnter2D(Collision2D c) {
        if (c.gameObject.CompareTag("Bullet"))
        {
            var expoObj = Instantiate(expoPrefab, transform.position, Quaternion.identity);
            Destroy(expoObj, expoObj.GetComponent<ParticleSystem>().main.duration);
            Destroy(gameObject);
            Score.Instance.HitEnemy();
        }
        else if (c.gameObject.CompareTag("Player"))
        {
            var expoObj = Instantiate(expoPrefab, transform.position, Quaternion.identity);
            Destroy(expoObj, expoObj.GetComponent<ParticleSystem>().main.duration);
            Destroy(gameObject);
            c.gameObject.GetComponent<Player>().DamageFromEnemy();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Despawn"))
        {
            Destroy(gameObject);
        }
    }
}

