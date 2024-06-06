# Semantic Kernel Winform Chat

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](/LICENSE)
[![Twitter: elbruno](https://img.shields.io/twitter/follow/elbruno.svg?style=social)](https://twitter.com/elbruno)
![GitHub: elbruno](https://img.shields.io/github/followers/elbruno?style=social)

Welcome to the Semantic Kernel Winform Chat demo. This repository contains a demo project that implement a chat with semantic kernel.

Snippet Generator: https://snippet-generator.app/?description=&tabtrigger=&snippet=&mode=vscode

## Prerequisites

Before running the sample, ensure you have the following installed:
- **.NET 8**: Make sure you have the latest version of .NET installed on your machine.
- **(Optional) Visual Studio or Visual Studio Code**: You will need an IDE or code editor capable of running .NET projects. Visual Studio or Visual Studio Code are recommended.
- Using git, clone locally one of the available Phi-3 versions from Hugging Face. 

## LLM Prerequisites

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
    ![Download only ONNX models](./img/10DownloadOnnx.png)

You can learn more about [Phi-3 in Hugging Face](https://huggingface.co/microsoft/Phi-3-mini-4k-instruct-onnx).

## About the sample

The main solution have several sample projects that demonstrates the capabilities of the Phi-3 models.

| Project | Description | Location |
| ------------ | ----------- | -------- |
| LabsPhi301    | This is a sample project that uses a local phi3 model to ask a question. The project load a local ONNX Phi-3 model using the `Microsoft.ML.OnnxRuntime` libraries. | .\src\LabsPhi301\ |

## How to Run the Projects

To run the projects, follow these steps:
1. Clone the repository to your local machine.

1. Open a terminal and navigate to the desired project. In example, let's run `LabsPhi301`.
    ```bash
    cd .\src\LabsPhi301\
    ```

1. Run the project with the command
    ```bash
    dotnet run
    ```

1.  The sample project ask for a user input and replies using the local mode. 

    The running demo is similar to this one:

    ![Chat running demo](./img/20SampleConsole.gif)

    ***Note:** there is a typo in the 1st question, Phi-3 is cool enough to share the correct answer!*

1.  The project `LabsPhi304` ask for the user to select different options, and then process the request. In example, analyzing a local image.

    The running demo is similar to this one:

    ![Image Analysis running demo](./img/30SampleVisionConsole.gif)
    

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
