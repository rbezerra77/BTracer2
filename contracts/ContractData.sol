//SPDX-License-Identifier: MIT
pragma solidity ^0.7.0;

import './ERC20Basic.sol';

contract ContractData {

    function getDetails(address tokenAddress) public view returns (string memory _name, string memory _symbol, uint _decimals){

        ERC20Basic token = ERC20Basic(tokenAddress);
        string memory name = token.name();
        string memory symbol = token.symbol();
        uint decimals = token.decimals();

        return (name, symbol, decimals);
    }
}