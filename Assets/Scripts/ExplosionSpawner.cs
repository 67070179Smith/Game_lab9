using UnityEngine;
public class ExplosionSpawner : MonoBehaviour
{
    public GameObject explosionPrefab; // ลาก Prefab FX_Explosion มาใส่ตรงนี้
    public void SpawnExplosion(Vector3 position)
    {
        Instantiate(explosionPrefab, position, Quaternion.identity);
    }
    // ตัวอย่างเรียกใช้ตอนกระสุน/ระเบิดชน
    private void OnCollisionEnter(Collision collision)
    {
        SpawnExplosion(transform.position);
        Destroy(gameObject); // ท าลายตัวลูกระเบิด/กระสุนเอง
    }
}