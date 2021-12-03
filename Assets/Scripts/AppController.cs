using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{
    [SerializeField] GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        // トップ画面へ遷移した時にカメラを調整する
    public void TopCameraSetting()
    {
        camera.transform.position = new Vector3(0,2,-5);
        camera.transform.rotation = Quaternion.Euler(0,0,0);
    }

    // ステータス画面へ遷移した時にカメラを調整する
    public void StatusCameraSetting()
    {
        camera.transform.position = new Vector3(0,3.5f,-5);
        camera.transform.rotation = Quaternion.Euler(20,0,0);
    }
}
