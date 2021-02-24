using System;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Contracts;
using System.Text.Json;
using WebAPI.Model;
using WebAPI.Enums;

namespace WebAPI.Factory
{
    class ContractFactory
    {
        private Contract _solContract;
        public Contract SolContract
        {
            get { return _solContract; }
            set { _solContract = value; }
        }

        private Web3 _handleWeb3;
        public Web3 HandleWeb3
        {
            get { return _handleWeb3; }
            set { _handleWeb3 = value; }
        }

        public ContractFactory(Contracts solCont)
        {
            /*
            *** Opening and parsing .secret.json - parse into _secret object
            */
            System.IO.StreamReader sReaderSecret = new System.IO.StreamReader(@"./accounts/.secret.json");
            string jsonSecret = sReaderSecret.ReadToEnd();
            Secret _secret = JsonSerializer.Deserialize<Secret>(jsonSecret);

            /*
            *** Defining correct json to open and get ABI / Also define the Contract object to return
            */
            String fileToParse = String.Empty;
            String contractAddr = String.Empty;
            switch (solCont)
            {
                case Contracts.BTracer:
                    fileToParse = @"../build/contracts/BTracer_V1.json";
                    contractAddr = _secret.Btracer;
                    break;

                case Contracts.Test:
                    fileToParse = @"../build/contracts/ContractData.json";
                    contractAddr = _secret.TestAddr;
                    break;

                default:
                    fileToParse = @"../build/contracts/ContractData.json";
                    contractAddr = _secret.TestAddr;
                    break;
            }

            /*
            *** Opening and finding the ABI value inside contract build json document
            */
            System.IO.StreamReader sReaderContract = new System.IO.StreamReader(fileToParse);
            string jsonContract = sReaderContract.ReadToEnd();
            var jsonDocumentContract = JsonDocument.Parse(jsonContract).RootElement.EnumerateObject();

            string abi = String.Empty;
            foreach (JsonProperty child in jsonDocumentContract)
            {
                if (child.Name.Equals("abi"))
                    abi = child.Value.ToString();
            }

            var url = _secret.SelectedNetURL;
            var privateKey = _secret.OwnerPK;
            var account = new Account(privateKey);
            var web3 = new Web3(account, url);

            // Console.WriteLine("url: " + url);
            // Console.WriteLine("privateKey: " + privateKey);
            // Console.WriteLine("account: " + account.Address.ToString());
            // Console.WriteLine("abi: " + abi);
            // Console.WriteLine("Contract Addr: " + contractAddr);

            _solContract = web3.Eth.GetContract(abi, contractAddr);
            _handleWeb3 = web3;
        }
    }
}