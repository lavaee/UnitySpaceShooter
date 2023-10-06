using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int speed;
    public Rigidbody rb;

    private void Update()
    {
        
        //transform.Translate(1 * Time.deltaTime, 0, 0);
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(Vector3.up * speed,ForceMode.Acceleration);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(Vector3.up * speed,ForceMode.Force);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(Vector3.up * speed,ForceMode.Impulse);
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            rb.AddForce(Vector3.up * speed,ForceMode.VelocityChange);
        }

        /*
         
        start // فقط یک بار فراخونی موقع شروع بازی

        update // فراخوانی در هر فریم

        getComponent // گرفتن کامپوننت (مثل ترنسفورم) از یک گیم آبجکت

        Instantiate(gameObject) // نمونه سازی

        Instantiate(gameObject, vector3 position, Quaternion rotation) // نمونه سازی در موقعیت پوزیشن و جهت روتیشن 

        FindGameOjectWithTag(string Tag) // پیدا کردن آبجکت با تگ

        Random.Range(min, max) // مقدار تصادفی بین مین و مکس

        Quaternion.Identity // rotation = (0,0,0) // آبجکت بدون چرخش یا جهت

        Invoke(string function name, float Delay) // فراخوانی تابع با چند ثانیه تاخیر

        Mathf.Abs(float) // قدر مطلق مقدار

        OnCollisionEnter(Collision) // فراخوانی برخورد با جسم دیگر

        Input.mousePosition // موقعیت فعلی موس در صفحه

        Camera.main.ScreenToWorldPoint(Vector3 Position) // موقعیت موس در فضای سه بعدی

        Destroy(gameObject) // نابود کردن گیم آبجکت

        CompareTag(string) // مقایسه تگ

        */
    }
}
