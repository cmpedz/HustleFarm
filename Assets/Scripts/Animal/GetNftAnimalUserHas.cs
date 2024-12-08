using Newtonsoft.Json;
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

    [SerializeField] private UserWalletController userWallet;

    async void Start()
    {
            List<int> nftAnimalsUserOwned = await userWallet.GetNftOwn();

            Debug.Log("Check nft own : " + JsonConvert.SerializeObject(nftAnimalsUserOwned));
        
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
