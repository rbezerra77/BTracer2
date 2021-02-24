const bTracer_v1 = artifacts.require("BTracer_v1");
const contractData = artifacts.require("ContractData");

module.exports = (deployer) => {
  deployer.deploy(bTracer_v1);
  // deployer.deploy(contractData);
  // deployer.deploy(bTracer_v1, {overwrite: false});
  deployer.deploy(contractData, {overwrite: false});
};
