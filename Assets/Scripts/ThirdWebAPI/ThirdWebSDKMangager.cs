using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thirdweb;
using TMPro;
using Thirdweb.Unity;


public class ThirdWebSDKMangager : MonoBehaviour
{
    // Start is called before the first frame update
    private static ThirdWebSDKMangager instance;
    public static ThirdWebSDKMangager Instance {
        get { return instance; }
    }

    [SerializeField] private TextMeshProUGUI userWalletAddress;

    //[SerializeField] private TextMeshProUGUI textTest;


    void Start()
    {
        if (instance == null) { 

            instance = this;

            DontDestroyOnLoad(gameObject);

            ThirdwebManager.Instance.Initialize();

        }
        else
        {
            if (instance != this) {
                Destroy(gameObject);
            }
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void ConnectUserWallet() {

        var options = new WalletOptions(provider: WalletProvider.MetaMaskWallet, chainId: 1);
        


        try
        {

            var wallet = await ThirdwebManager.Instance.ConnectWallet(options);

            if (wallet != null)
            {
                string walletAddress = await wallet.GetAddress();

                userWalletAddress.text = walletAddress;

                //textTest.text = "welcome user";
            }
            else
            {
               // textTest.text = "wallet is null";
            }

            

        } catch (System.Exception e){
            //textTest.text = "error when connect with user wallet : " + e.StackTrace;
        }
        finally{
            //textTest.gameObject.SetActive(true);
        }
       
          

    }
}
