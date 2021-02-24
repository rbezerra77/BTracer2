using System.Threading.Tasks;
using WebAPI.Factory;
using WebAPI.Enums;
using WebAPI.Model;
using Nethereum.Web3;
using Nethereum.Contracts;
using System;
using System.Numerics;
using WebAPI.Utils;
using System.Collections.Generic;

namespace WebAPI.EthereumServices
{
    class BTracerService : IBTracerService
    {
        private Contract contract;
        private ContractFactory _cf;
        private Web3 handleWeb3;

        private Contract contractTokenDetails;
        private ContractFactory _cfTokenDetails;
        private Web3 handleWeb3TokenDetails;
        public BTracerService()
        {
            _cf = new ContractFactory(Contracts.BTracer);
            contract = _cf.SolContract;
            handleWeb3 = _cf.HandleWeb3;

            _cfTokenDetails = new ContractFactory(Contracts.Test);
            contractTokenDetails = _cfTokenDetails.SolContract;
            handleWeb3TokenDetails = _cfTokenDetails.HandleWeb3;            
        }

        public async Task<EthReturn> addNewTrace_Payload_B(string _tracerId, string orderno, string process, string operation)
        {
            var addNewTrace_Payload_B = handleWeb3.Eth.GetContractTransactionHandler<addNewTrace_Payload_B>();
            var _ret = new EthReturn();

            try
            {

                var payloadB = new addNewTrace_Payload_B()
                {
                    _id = _tracerId,
                    orderno = orderno,
                    process = process,
                    operation = operation
                };

                var transactionHash = await addNewTrace_Payload_B.SendRequestAsync(contract.Address, payloadB);

                _ret.Message = "Ok!";
                _ret.TxHash = transactionHash;
                _ret.Success = true;

            }
            catch (System.Exception ex)
            {
                _ret.Message = ex.Message + "\n *** Try to provide a valid Ethereum wallet address *** ";
                _ret.TxHash = "";
                _ret.Success = false;
            }

            return _ret;
        }

        public async Task<EthReturn> addNewTrace_Payload_C(string _tracerId, string production, string year, string lastsequence)
        {
            var addNewTrace_Payload_C = handleWeb3.Eth.GetContractTransactionHandler<addNewTrace_Payload_C>();
            var _ret = new EthReturn();

            try
            {

                var payloadC = new addNewTrace_Payload_C()
                {
                    _id = _tracerId,
                    production = production,
                    year = year,
                    lastsequence = lastsequence
                };

                var transactionHash = await addNewTrace_Payload_C.SendRequestAsync(contract.Address, payloadC);

                _ret.Message = "Ok!";
                _ret.TxHash = transactionHash;
                _ret.Success = true;

            }
            catch (System.Exception ex)
            {
                _ret.Message = ex.Message + "\n *** Try to provide a valid Ethereum wallet address *** ";
                _ret.TxHash = "";
                _ret.Success = false;
            }

            return _ret;
        }

        public async Task<EthReturn> addNewTrace_Payload_D(string _tracerId, string tckr_type, string comments, string usage)
        {
            var addNewTrace_Payload_D = handleWeb3.Eth.GetContractTransactionHandler<addNewTrace_Payload_D>();
            var _ret = new EthReturn();

            try
            {

                var payloadD = new addNewTrace_Payload_D()
                {
                    _id = _tracerId,
                    tckr_type = tckr_type,
                    comments = comments,
                    usage = usage
                };

                var transactionHash = await addNewTrace_Payload_D.SendRequestAsync(contract.Address, payloadD);

                _ret.Message = "Ok!";
                _ret.TxHash = transactionHash;
                _ret.Success = true;

            }
            catch (System.Exception ex)
            {
                _ret.Message = ex.Message + "\n *** Try to provide a valid Ethereum wallet address *** ";
                _ret.TxHash = "";
                _ret.Success = false;
            }

            return _ret;
        }

