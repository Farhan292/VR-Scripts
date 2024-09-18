using UnityEngine;

public class BulletShooter2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public GameObject badGuy;

    private bool canShoot = true;
    private float bulletDuration = 2f;
    private float reloadTime = 4f;

    private void Start()
    {
        InvokeRepeating("ShootBullet", 0f, reloadTime);
    }

    private void ShootBullet()
    {
        canShoot = !(badGuy == null);
        if (canShoot)
        {
            GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                bulletRb.velocity = -spawnPoint.forward * 5f;
            }
            Destroy(bullet, bulletDuration);

            canShoot = false;
            Invoke("EnableShooting", bulletDuration);
        }
    }

    private void EnableShooting()
    {
        canShoot = true;
    }
}
