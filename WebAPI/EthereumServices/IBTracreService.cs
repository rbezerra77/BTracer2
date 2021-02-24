using System.Threading.Tasks;
using WebAPI.Model;
using System;
using System.Numerics;
using System.Collections.Generic;

namespace WebAPI.EthereumServices
{
    public interface IBTracerService
    {
        Task<EthReturn> addNewTrace_Payload_B(String _tracerId, String orderno, String process, String operation);
        Task<EthReturn> addNewTrace_Payload_C(String _tracerId, String production, String year, String lastsequence);
        Task<EthReturn> addNewTrace_Payload_D(String _tracerId, String tckr_type, String comments, String usage);
        Task<EthReturn> addNewTrace_Payload_E(String _tracerId, string farm, String farmer, String variety, String weather, String region);

        Task<BTracerModelB> getTrace_Payload_B(String _tracerId);
        Task<BTracerModelC> getTrace_Payload_C(String _tracerId);
        Task<BTracerModelD> getTrace_Payload_D(String _tracerId);
        Task<BTracerModelE> getTrace_Payload_E(String _tracerId);
        Task<String> getTxInfo(String tx);
        Task<List<String>> getTokenData(String tokenAddr);
        Task<String> getTraceCod(String trackerID);
        Task<EthReturn> addNewTraceCod(String trackerID, string jsonCod);
    }

}