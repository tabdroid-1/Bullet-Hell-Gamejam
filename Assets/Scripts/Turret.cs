using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletFury;
using BulletFury.Data;

public class Turret : MonoBehaviour
{
    [SerializeField] private BulletManager bulletManager = null;
    [SerializeField] private float rotateSpeed = 0f;

    private void Awake()
    {
        Application.targetFrameRate = 120;
    }

    private void Start()
    {
        bulletManager = GetComponent<BulletManager>();
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