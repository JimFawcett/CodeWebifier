# CodeWebifier

**Convert source code files into stylized HTML fragments suitable for web pages or blogs.**

[![GitHub Stars](https://img.shields.io/github/stars/JimFawcett/CodeWebifier?style=social)](https://github.com/JimFawcett/CodeWebifier/stargazers)
[![GitHub Forks](https://img.shields.io/github/forks/JimFawcett/CodeWebifier?style=social)](https://github.com/JimFawcett/CodeWebifier/network/members)

---

## 💡 About CodeWebifier

**CodeWebifier** is a utility designed to take raw source code files (e.g., C#, C++, etc.) and transcribe their content into a **web page fragment** (HTML, potentially with inline CSS for styling and syntax highlighting).

The primary function is to **write this formatted HTML output directly to the console**, allowing users to easily copy the fragment and paste it into their own web documentation, technical blogs, or project websites. This is a quick and effective way to ensure code snippets are displayed correctly and with appropriate syntax highlighting on the web.

![App screenshot](img src="https://github.com/JimFawcett/NewSite/tree/main/pictures/CodeWebifier.png" size="500")

## ✨ Features

* **Source Code to HTML Conversion:** Converts the contents of a specified source code file into a self-contained HTML block.
* **Web Page Fragment Output:** Generates HTML suitable for embedding directly into an existing web page body.
* **Console Output:** Writes the final HTML fragment to the console for convenient copy-and-paste operations.
* **Built with C#:** A straightforward, compiled console application.

## 🚀 Getting Started

This project is a C# console application and can be built and run using Visual Studio or the .NET Core CLI.

### Prerequisites

* .NET Framework or .NET Core (depending on the project's target framework)
* A C# compiler (e.g., Visual Studio or `dotnet CLI`)

### Installation (Building from Source)

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/JimFawcett/CodeWebifier.git](https://github.com/JimFawcett/CodeWebifier.git)
    cd CodeWebifier
    ```

2.  **Open the Solution:**
    Open the `CodeWebifier.sln` file in Visual Studio and build the solution, or use the command line:
    ```bash
    dotnet build
    ```

## 💻 Usage

The application is typically run from the command line and requires the path to the source code file you wish to "webify."

Assuming you have built the executable, here is the general usage pattern:

```bash
# General syntax
CodeWebifier.exe <path_to_source_file>

# Example
CodeWebifier.exe C:\Projects\MyRepo\src\Program.cs