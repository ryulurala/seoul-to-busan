using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonManager : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;

    [SerializeField]
    GameObject numberPrefab;

    [SerializeField]
    GameObject copyObject;

    public Text startingPoint;
    public Text middle;
    public Text destination;
    
    private GameObject resourceMap;
    
    public GameObject destMap;

    Camera mCamera;

    private int check = -1;
    private bool isStart = false;

    public List<GameObject> persons = new List<GameObject>(); // person
    public List<GameObject> mNumberList = new List<GameObject>(); // bar
    public List<Transform> personTransform = new List<Transform>(); // persons의 transform

    void Start()
    {
        mCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //둘다 선택 되었을 때
        if (check == 0) // 0
        {
            persons.Add(Instantiate(copyObject, resourceMap.transform.position, Quaternion.identity, transform));
            check = -1;

            personTransform.Add(persons[persons.Count-1].transform); // 캐릭터 위치 저장
            mCamera.GetComponent<CharacterCamera>().CharacterTransform = personTransform[personTransform.Count-1]; // 캐릭터 카메라 선택

            mNumberList.Add(Instantiate(numberPrefab, persons[persons.Count - 1].transform.position, Quaternion.identity, canvas.transform)); // bar 추가
            
            // 초기화
            resourceMap = null;
        }

        for (int i = 0; i < personTransform.Count; i++)
        {
            mNumberList[i].transform.position = mCamera.WorldToScreenPoint(personTransform[i].position + new Vector3(0, 0.6f, 0));
        }
    }

    public void SeoulClick()
    {
        if (!isStart)
        {
            destMap = null;
            destination.text = null;
            resourceMap = GameObject.Find("S_C");
            startingPoint.text = "서울";
            middle.text = "->";
            check = 1;
            isStart = true;
        }
        else if (isStart && check != 1)
        {
            destMap = GameObject.Find("S_C");
            destination.text = "서울";
            check = 0; // 출발지와 도착지가 둘다 선택됨
            isStart = false;
        }
    }

    public void IncheonClick()
    {
        if (!isStart)
        {
            destMap = null;
            destination.text = null;
            resourceMap = GameObject.Find("In_C");
            startingPoint.text = "인천";
            middle.text = "->";
            check = 2;
            isStart = true;
        }
        else if (isStart && check != 2)
        {
            destMap = GameObject.Find("In_C");
            destination.text = "인천";
            check = 0; // 출발지와 도착지가 둘다 선택됨
            isStart = false;
        }

    }

    public void GyeongiClick()
    {
        if (!isStart)
        {
            destMap = null;
            destination.text = null;
            resourceMap = GameObject.Find("G_C");
            startingPoint.text = "경기도";
            middle.text = "->";
            check = 3;
            isStart = true;
        }
        else if (isStart && check != 3)
        {
            destMap = GameObject.Find("G_C");
            destination.text = "경기도";
            check = 0; // 출발지와 도착지가 둘다 선택됨
            isStart = false;
        }

    }

    public void GangwonClick()
    {
        if (!isStart)
        {
            destMap = null;
            destination.text = null;
            resourceMap = GameObject.Find("GA_C");
            startingPoint.text = "강원도";
            middle.text = "->";
            check = 4;
            isStart = true;
        }
        else if (isStart && check != 4)
        {
            destMap = GameObject.Find("GA_C");
            destination.text = "강원도";
            check = 0; // 출발지와 도착지가 둘다 선택됨
            isStart = false;
        }
    }

    public void CHBClick()
    {
        if (!isStart)
        {
            destMap = null;
            destination.text = null;
            resourceMap = GameObject.Find("CHB_C");
            startingPoint.text = "충청북도";
            middle.text = "->";
            check = 5;
            isStart = true;
        }
        else if (isStart && check != 5)
        {
            destMap = GameObject.Find("CHB_C");
            destination.text = "충청북도";
            check = 0; // 출발지와 도착지가 둘다 선택됨
            isStart = false;
        }

    }

    public void CHNClick()
    {
        if (!isStart)
        {
            destMap = null;
            destination.text = null;
            resourceMap = GameObject.Find("CHN_C");
            startingPoint.text = "충청남도";
            middle.text = "->";
            check = 6;
            isStart = true;
        }
        else if (isStart && check != 6)
        {
            destMap = GameObject.Find("CHN_C");
            destination.text = "충청남도";
            check = 0; // 출발지와 도착지가 둘다 선택됨
            isStart = false;
        }

    }

    public void DaejeonClick()
    {
        if (!isStart)
        {
            destMap = null;
            destination.text = null;
            resourceMap = GameObject.Find("DAEJEON_C");
            startingPoint.text = "대전";
            middle.text = "->";
            check = 7;
            isStart = true;
        }
        else if (isStart && check != 7)
        {
            destMap = GameObject.Find("DAEJEON_C");
            destination.text = "대전";
            check = 0; // 출발지와 도착지가 둘다 선택됨
            isStart = false;
        }

    }

    public void GBClick()
    {
        if (!isStart)
        {
            destMap = null;
            destination.text = null;
            resourceMap = GameObject.Find("GB_C");
            startingPoint.text = "경상북도";
            middle.text = "->";
            check = 8;
            isStart = true;
        }
        else if (isStart && check != 8)
        {
            destMap = GameObject.Find("GB_C");
            destination.text = "경상북도";
            check = 0; // 출발지와 도착지가 둘다 선택됨
            isStart = false;
        }
    
    }

    public void GNClick()
    {
        if (!isStart)
        {
            destMap = null;
            destination.text = null;
            resourceMap = GameObject.Find("GN_C");
            startingPoint.text = "경상남도";
            middle.text = "->";
            check = 9;
            isStart = true;
        }
        else if (isStart && check != 9)
        {
            destMap = GameObject.Find("GN_C");
            destination.text = "경상남도";
            check = 0; // 출발지와 도착지가 둘다 선택됨
            isStart = false;
        }

    }

    public void DaeguClick()
    {
        if (!isStart)
        {
            destMap = null;
            destination.text = null;
            resourceMap = GameObject.Find("DAEGU_C");
            startingPoint.text = "대구";
            middle.text = "->";
            check = 10;
            isStart = true;
        }
        else if (isStart && check != 10)
        {
            destMap = GameObject.Find("DAEGU_C");
            destination.text = "대구";
            check = 0; // 출발지와 도착지가 둘다 선택됨
            isStart = false;
        }
  
    }

    public void WoolsanClick()
    {
        if (!isStart)
        {
            destMap = null;
            destination.text = null;
            resourceMap = GameObject.Find("WOO_C");
            startingPoint.text = "울산";
            middle.text = "->";
            check = 11;
            isStart = true;
        }
        else if (isStart && check != 11)
        {
            destMap = GameObject.Find("WOO_C");
            destination.text = "울산";
            check = 0; // 출발지와 도착지가 둘다 선택됨
            isStart = false;
        }
  
    }

    public void BusanClick()
    {
        if (!isStart)
        {
            destMap = null;
            destination.text = null;
            resourceMap = GameObject.Find("BU_C");
            startingPoint.text = "부산";
            middle.text = "->";
            check = 12;
            isStart = true;
        }
        else if (isStart && check != 12)
        {
            destMap = GameObject.Find("BU_C");
            destination.text = "부산";
            check = 0; // 출발지와 도착지가 둘다 선택됨
            isStart = false;
        }

    }

    public void JBClick()
    {
        if (!isStart)
        {
            destMap = null;
            destination.text = null;
            resourceMap = GameObject.Find("JB_C");
            startingPoint.text = "전라북도";
            middle.text = "->";
            check = 13;
            isStart = true;
        }
        else if (isStart && check != 13)
        {
            destMap = GameObject.Find("JB_C");
            destination.text = "전라북도";
            check = 0; // 출발지와 도착지가 둘다 선택됨
            isStart = false;
        }
    }

    public void JNClick()
    {
        if (!isStart)
        {
            destMap = null;
            destination.text = null;
            resourceMap = GameObject.Find("JN_C");
            startingPoint.text = "전라남도";
            middle.text = "->";
            check = 14;
            isStart = true;
        }
        else if (isStart && check != 14)
        {
            destMap = GameObject.Find("JN_C");
            destination.text = "전라남도";
            check = 0; // 출발지와 도착지가 둘다 선택됨
            isStart = false;
        }
       
    }

    public void GwangjuClick()
    {
        if (!isStart)
        {
            destMap = null;
            destination.text = null;
            resourceMap = GameObject.Find("GW_C");
            startingPoint.text = "광주";
            middle.text = "->";
            check = 15;
            isStart = true;
        }
        else if (isStart && check != 15)
        {
            destMap = GameObject.Find("GW_C");
            destination.text = "광주";
            check = 0; // 출발지와 도착지가 둘다 선택됨
            isStart = false;
        }
    }

    public void JejuClick()
    {
        if (!isStart)
        {
            destMap = null;
            destination.text = null;
            resourceMap = GameObject.Find("JE_C");
            startingPoint.text = "제주도";
            middle.text = "->";
            check = 16;
            isStart = true;
        }
        else if (isStart && check != 16)
        {
            destMap = GameObject.Find("JE_C");
            destination.text = "제주도";
            check = 0; // 출발지와 도착지가 둘다 선택됨
            isStart = false;
        }
      
    }
    
    public void DokdoClick()
    {
        if (!isStart)
        {
            destMap = null;
            destination.text = null;
            resourceMap = GameObject.Find("Dok_C");
            startingPoint.text = "독도";
            middle.text = "->";
            check = 17;
            isStart = true;
        }
        else if (isStart && check != 17)
        {
            destMap = GameObject.Find("Dok_C");
            destination.text = "독도";
            check = 0; // 출발지와 도착지가 둘다 선택됨
            isStart = false;
        }
       
    }
}
