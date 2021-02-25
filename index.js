require('dotenv/config')
const express = require('express');
const { resourceUsage } = require('process')
const Web3 = require('web3')
const web3 = new Web3('https://ropsten.infura.io/v3/8c6d2c33a9744049837aaaf0b2d8276f')

var Tx = require('ethereumjs-tx').Transaction
const contractABI = [
  {
    "inputs": [],
    "stateMutability": "nonpayable",
    "type": "constructor"
  },
  {
    "inputs": [
      {
        "internalType": "string",
        "name": "_id",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "orderno",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "process",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "operation",
        "type": "string"
      }
    ],
    "name": "addNewTrace_Payload_B",
    "outputs": [
      {
        "internalType": "bool",
        "name": "_retB",
        "type": "bool"
      }
    ],
    "stateMutability": "nonpayable",
    "type": "function"
  },
  {
    "inputs": [
      {
        "internalType": "string",
        "name": "_id",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "production",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "year",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "lastsequence",
        "type": "string"
      }
    ],
    "name": "addNewTrace_Payload_C",
    "outputs": [
      {
        "internalType": "bool",
        "name": "_retC",
        "type": "bool"
      }
    ],
    "stateMutability": "nonpayable",
    "type": "function"
  },
  {
    "inputs": [
      {
        "internalType": "string",
        "name": "_id",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "tckr_type",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "comments",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "usage",
        "type": "string"
      }
    ],
    "name": "addNewTrace_Payload_D",
    "outputs": [
      {
        "internalType": "bool",
        "name": "_retD",
        "type": "bool"
      }
    ],
    "stateMutability": "nonpayable",
    "type": "function"
  },
  {
    "inputs": [
      {
        "internalType": "string",
        "name": "_id",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "farm",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "farmer",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "variety",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "weather",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "region",
        "type": "string"
      }
    ],
    "name": "addNewTrace_Payload_E",
    "outputs": [
      {
        "internalType": "bool",
        "name": "_retE",
        "type": "bool"
      }
    ],
    "stateMutability": "nonpayable",
    "type": "function"
  },
  {
    "inputs": [
      {
        "internalType": "string",
        "name": "_id",
        "type": "string"
      }
    ],
    "name": "getTrace_Payload_B",
    "outputs": [
      {
        "internalType": "string",
        "name": "orderno",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "process",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "operation",
        "type": "string"
      }
    ],
    "stateMutability": "view",
    "type": "function",
    "constant": true
  },
  {
    "inputs": [
      {
        "internalType": "string",
        "name": "_id",
        "type": "string"
      }
    ],
    "name": "getTrace_Payload_C",
    "outputs": [
      {
        "internalType": "string",
        "name": "production",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "year",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "lastsequence",
        "type": "string"
      }
    ],
    "stateMutability": "view",
    "type": "function",
    "constant": true
  },
  {
    "inputs": [
      {
        "internalType": "string",
        "name": "_id",
        "type": "string"
      }
    ],
    "name": "getTrace_Payload_D",
    "outputs": [
      {
        "internalType": "string",
        "name": "tckr_type",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "comments",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "usage",
        "type": "string"
      }
    ],
    "stateMutability": "view",
    "type": "function",
    "constant": true
  },
  {
    "inputs": [
      {
        "internalType": "string",
        "name": "_id",
        "type": "string"
      }
    ],
    "name": "getTrace_Payload_E",
    "outputs": [
      {
        "internalType": "string",
        "name": "farm",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "farmer",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "variety",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "weather",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "region",
        "type": "string"
      }
    ],
    "stateMutability": "view",
    "type": "function",
    "constant": true
  },
  {
    "inputs": [
      {
        "internalType": "string",
        "name": "_id",
        "type": "string"
      },
      {
        "internalType": "string",
        "name": "trace",
        "type": "string"
      }
    ],
    "name": "addTraceCod",
    "outputs": [
      {
        "internalType": "bool",
        "name": "",
        "type": "bool"
      }
    ],
    "stateMutability": "nonpayable",
    "type": "function"
  },
  {
    "inputs": [
      {
        "internalType": "string",
        "name": "_id",
        "type": "string"
      }
    ],
    "name": "getTraceCod",
    "outputs": [
      {
        "internalType": "string",
        "name": "",
        "type": "string"
      }
    ],
    "stateMutability": "view",
    "type": "function",
    "constant": true
  }
]
const contractAddress = '0x4665c5c3b8e724aa99C49b213D576BCbC8B83F7D' // ropsten

