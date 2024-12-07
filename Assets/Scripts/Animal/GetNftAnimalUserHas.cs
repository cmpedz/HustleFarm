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
          List<int> nftAnimalsUserOwned = new List<int>();

          for(int i = 0; i < 8; i++)
           {
            nftAnimalsUserOwned.Add(i);
            
          }
       

        foreach(int i in nftAnimalsUserOwned)
        {
            idNftOwned.Add(i);
        }

          
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
