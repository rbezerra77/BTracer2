//SPDX-License-Identifier: MIT
pragma solidity ^0.7.0;

abstract contract ERC20Basic {
   function name() virtual public view returns (string memory);
   function symbol() virtual public view returns (string memory);
   function decimals() virtual public view returns (uint8);
}