const contractDetails = new web3.eth.Contract(contractABI, contractAddress)

const account1 = '0xd19123f347fBBfbFC4E827DfEC48Bbf50541cf74'
const account2 = '0x719d5c00351ea619A79Ab0ef76Cc8C720e3e5836'
//16ac9796f4c062cd1ecbf042c6dce04e644f10e5995694e12e7528af8c37eeb3
const PRIVATE_KEY1 = Buffer.from('8d7e65ca872482cab625f71b4dab43a3a01dafa905e5757f2b174881953712d9', 'hex')
const PRIVATE_KEY2 = Buffer.from('a5013897d3fd9485afe22a97f40a8d4054dcc487cfdec46510bf8775c326f686', 'hex')

function main() {
  const app = express();
  const PORT = process.env.PORT || 3000;
  //-------------------------------------------
  const bodyParser = require('body-parser');
  const cors = require('cors')
  
  app.use(bodyParser.urlencoded({extended: true}));
  app.use(bodyParser.json())
  app.use(cors())
//-------------------------------------------

  app.use(express.json());
  
  app.get('/', (request, response) => {

      response.json({'Welcome':'Welcome to main page!  Please refer to /get-trace-cod/:id and try get some data from blockchain.'});

  });

  app.get('/get-trace-cod/:id', async (request, response) => {

    let traceId = request.params.id
    let trackerData = await contractDetails.methods.getTraceCod(traceId).call()

    if (!trackerData) {
      response.status(500).send('tracker not found.')
    } else {
      response.json(trackerData);
    }
  });

  app.post('/post-trace-cod', async (request, response) => {
    const incomingTraceObj = request.body;

    let id = incomingTraceObj['id']
    let trace = incomingTraceObj['trace']

    console.log(id, trace) //ok printa

    const query = await contractDetails.methods.addTraceCod(id, trace);

    await web3.eth.getTransactionCount(account1, async (err, txCount) => {
      console.log('Testing Point 0 ')

      let txObject = {
        nonce: web3.utils.toHex(txCount),
        from: account1,
        to: contractAddress,
        data: query.encodeABI(),
        value: web3.utils.toHex(web3.utils.toWei('0', 'ether')),
        gasLimit: web3.utils.toHex(process.env.GAS_LIMIT),
        gasPrice: web3.utils.toHex(web3.utils.toWei(process.env.GAS_PRICE, 'gwei'))
      }

      // web3.utils.toHex(21000)
      console.log('Testing Point 1 ')
      
      console.log(txCount)

      console.log('Testing Point 3 ')

      const tx = new Tx(txObject, { chain: 'ropsten' })
      tx.sign(PRIVATE_KEY1)

      const serializedTransaction = tx.serialize()
      const raw = '0x' + serializedTransaction.toString('hex')

      await web3.eth.sendSignedTransaction(raw, (err, txHash) => {
        console.log('txHash **** : ', txHash)

        if (err) {
          let jsonHash = {
            "txHash": 'NO_HASH',
            "Status": err
          }
          console.log(jsonHash)
          response.json(jsonHash);
        } else {

          let jsonHash = {
            "txHash": txHash,
            "Status": 'ok'
          }

          console.log(jsonHash)
          response.json(jsonHash);
        }
      })
    })
  })

  app.listen(PORT, () => console.log(`Express server currently running on port ${PORT}`));

}

main()
