using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    // khai bao cac bien su dung
    public static bool isGameOver = false; //Trạng Thái kết thúc Game
    public float jumpheight, speed; // độ cao khi nhảy  , tốc độ chạy
    private Animator player; // Nhân vật
    void Start()
    {
        // Ánh xạ Component
        player = GetComponent<Animator>();
        Time.timeScale = 1; //tỉ lệ với thời gian thực
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (! isGameOver) //Nếu game chưa kết thúc
        {
            if ( Input.GetKey(KeyCode.LeftArrow) ) // nếu nhấn phím mũi tên trái
            {
                // Thay đổi trạng thái của nhân vật
                player.SetBool("isIdle" , false);
                player.SetBool("isRunning", true);
                // di chuyển nhân vật
                gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime  );
                //Quay đầu nhân vật
                if ( gameObject.transform.localScale.x > 0)
                {
                    gameObject.transform.localScale = new Vector3(
                        gameObject.transform.localScale.x * -1,
                        gameObject.transform.localScale.y,
                        gameObject.transform.localScale.z
                        );
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow) ) // nếu nhấn phím mũi tên phải
            {
                // Thay đổi trạng thái của nhân vật
                player.SetBool("isIdle", false);
                player.SetBool("isRunning", true);
                // di chuyển nhân vật
                gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
                //Quay đầu nhân vật
                if (gameObject.transform.localScale.x < 0)
                {
                    gameObject.transform.localScale = new Vector3(
                        gameObject.transform.localScale.x * -1,
                        gameObject.transform.localScale.y,
                        gameObject.transform.localScale.z
                        );
                }
            }
            else if (Input.GetKey(KeyCode.Space) ) //Nếu nhấn phím cách thì nhân vật sẽ  nhảy
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
                    gameObject.GetComponent<Rigidbody2D>().velocity.x,
                    jumpheight
                    );
            }
            else // Nếu ko nhấn gì thì nhân vật đứng im
            {
                // Thay đổi trạng thái của nhân vật
                player.SetBool("isIdle", true);
                player.SetBool("isRunning", false);
            }
        }
    }
}
