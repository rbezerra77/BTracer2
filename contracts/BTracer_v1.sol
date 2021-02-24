//SPDX-License-Identifier: MIT
pragma solidity ^0.7.0;

contract BTracer_v1 {
    
    struct trckr {
        string orderno; 
        string process;
        string operation;
        string production;
        string year;
        string lastsequence;
        string tckr_type;
        string comments;
        string usage;
        string farm;
        string farmer;
        string variety;
        string weather;
        string region;
    }
    
    mapping (string => trckr) private tracker;
    mapping (string => string) trackerCod;

    constructor() {
        string memory _id = "0";
        tracker[_id].orderno = "A2020";
        tracker[_id].process = "Process A";
        tracker[_id].operation = "operation A";
        tracker[_id].production = "production A";
        tracker[_id].year = "2020";
        tracker[_id].lastsequence = "1";
        tracker[_id].tckr_type = "Type";
        tracker[_id].comments = "Comments comes here!";
        tracker[_id].usage = "Usage";
        tracker[_id].farm = "Local Farm";
        tracker[_id].farmer = "Mr. Farmer";
        tracker[_id].variety = "Arabica";
        tracker[_id].weather = "Mist";
        tracker[_id].region = "North";
    }
    
    function addNewTrace_Payload_B(string memory _id, 
                        string memory orderno, 
                        string memory process,
                        string memory operation) public returns (bool _retB) {
            
        tracker[_id].orderno = orderno;
        tracker[_id].process = process;
        tracker[_id].operation = operation;
        
        return true;
    }    
    
    function addNewTrace_Payload_C(string memory _id, 
                        string memory production,
                        string memory year,
                        string memory lastsequence) public returns (bool _retC) {
                            
        tracker[_id].production = production;
        tracker[_id].year = year;
        tracker[_id].lastsequence = lastsequence;
        
        return true;
    }   
    
    function addNewTrace_Payload_D(string memory _id, 
                        string memory tckr_type,
                        string memory comments,
                        string memory usage) public returns (bool _retD) {
                            
        tracker[_id].tckr_type = tckr_type;
        tracker[_id].comments = comments;
        tracker[_id].usage = usage;
        
        return true;
    }
    
    function addNewTrace_Payload_E(string memory _id, 
                        string memory farm,
                        string memory farmer,
                        string memory variety,
                        string memory weather,
                        string memory region) public returns (bool _retE) {
                            
        tracker[_id].farm = farm;
        tracker[_id].farmer = farmer;
        tracker[_id].variety = variety;
        tracker[_id].weather = weather;
        tracker[_id].region = region;
        
        return true;
    }
        
    function getTrace_Payload_B(string memory _id) public view returns ( string memory orderno, 
                                                                    string memory process,
                                                                    string memory operation ) {
            
        return ( tracker[_id].orderno,
                tracker[_id].process,
                tracker[_id].operation );
        
    }    
    
    function getTrace_Payload_C(string memory _id) public view returns ( string memory production,
                                                                    string memory year,
                                                                    string memory lastsequence ) {
        return ( tracker[_id].production,
                tracker[_id].year,
                tracker[_id].lastsequence );

    }   
    
    function getTrace_Payload_D(string memory _id) public view returns ( string memory tckr_type,
                                                                    string memory comments,
                                                                    string memory usage ) {
        return ( tracker[_id].tckr_type,
                tracker[_id].comments,
                tracker[_id].usage );
    }
    
    function getTrace_Payload_E(string memory _id) public view returns ( string memory farm,
                                                                    string memory farmer,
                                                                    string memory variety,
                                                                    string memory weather,
                                                                    string memory region ) {
        return ( tracker[_id].farm,
                tracker[_id].farmer,
                tracker[_id].variety,
                tracker[_id].weather,
                tracker[_id].region );
    }

    function addTraceCod(string memory _id, string memory trace) public returns (bool) {
        require(bytes(_id).length != 0, "Tracker ID must be filled.");
        require(bytes(trace).length != 0, "Trace content (json) must be filled.");

        trackerCod[_id] = trace;

        return true;
    }

    function getTraceCod(string memory _id) public view returns (string memory) {
        require(bytes(_id).length != 0, "Tracker ID must be filled.");
        
        return trackerCod[_id];
    }    
}