using Meta.XR.ImmersiveDebugger.UserInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class   BallLauncher : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] float disparo;
      [SerializeField] float currentTime;
    [SerializeField] float nextShootTime;
    [Header("Dirección shooter")]
    [SerializeField] float maxY;
    [SerializeField] float minY;
    [SerializeField] float maxX;
    [SerializeField] float minX;
    BallMovement BallMovement;

    static float _forceMultiplier = 100f;
    // Start is called before the first frame update
    public static float _forceMultiply
    {
        get {  return _forceMultiplier; }
        set { _forceMultiplier = value; }
    }

  

    static bool _canShoot = false;

    public static bool canShoot
    {
        get { return _canShoot;  }
        set { _canShoot=value; }
    }

    private void OnEnable()
    {
        //GameManager.onStart += EnableLauncher;
        ///GameManager.onEnd += DisableLauncher;
    }

    private void OnDisable()
    {
        //GameManager.onStart -= EnableLauncher;
        ///GameManager.onEnd -= DisableLauncher;
    }

    [ContextMenu("Enable Launcher")]
    public void EnableLauncher() => _canShoot = true;

    [ContextMenu("Disable Launcher")]
    public void DisbleLauncher() => _canShoot = false;

    // Update is called once per frame
    private void Update()
    {
        if (currentTime<nextShootTime)
        {
            currentTime += Time.deltaTime;
        }
      
        if( currentTime > nextShootTime)
        {
            currentTime = 0;
            Shoot();
           

        }
    }

    private void Shoot()
    {
        var launcherAngle = GetRandomLauncherAngles();
        transform.rotation = Quaternion.Euler(launcherAngle.x, launcherAngle.y, 0);

        GameObject ballInstance = Instantiate(ball, transform.position, transform.rotation);

        ballInstance.GetComponent<Rigidbody>().AddForce(gameObject.transform.TransformDirection(Vector3.forward) * _forceMultiplier, ForceMode.Impulse);
     
        currentTime = 0;
    }
    Vector3  GetRandomLauncherAngles()
    {
        Vector3 rotationAngle;

        rotationAngle.x = Random.Range(minX, maxX);
        rotationAngle.y = Random.Range(minY, maxY);
        rotationAngle.z = 0f;

        return rotationAngle;
    }
        
    
}
