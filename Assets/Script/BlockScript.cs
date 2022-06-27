using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    // Start is called before the first frame update

    //�ϐ��̍쐬//

    [SerializeField]
    private bool canRotate = true;


    //�ړ��p

    void Move(Vector3 moveDirection)
    {
        transform.position += moveDirection;
    }

    //�ړ��p�֐����ĂԊ֐��i�S��ށj

    public void MoveLeft()
    {
        Move(new Vector3(-1, 0, 0));
    }
    public void MoveRight()
    {
        Move(new Vector3(1, 0, 0));
    }
    public void MoveUp()
    {
       Move(new Vector3(0, 1, 0));
    }
    public void MoveDown()
    {
        Move(new Vector3(0, -1, 0));
    }


    //��]�p�i�Q��ށj

    public void RotateRight()
    {
        if (canRotate)
        {
            transform.Rotate(0, 0, -90);
        }
    }
    public void RotateLeft()
    {
        if (canRotate)
        {
            transform.Rotate(0, 0, 90);
        }
    }

}
