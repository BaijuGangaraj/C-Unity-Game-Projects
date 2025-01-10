using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody RB3D;
    public Rigidbody RB3D1;
    public float acc,dcc;public int dccindex;
    public float dcardegree;public float cardegree;
    public float dcarradian;public float carradian;
    public float CACDist;  // car and camera dist
    public int count1 = 0;
    void Start()
    {
        acc = 1f; dcc= 1f;
        dcardegree = 1.0f;
        CACDist = (RB3D.position.z-RB3D1.position.z);
        dcarradian = toradian(dcardegree);
       
    }

    // Update is called once per frame
    void Update()
    {
         
        //print(RB3D.position.x+"  "+RB3D.position.y+"  "+RB3D.position.z+"   "+RB3D.rotation.eulerAngles.y);
         //print(Mathf.Cos(carradian));

        if(Input.GetKey("w")){movecarfront();}
        if(Input.GetKey("s")){movecarback();}
        if(Input.GetKey("a")){ turncarleft(); }
        if(Input.GetKey("d")){ turncarright();}
        
        
        if(Input.GetKeyDown("w")||Input.GetKeyDown("s"))
        {
            if(dcc>1){acc = dcc;}
			if(dcc<=1){acc = 1;}
        }
        if(Input.GetKeyUp("w")||Input.GetKeyUp("s"))
        {
            dcc = acc;
            acc = 1;
        }

        if(dcc>1&&acc==1)//for car movement even after key up
        {
           movedccquantity(dccindex,dcc);
        }
    }

    float toradian(float degree)
    {
      float r;

      r = degree*(22.0f/7.0f)*(1.0f/180.0f);
      return r;

    }

    void turncarleft()
    {

      if(acc>1||dcc>1)     //for not turning when car is not moving
    {
            if(count1==10)
            {
            cardegree = cardegree+dcardegree;
            carradian = toradian(cardegree);
            print(carradian);

            RB3D.transform.localEulerAngles = new Vector3(0,-1*cardegree,0);

            RB3D1.transform.position = new Vector3(RB3D.position.x+(CACDist*Mathf.Sin(carradian)),RB3D1.position.y,RB3D.position.z-(CACDist*Mathf.Cos(carradian)));
            RB3D1.transform.localEulerAngles = new Vector3(0,-1*cardegree,0);
            
            count1 = 0;
            }
            count1++;
    }
    }
    void turncarright()
    {

      if(acc>1||dcc>1)      //for not turning when car is not moving
    {
            if(count1==10)
            {
            cardegree = cardegree-dcardegree;
            carradian = toradian(cardegree);

            RB3D.transform.localEulerAngles = new Vector3(0,-1*cardegree,0);
            
            RB3D1.transform.position = new Vector3(RB3D.position.x+(CACDist*Mathf.Sin(carradian)),RB3D1.position.y,RB3D.position.z-(CACDist*Mathf.Cos(carradian)));
            RB3D1.transform.localEulerAngles = new Vector3(0,-1*cardegree,0);

           
            count1 = 0;
            }
            count1++;

    }
    }
    void movecarfront()
    {
      RB3D.transform.Translate(0,0,(0.01f*acc));
      RB3D1.transform.Translate(0,0,(0.01f*acc));
      if(acc<=8){acc = acc*1.003f;}
      dccindex = 1;
    }
    void movecarback()
    {
      RB3D.transform.Translate(0,0,-(0.01f*acc));
      RB3D1.transform.Translate(0,0,-(0.01f*acc));
      if(acc<=5){acc = acc*1.003f;}
      dccindex = -1;
    }
    
    void movedccquantity(int morb,float dccqunatity)
    {
       if(morb == 1)
       {
       RB3D.transform.Translate(0,0,(0.01f*dccqunatity));
       RB3D1.transform.Translate(0,0,(0.01f*dccqunatity));
       }
      if(morb == -1)
       {
       RB3D.transform.Translate(0,0,-(0.01f*dccqunatity));
       RB3D1.transform.Translate(0,0,-(0.01f*dccqunatity));
       }
     
       dcc = dcc - 0.01f;
    }


}
