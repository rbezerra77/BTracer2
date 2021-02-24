using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;
using WebAPI.EthereumServices;
using System.Collections.Generic;
using WebAPI.Utils;
using System.Text.Json;

namespace WebNethereum.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BTracerController : ControllerBase
    {
        private IBTracerService service;
        public BTracerController(IBTracerService BTracerService)
        {
            service = BTracerService;
        }

        /// <summary>
        /// set-trace Route: Add new tracer to Blockchain.
        /// </summary>
        /// <param name="_bTraceModel">Tracer Structure[BTracerModel] as parameter</param>
        /// <returns>EthReturn Structure containing 03 Hashes related to posts into blockchain</returns>
        [HttpPost]
        [Route("set-trace")]
        public async Task<EthReturnFull> PostSetTraceAsync(BTracerModel _bTraceModel)
        {
            var txHash_B = await service.addNewTrace_Payload_B(_bTraceModel.id, _bTraceModel.orderno, _bTraceModel.process, _bTraceModel.operation);
            var txHash_C = await service.addNewTrace_Payload_C(_bTraceModel.id, _bTraceModel.production, _bTraceModel.year, _bTraceModel.lastsequence);
            var txHash_D = await service.addNewTrace_Payload_D(_bTraceModel.id, _bTraceModel.tckr_type, _bTraceModel.comments, _bTraceModel.usage);
            var txHash_E = await service.addNewTrace_Payload_E(_bTraceModel.id, _bTraceModel.farm, _bTraceModel.farmer, _bTraceModel.variety, _bTraceModel.weather, _bTraceModel.region);

            return new EthReturnFull
            {
                TxHashB = txHash_B.TxHash,
                TxHashC = txHash_C.TxHash,
                TxHashD = txHash_D.TxHash,
                TxHashE = txHash_E.TxHash,
                Message = "Ok, Incluso com sucesso!",
                Success = true
            };
        }

        /// <summary>
        /// get-trace Route: Returns tracer when an ID is given
        /// </summary>
        /// <param name="id">Tracer identification for tracker beans partners</param>
        /// <returns>Json with tracker Data</returns>
        [HttpGet]
        [Route("get-trace/{id}")]
        public async Task<BTracerModel> getTrace_Payload_B([FromRoute] String id)
        {
            BTracerModelB BTracerB = await service.getTrace_Payload_B(id);
            BTracerModelC BTracerC = await service.getTrace_Payload_C(id);
            BTracerModelD BTracerD = await service.getTrace_Payload_D(id);
            BTracerModelE BTracerE = await service.getTrace_Payload_E(id);

            return new BTracerModel
            {
                orderno = BTracerB.orderno,
                process = BTracerB.process,
                operation = BTracerB.operation,
                production = BTracerC.production,
                year = BTracerC.year,
                lastsequence = BTracerC.lastsequence,
                tckr_type = BTracerD.tckr_type,
                comments = BTracerD.comments,
                usage = BTracerD.usage,
                farm = BTracerE.farm,
                farmer = BTracerE.farmer,
                variety = BTracerE.variety,
                weather = BTracerE.weather,
                region = BTracerE.region
            };
        }

        /// <summary>
        /// get-trace Route: Returns tracer when an ID is given
        /// </summary>
        /// <param name="id">Tracer identification for tracker beans partners</param>
        /// <returns>Json with tracker Data</returns>
        [HttpGet]
        [Route("get-tx/{id}")]
        public async Task<String> getTransactionData([FromRoute] String id)
        {
            var ret = await service.getTxInfo(id);
            return ret;
        }

        /// <summary>
        /// get-trace Route: Returns tracer when an ID is given
        /// </summary>
        /// <param name="id">Tracer identification for tracker beans partners</param>
        /// <returns>Json with tracker Data</returns>
        [HttpGet]
        [Route("get-token-data/{tokenaddr}")]
        public async Task<List<String>> getTokenData([FromRoute] String tokenaddr)
        {
            var ret = await service.getTokenData(tokenaddr);
            return ret;
        }

        /// <summary>
        /// set-trace Route: Add new tracer to Blockchain.
        /// </summary>
        /// <param name="_bTraceModel">Tracer Structure[BTracerModel] as parameter</param>
        /// <returns>EthReturn Structure containing 03 Hashes related to posts into blockchain</returns>
        [HttpPost]
        [Route("set-traceCod")]
        public async Task<EthReturn> PostSetTraceCodAsync(BTracerModel _bTraceModel)
        {
            String originalString = JsonSerializer.Serialize<BTracerModel>(_bTraceModel);
            String trackerID = _bTraceModel.id;

            var jsonCod = Utils.CompressJson(originalString);
            return await service.addNewTraceCod(trackerID, jsonCod);
        }

        /// <summary>
        /// Add new trace
        /// </summary>
        /// <param name="trackerID">Tracker Structure as parameter</param>
        /// <returns>EthReturn Structure</returns>
        [HttpGet]
        [Route("get-traceCod/{trackerID}")]
        public async Task<String> GetTraceCodAsync([FromRoute] String trackerID)
        {
            String compressedString = await service.getTraceCod(trackerID);
            Console.WriteLine(compressedString);

            return Utils.UncompressJson(compressedString);
        }        
    }
}