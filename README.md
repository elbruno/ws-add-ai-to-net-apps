# Adding AI to Your Existing .NET Apps - Workshop

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](/LICENSE)
[![Twitter: elbruno](https://img.shields.io/twitter/follow/elbruno.svg?style=social)](https://twitter.com/elbruno)
![GitHub: elbruno](https://img.shields.io/github/followers/elbruno?style=social)

Welcome to the Adding AI to Your Existing .NET Apps Workshop. This repository contains a set of .NET projects to demostrate how to add AI to a common .NET scenario: Winform as front end app, and an WebAPI as backend.. 

## Prerequisites

Before running the sample, ensure you have the following installed:
- **.NET 8**: Make sure you have the latest version of .NET installed on your machine.

- **Visual Studio or Visual Studio Code**: You will need an IDE or code editor capable of running .NET projects. Visual Studio or Visual Studio Code are recommended.

- **[Azure OpenAI Services](https://learn.microsoft.com/azure/ai-services/openai/overview)**: To GPT-4o as the model to support the chat, you need to have access to Azure OpenAI Services and create and deploy a GPT-4o model. .

- **[Ollama](https://ollama.com/download)**: To use Phi-3 as local model with Ollama, you need to have ollama installed. 

- **[Docker Desktop](https://www.docker.com/products/docker-desktop/)**: To use Phi-3 as local model with Ollama, you need to have ollama installed. 

### Local LLM install

- Create a local folder to store the Phi-3 local model. In example: `C:\phi3\models`.

- Download the **phi3-mini-4k-instruct-onnx** model to your local machine:
    ```bash
    # navigate to the folder to store the models
    cd c:\phi3\models

    # add support for lfs
    git lfs install 

    # clone and download mini 4K instruct model
    git clone https://huggingface.co/microsoft/Phi-3-mini-4k-instruct-onnx

    # clone and download vision 128K model
    git clone https://huggingface.co/microsoft/Phi-3-vision-128k-instruct-onnx-cpu
    ```
    ***Important:** The current demos are designed to use the ONNX versions of the model. The previous steps clone the following models.*

## Workshop Steps

These are the different steps included in the workshop:

1. Standard Winform + API NET Chat App
2. Add Azure OpenAI GPT-4o to support chat (text)
3. Add Azure OpenAI GPT-4o to support chat + image (text)
4. Add Phi-3 to support chat using ONNX (text)
5. Add Phi-3 to support chat + image using ONNX (text)
6. Add Phi-3 to support chat using Ollama in docker(text)
7. Add Cache using Semantic Memory, local in Memory
8. Add Cache using Semantic Memory, store in Azure AI Search
9. Add RAG using Azure AI Search
Add Aspire Dashboard using OTLP endpoint

## Resources

- [Snippet Generator](https://snippet-generator.app/?description=&tabtrigger=&snippet=&mode=vscode)

## Author

👤 **Bruno Capuano**

* Website: https://elbruno.com
* Twitter: [@elbruno](https://twitter.com/elbruno)
* Github: [@elbruno](https://github.com/elbruno)
* LinkedIn: [@elbruno](https://linkedin.com/in/elbruno)

## 🤝 Contributing

Contributions, issues and feature requests are welcome!

Feel free to check [issues page](https://github.com/elbruno/sk-chat-winform-demo/issues).

## Show your support

Give a ⭐️ if this project helped you!


## 📝 License

Copyright &copy; 2024 [Bruno Capuano](https://github.com/elbruno).

This project is [MIT](/LICENSE) licensed.

***
