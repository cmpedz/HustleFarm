using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNftAnimalUserHas : Singleton<GetNftAnimalUserHas>
{
    // Start is called before the first frame update

    private List<int> idNftOwned = new List<int>();
    public List<int> IdNftOwned
    {
        get { return this.idNftOwned; }
    }

    void Start()
    {
          List<int> testIntialAnimalsHas = new List<int>();
        testIntialAnimalsHas.Add(0);
        testIntialAnimalsHas.Add(1);

        foreach(int i in testIntialAnimalsHas)
        {
            idNftOwned.Add(i);
        }

          
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
