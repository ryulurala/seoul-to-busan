using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonManager : MonoBehaviour
{
    [SerializeField]
    GameObject personNumber = null;

    [SerializeField]
    GameObject personNumberPrefab = null;

    [SerializeField]
    GameObject Character = null;

    public Text startingPoint;
    public Text middle;
    public Text destination;

    [HideInInspector]
    public GameObject resourceMap = null;
    [HideInInspector]
    public GameObject destMap = null;

    Camera mCamera;

    public int check = -1;
    private bool isStart = false;
    private bool isDestroy = false;
    private bool isClear = false;

    // 생길 때도 한꺼번에, 지울 때도 한꺼번에
    public List<GameObject> persons = new List<GameObject>(); // person
    public List<string> rMap = new List<string>();
    public List<string> dMap = new List<string>();

    public List<GameObject> mNumberList = new List<GameObject>(); // bar
    public List<Transform> personTransform = new List<Transform>(); // persons의 transform

    private GameObject pivot;

    void Start()
    {
        mCamera = Camera.main;
        pivot = GameObject.FindGameObjectWithTag("Pivot");
    }

    // Update is called once per frame
    void Update()
    {
        //둘다 선택 되었을 때
        if (check == 0) // 0
        {
            rMap.Add(startingPoint.text);
            dMap.Add(destination.text);

            for(int i=1; i<5; i++)
            {
                pivot.GetComponent<CameraSwitch>().buttons[i].GetComponent<Animator>().SetBool("ClickBling", false);
            }

            pivot.GetComponent<CameraSwitch>().buttons[0].GetComponent<Animator>().SetBool("ClickBling", true);

            persons.Add(Instantiate(Character, resourceMap.transform.position, Quaternion.identity, transform));
            check = -1;

            personTransform.Add(persons[persons.Count-1].transform); // 캐릭터 위치 저장
            mCamera.GetComponent<CharacterCamera>().CharacterTransform = personTransform[personTransform.Count-1]; // 캐릭터 카메라 선택

            GameObject bar = Instantiate(personNumberPrefab, personTransform[personTransform.Count - 1].position, Quaternion.identity, personNumber.transform);

            int cavePopulDivide = resourceMap.GetComponent<CaveDefault>().population/2;

            bar.GetComponent<Text>().text = cavePopulDivide.ToString();
            resourceMap.GetComponent<CaveDefault>().population -= cavePopulDivide; // resourceMap에 차감

            mNumberList.Add(bar); // bar 추가

            // 초기화
            resourceMap = null;

            // Text 초기화
            if (!isClear)
            {
                StartCoroutine("ClearText");
            }
        }

        for (int i = 0; i < personTransform.Count; i++)
        {
            mNumberList[i].transform.position = mCamera.WorldToScreenPoint(personTransform[i].position + new Vector3(0, 0.6f, 0));
        }

        
        // Destroy Coroutine 실행
        if (!isDestroy)
        {
            // 3초후 Destroy
            if (persons.Count > 0)
            {
                StartCoroutine("DestroyCharacter");
            }
        }

    }

    // 중앙상단에 Text 초기화
    IEnumerator ClearText()
    {
        isClear = true;
        
        yield return new WaitForSeconds(2f);
        if (resourceMap == null)
        {
            startingPoint.text = null;
            middle.text = null;
            destination.text = null;
        }
        isClear = false;
    }

    // 일정 시간 후 resource, dest UI clear 및 Destroy Character
    IEnumerator DestroyCharacter()
    {
        isDestroy = true;
        Debug.Log("DestroyCharacter Coroutine");
        for (int i = 0; i < persons.Count; i++)
        {
            if (!persons[i].GetComponent<ClickToMove>().mRunning)
            {
                yield return new WaitForSeconds(3f);
                break;
            }
        }

        /////////3초 후 일어날 일 Destroy(person), Destroy(personTransform), Destroy(mNumberList)
        for (int i=0; i<persons.Count; i++)
        {
            if (!persons[i].GetComponent<ClickToMove>().mRunning)
            {
                GameObject destTemp = persons[i].GetComponent<ClickToMove>().destination;

                Camera.main.GetComponent<CharacterCamera>().CharacterTransform = destTemp.transform; // 소멸된 Cave를 바라보게 함

                destTemp.GetComponent<CaveDefault>().population += int.Parse(mNumberList[i].GetComponent<Text>().text); // 목적지에 인구 수 추가
                
                // Destroy
                Destroy(mNumberList[i]);
                Destroy(persons[i]);
                Destroy(personTransform[i]);
                persons.RemoveAt(i);
                mNumberList.RemoveAt(i);
                personTransform.RemoveAt(i);

                // Map name destroy
                rMap.RemoveAt(i);
                dMap.RemoveAt(i);
            }
        }

        isDestroy = false;
    }

    public void SeoulClick()
    {
        if (!isStart)
        {
            destMap = null;
            destination.text = null;
            resourceMap = GameObject.Find("S_C");
            if (resourceMap.GetComponent<CaveDefault>().population > 0)
            {
                startingPoint.text = "서울";
                middle.text = "->";
                check = 1;
                isStart = true;
            }
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
            if (resourceMap.GetComponent<CaveDefault>().population > 0)
            {
                startingPoint.text = "인천";
                middle.text = "->";
                check = 2;
                isStart = true;
            }
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
            if (resourceMap.GetComponent<CaveDefault>().population > 0)
            {
                startingPoint.text = "경기도";
                middle.text = "->";
                check = 3;
                isStart = true;
            }
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
            if (resourceMap.GetComponent<CaveDefault>().population > 0)
            {
                startingPoint.text = "강원도";
                middle.text = "->";
                check = 4;
                isStart = true;
            }
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
            if (resourceMap.GetComponent<CaveDefault>().population > 0)
            {
                startingPoint.text = "충청북도";
                middle.text = "->";
                check = 5;
                isStart = true;
            }
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
            if (resourceMap.GetComponent<CaveDefault>().population > 0)
            {
                startingPoint.text = "충청남도";
                middle.text = "->";
                check = 6;
                isStart = true;
            }
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
            if (resourceMap.GetComponent<CaveDefault>().population > 0)
            {
                startingPoint.text = "대전";
                middle.text = "->";
                check = 7;
                isStart = true;
            }
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
            if (resourceMap.GetComponent<CaveDefault>().population > 0)
            {
                startingPoint.text = "경상북도";
                middle.text = "->";
                check = 8;
                isStart = true;
            }
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
            if (resourceMap.GetComponent<CaveDefault>().population > 0)
            {
                startingPoint.text = "경상남도";
                middle.text = "->";
                check = 9;
                isStart = true;
            }
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
            if (resourceMap.GetComponent<CaveDefault>().population > 0)
            {
                startingPoint.text = "대구";
                middle.text = "->";
                check = 10;
                isStart = true;
            }
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
            if (resourceMap.GetComponent<CaveDefault>().population > 0)
            {
                startingPoint.text = "울산";
                middle.text = "->";
                check = 11;
                isStart = true;
            }
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
            if (resourceMap.GetComponent<CaveDefault>().population > 0)
            {
                startingPoint.text = "부산";
                middle.text = "->";
                check = 12;
                isStart = true;
            }
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
            if (resourceMap.GetComponent<CaveDefault>().population > 0)
            {
                startingPoint.text = "전라북도";
                middle.text = "->";
                check = 13;
                isStart = true;
            }
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
            if (resourceMap.GetComponent<CaveDefault>().population > 0)
            {
                startingPoint.text = "전라남도";
                middle.text = "->";
                check = 14;
                isStart = true;
            }
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
            if (resourceMap.GetComponent<CaveDefault>().population > 0)
            {
                startingPoint.text = "광주";
                middle.text = "->";
                check = 15;
                isStart = true;
            }
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
            if (resourceMap.GetComponent<CaveDefault>().population > 0)
            {
                startingPoint.text = "제주도";
                middle.text = "->";
                check = 16;
                isStart = true;
            }
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
            if (resourceMap.GetComponent<CaveDefault>().population > 0)
            {
                startingPoint.text = "독도";
                middle.text = "->";
                check = 17;
                isStart = true;
            }
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
