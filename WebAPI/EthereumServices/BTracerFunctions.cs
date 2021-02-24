using Nethereum.Contracts;
using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Numerics;

namespace WebAPI.EthereumServices
{
    [Function("addNewTrace_Payload_B", "bool")]
    public class addNewTrace_Payload_B : FunctionMessage
    {
        // function addNewTrace_Payload_B(string memory _id, 
        //             string memory orderno, 
        //             string memory process,
        //             string memory operation) public returns (bool _retB) {
        [Parameter("string", "_id", 1)]
        public string _id { get; set; }

        [Parameter("string", "orderno", 2)]
        public string orderno { get; set; }

        [Parameter("string", "process", 3)]
        public string process { get; set; }

        [Parameter("string", "operation", 4)]
        public string operation { get; set; }
    }

    // function addNewTrace_Payload_C(string memory _id, 
    // string memory production,
    // string memory year,
    // string memory lastsequence) public returns (bool _retC) {

    [Function("addNewTrace_Payload_C", "bool")]
    public class addNewTrace_Payload_C : FunctionMessage
    {
        [Parameter("string", "_id", 1)]
        public string _id { get; set; }

        [Parameter("string", "production", 2)]
        public string production { get; set; }

        [Parameter("string", "year", 3)]
        public string year { get; set; }

        [Parameter("string", "lastsequence", 4)]
        public string lastsequence { get; set; }
    }

    // function addNewTrace_Payload_D(string memory _id, 
    // string memory tckr_type,
    // string memory comments,
    // string memory usage) public returns (bool _retD) {
    [Function("addNewTrace_Payload_D", "bool")]
    public class addNewTrace_Payload_D : FunctionMessage
    {
        [Parameter("string", "_id", 1)]
        public string _id { get; set; }

        [Parameter("string", "tckr_type", 2)]
        public string tckr_type { get; set; }

        [Parameter("string", "comments", 3)]
        public string comments { get; set; }

        [Parameter("string", "usage", 4)]
        public string usage { get; set; }
    }

    // function addNewTrace_Payload_E(string memory _id, 
    // string memory farm,
    // string memory farmer,
    // string memory variety,
    // string memory weather,
    // string memory region) public returns (bool _retE) {
    [Function("addNewTrace_Payload_E", "bool")]
    public class addNewTrace_Payload_E : FunctionMessage
    {
        [Parameter("string", "_id", 1)]
        public string _id { get; set; }

        [Parameter("string", "farm", 2)]
        public string farm { get; set; }

        [Parameter("string", "farmer", 3)]
        public string farmer { get; set; }

        [Parameter("string", "variety", 4)]
        public string variety { get; set; }

        [Parameter("string", "weather", 4)]
        public string weather { get; set; }

        [Parameter("string", "region", 4)]
        public string region { get; set; }
    }

    // // function setTrace(string memory _id, trckr memory _InTrace) public returns (bool _retTraceFull){
    // [Function("setTrace", "bool")]
    // public class setTrace : FunctionMessage
    // {
    //     [Parameter("string", "_id", 1)]
    //     public string _id { get; set; }

    //     [Parameter("struct", "_InTrace", 2)]
    //     public string _InTrace { get; set; }
    // }

    // // function getTrace(string memory _id) public view returns (trckr memory _retTrace){
    // [Function("getTrace", "struct")]
    // public class getTrace : FunctionMessage
    // {
    //     [Parameter("string", "_id", 1)]
    //     public string _id { get; set; }
    // }

    [FunctionOutput]
    public class OutPut_Trace_Payload_B : IFunctionOutputDTO
    {
        [Parameter("string", "orderno", 1)]
        public String orderno { get; set; }

        [Parameter("string", "process", 2)]
        public String process { get; set; }

        [Parameter("string", "operation", 3)]
        public String operation { get; set; }
    }

    [FunctionOutput]
    public class OutPut_Trace_Payload_C : IFunctionOutputDTO
    {
        [Parameter("string", "production", 1)]
        public String production { get; set; }

        [Parameter("string", "year", 2)]
        public String year { get; set; }

        [Parameter("string", "lastsequence", 3)]
        public String lastsequence { get; set; }
    }

    [FunctionOutput]
    public class OutPut_Trace_Payload_D : IFunctionOutputDTO
    {
        [Parameter("string", "tckr_type", 1)]
        public String tckr_type { get; set; }

        [Parameter("string", "comments", 2)]
        public String comments { get; set; }

        [Parameter("string", "usage", 3)]
        public String usage { get; set; }
    }

    [FunctionOutput]
    public class OutPut_Trace_Payload_E : IFunctionOutputDTO
    {
        [Parameter("string", "farm", 1)]
        public String farm { get; set; }

        [Parameter("string", "farmer", 2)]
        public String farmer { get; set; }

        [Parameter("string", "variety", 3)]
        public String variety { get; set; }

        [Parameter("string", "weather", 4)]
        public String weather { get; set; }

        [Parameter("string", "region", 5)]
        public String region { get; set; }
    }

    [FunctionOutput]
    public class Output_TokenDetails : IFunctionOutputDTO
    {
        [Parameter("string", "_name", 1)]
        public String Name { get; set; }

        [Parameter("string", "_symbol", 2)]
        public String Symbol { get; set; }

        [Parameter("uint", "_decimals", 3)]
        public int Decimals { get; set; }
    }

    [Function("addTraceCod", "bool")]
    public class addTraceCodFunction : FunctionMessage
    {
        [Parameter("string", "_id", 1)]
        public string TrackerId { get; set; }

        [Parameter("string", "trace", 2)]
        public string TrackerCod { get; set; }        
    }    
}