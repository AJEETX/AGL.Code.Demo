# Agl Demo application

Problem: 
http://agl-developer-test.azurewebsites.net/

[![.Net Framework](https://img.shields.io/badge/DotNet-3.1_Framework-blue.svg?style=plastic)](https://www.microsoft.com/net/download/dotnet-core/3.1) |[![Node](https://img.shields.io/badge/NodeJs-v12-blue.svg?style=plastic)](https://nodejs.org/en/download/) | [![Angular](https://img.shields.io/badge/angular-8-blue)](https://angular.io/) | ![GitHub language count](https://img.shields.io/github/languages/count/ajeetx/AGL.Code.Demo.svg) | ![GitHub top language](https://img.shields.io/github/languages/top/ajeetx/AGL.Code.Demo.svg) |![GitHub repo size in bytes](https://img.shields.io/github/repo-size/ajeetx/AGL.Code.Demo.svg) 
| --- | ---          | ---        | ---      | ---        |  --- |

---------------------------------------

## Repository codebase
 
The repository consists of projects as below:


| # |Project Name | Project detail | location| Environment |
| ---| ---  | ---           | ---          | --- |
| 1 | Agl.WebApi | Asp.Net Core WebApi as backend  |  **Backend** folder | [![.Net Framework](https://img.shields.io/badge/DotNet-3.1_Framework-blue.svg?style=plastic)](https://www.microsoft.com/net/download/dotnet-core/3.1)|
| 2 | Agl.WebApi.Domain | Business logic  |  **Backend** folder | [![.Net Framework](https://img.shields.io/badge/DotNet-3.1_Framework-blue.svg?style=plastic)](https://www.microsoft.com/net/download/dotnet-core/3.1)|
| 3 | Agl.WebApi.Test | Unit Test for Api |  **Backend.Test** folder | [![.Net Framework](https://img.shields.io/badge/DotNet-3.1_Framework-blue.svg?style=plastic)](https://www.microsoft.com/net/download/dotnet-core/3.1)| 
| 4 | Agl.WebApi.Client | angular application   | **Frontend** folder | [![Node](https://img.shields.io/badge/Node-Js-blue.svg?style=plastic)](https://nodejs.org/en/download/)  [![Angular](https://img.shields.io/badge/angular-8-blue)](https://angular.io/) |

##### Environment Setup

> Download/install   	
>	1. [![.Net Framework](https://img.shields.io/badge/DotNet-3.1_Framework-blue.svg?style=plastic)](https://www.microsoft.com/net/download/dotnet-core/3.1) to run Agl.WebApi and Agl.WebApi.Test project
>   
>   2. [![Node](https://img.shields.io/badge/NodeJs-v12-blue.svg?style=plastic)](https://nodejs.org/en/download/) to run the angular [front end] application
>   
>	3. [![VS2019](https://img.shields.io/badge/VS-2019-blue.svg?style=plastic)](https://visualstudio.microsoft.com/vs//) to run/debug the applications
>   
>   4. Please install angular-cli version 8 [![Angular](https://img.shields.io/badge/angular-8-blue)](https://angular.io/)
>   

##### Project Setup to run the application

>   1. Please clone or download the repository from [![github](https://img.shields.io/badge/git-hub-blue.svg?style=plastic)](https://github.com/AJEETX/AGL.Code.Demo) 
>   
>   2. Unzip the downloaded repository and open the solution file **AGL.Code.Demo.sln** in Visual Studio 2019.
>
>   3. To start backend and frontend applications, the solution needs to be setup with **Multiple startup projects**
>   
>   4. To setup as **Multiple startup projects**, Right click on solution file in **Visual Studio 2019** solution explorer and select **Properties** in the context menu.
>
>   5. Goto **Common Properties** -> **Startup Project**. On the right pane click the radio button **Multiple startup projects**.
>
>   6. In the below pane, the projects **Agl.WebApi** and **Agl.WebApi.Client** 'Action' need to set to **Start** by selecting from the dropdown in sequence.Click OK. See below
>
>   <img width=“100%” alt="multiple-project-setup" src="./multiple-project-setup.PNG">
>
>   7. All is set, click the **Start** button to run the demo application.
>
>   8. The backend WebApi shall open in browser with url **http://localhost:5000/**, if not then manually open chrome browser with the url.

>   <img width=“100%” alt="backend" src="./backend.PNG">
>
>   9. The frontend application shall open in browser with url **http://localhost:5050/**, if not then manually open chrome browser with the url.
>     
>   <img width=“100%” alt="frontend" src="./frontend.PNG">

```
note: For better experience please use chrome browser.
```
```
happy coding :)
```