        public async Task<EthReturn> addNewTrace_Payload_E(string _tracerId, string farm, string farmer, string variety, string weather, string region)
        {
            var addNewTrace_Payload_E = handleWeb3.Eth.GetContractTransactionHandler<addNewTrace_Payload_E>();
            var _ret = new EthReturn();

            try
            {

                var payloadE = new addNewTrace_Payload_E()
                {
                    _id = _tracerId,
                    farm = farm,
                    farmer = farmer,
                    variety = variety,
                    weather = weather,
                    region = region
                };

                var transactionHash = await addNewTrace_Payload_E.SendRequestAsync(contract.Address, payloadE);

                _ret.Message = "Ok!";
                _ret.TxHash = transactionHash;
                _ret.Success = true;

            }
            catch (System.Exception ex)
            {
                _ret.Message = ex.Message + "\n *** Try to provide a valid Ethereum wallet address *** ";
                _ret.TxHash = "";
                _ret.Success = false;
            }

            return _ret;
        }

        public async Task<BTracerModelB> getTrace_Payload_B(string _tracerId)
        {
            OutPut_Trace_Payload_B modB;

            try
            {
                var payLoadBFunction = contract.GetFunction("getTrace_Payload_B");
                modB = await payLoadBFunction.CallDeserializingToObjectAsync<OutPut_Trace_Payload_B>(_tracerId);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new BTracerModelB
            {
                orderno = modB.orderno,
                process = modB.process,
                operation = modB.operation
            };
        }

        public async Task<BTracerModelC> getTrace_Payload_C(string _tracerId)
        {
            OutPut_Trace_Payload_C modC;

            try
            {
                var payLoadCFunction = contract.GetFunction("getTrace_Payload_C");
                modC = await payLoadCFunction.CallDeserializingToObjectAsync<OutPut_Trace_Payload_C>(_tracerId);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new BTracerModelC
            {
                production = modC.production,
                year = modC.year,
                lastsequence = modC.lastsequence
            };
        }

        public async Task<BTracerModelD> getTrace_Payload_D(string _tracerId)
        {
            OutPut_Trace_Payload_D modD;

            try
            {
                var payLoadDFunction = contract.GetFunction("getTrace_Payload_D");
                modD = await payLoadDFunction.CallDeserializingToObjectAsync<OutPut_Trace_Payload_D>(_tracerId);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new BTracerModelD
            {
                tckr_type = modD.tckr_type,
                comments = modD.comments,
                usage = modD.usage
            };
        }

        public async Task<BTracerModelE> getTrace_Payload_E(string _tracerId)
        {
            OutPut_Trace_Payload_E modE;

            try
            {
                var payLoadEFunction = contract.GetFunction("getTrace_Payload_E");
                modE = await payLoadEFunction.CallDeserializingToObjectAsync<OutPut_Trace_Payload_E>(_tracerId);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new BTracerModelE
            {
                farm = modE.farm,
                farmer = modE.farmer,
                variety = modE.variety,
                weather = modE.weather,
                region = modE.region
            };
        }

        public async Task<String> getTxInfo(String tx)
        {
            String addrFrom = String.Empty;
            String addrTo = String.Empty;
            String action = String.Empty;
            String txValue = String.Empty;
            String where = String.Empty;
            //Connecting to Ethereum mainnet using Infura
            var web3 = handleWeb3; // new Web3("https://mainnet.infura.io/v3/7238211010344719ad14a89db874158c");

            //Getting current block number  
            var blockNumber = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
            Console.WriteLine("========================================================================");
            Console.WriteLine("========================================================================");
            Console.WriteLine("Current BlockNumber is: " + blockNumber.Value);

            //Getting current block with transactions 
            // var block = await web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(new HexBigInteger(8257129));
            // Console.WriteLine("Block number: " + block.Number.Value);
            // Console.WriteLine("Block hash: " + block.BlockHash);
            // Console.WriteLine("Block no of transactions:" + block.Transactions.Length);
            // Console.WriteLine("Block transaction 0 From:" + block.Transactions[0].From);
            // Console.WriteLine("Block transaction 0 To:" + block.Transactions[0].To);
            // Console.WriteLine("Block transaction 0 Amount:" + block.Transactions[0].Value);
            // Console.WriteLine("Block transaction 0 Hash:" + block.Transactions[0].TransactionHash);

            // var transaction =
            //     await web3.Eth.Transactions.GetTransactionByHash.SendRequestAsync("0xb4729a0d8dd30e3070d0cb203090f2b792e029f6fa4629e96d2ebc1de13cb5c4");
            var transaction =
                await web3.Eth.Transactions.GetTransactionByHash.SendRequestAsync(tx);            
            Console.WriteLine("Transaction From:" + transaction.From);
            Console.WriteLine("Transaction To:" + transaction.To);
            Console.WriteLine("Transaction Amount:" + transaction.Value);
            Console.WriteLine("Transaction Hash:" + transaction.TransactionHash);

            Console.WriteLine("Transaction Blockhash:" + transaction.BlockHash);
            Console.WriteLine("Transaction BlockNumber:" + transaction.BlockNumber);
            Console.WriteLine("Transaction Gas:" + transaction.Gas);
            Console.WriteLine("Transaction GasPrice:" + transaction.GasPrice);
            Console.WriteLine("Transaction Input:" + transaction.Input);
            Console.WriteLine("Transaction Nonce:" + transaction.Nonce);

            Console.WriteLine("Transaction R:" + transaction.R);
            Console.WriteLine("Transaction S:" + transaction.S);
            Console.WriteLine("Transaction V:" + transaction.V);
            Console.WriteLine("Transaction TransactionIndex:" + transaction.TransactionIndex);

            var transactionReceipt =
                await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(tx);
            Console.WriteLine("Transaction Hash:" + transactionReceipt.TransactionHash);
            Console.WriteLine("TransactionReceipt Logs Count:" + transactionReceipt.Logs.Count);

            var logList = transactionReceipt.Logs;
            foreach (var item in logList)
            {
                Console.WriteLine("========================================================================");
                Console.WriteLine("TransactionReceipt Logs:" + item);
            }
            
            Console.WriteLine("TransactionReceiptContractAddress:" + transactionReceipt.ContractAddress);
            addrFrom = transaction.From;
            addrTo = transaction.To;
            txValue = transaction.Value.ToString();
            // String addrTo;
            // String action;
            // String Value;
            // String where;
            String fullPhrase = "[" + addrFrom + "] [" + action + "] [" + txValue + "] [" + addrTo + "] [" + where + "]";

            Console.WriteLine("Full text: " + fullPhrase);

            return fullPhrase;
        }

        public async Task<List<String>> getTokenData(String tokenAddr)
        {
            List<String> ret = new List<string>();

            try
            {
                var tokenData = contractTokenDetails.GetFunction("getDetails");
                Output_TokenDetails tokenReturn = await tokenData.CallDeserializingToObjectAsync<Output_TokenDetails>(tokenAddr);

                ret.Add("Name: " + tokenReturn.Name);
                ret.Add("Symbol: " + tokenReturn.Symbol);
                ret.Add("Decimals: " + tokenReturn.Decimals.ToString());
            }
            catch (Exception ex)
            {
                ret.Add("TOKEN NOT FOUND(try a different network) or THIS ADDRESS DOES NOT BELONGS TO A TOKEN.");
                ret.Add(ex.Message);
            }

            return ret;
        }

        public async Task<String> getTraceCod(String trackerID)
        {
            var getTraceCodFunction = contract.GetFunction("getTraceCod");
            var jsonCod = await getTraceCodFunction.CallAsync<String>(trackerID);
            
            return jsonCod;
        }
        public async Task<EthReturn> addNewTraceCod(String trackerID, string jsonCod)
        {
            var addTraceCodHandler = handleWeb3.Eth.GetContractTransactionHandler<addTraceCodFunction>();
            var _ret = new EthReturn();

            try
            {
                var addTraceCodRef = new addTraceCodFunction()
                {
                    TrackerId = trackerID,
                    TrackerCod = jsonCod
                };

                var transactionHash = await addTraceCodHandler.SendRequestAsync(contract.Address, addTraceCodRef);

                _ret.Message = "Ok! (Codifyed Json added)";
                _ret.TxHash = transactionHash;
                _ret.Success = true;

            }
            catch (System.Exception ex)
            {
                _ret.Message = ex.Message + "\n *** Something went wrong. Please verify your network. *** ";
                _ret.TxHash = "";
                _ret.Success = false;
            }

            return _ret;
        }       

    }
}