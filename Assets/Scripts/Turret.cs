using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletFury;
using BulletFury.Data;
using Unity.VisualScripting;

public class Turret : MonoBehaviour
{
    /*public BulletManager bulletManager = null;

    private void Awake()
    {
        Application.targetFrameRate = 120;
    }

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = GetComponent<BulletManager>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletManager == null)
            return;

        bulletManager.Spawn(transform.position, transform.right);

        bulletManager.Spawn(transform.position, bulletManager.Plane == BulletPlane.XY ? transform.up : transform.forward);
    }*/

    [SerializeField] private BulletManager bulletManager = null;
    [SerializeField] private float rotateSpeed = 0f;

    private void Awake()
    {
        Application.targetFrameRate = 120;
    }

    private void Update()
    {
        if (bulletManager == null)
            return;

        // ReSharper disable Unity.InefficientPropertyAccess


        bulletManager.Spawn(transform.position, bulletManager.Plane == BulletPlane.XY ? transform.up : transform.forward);

        transform.Rotate(bulletManager.Plane == BulletPlane.XY ? Vector3.forward : Vector3.up, (rotateSpeed * Time.smoothDeltaTime));
    }
}
