<a name="readme-top"></a>

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]

<br/>

[![SonarCloud](https://sonarcloud.io/images/project_badges/sonarcloud-black.svg)](https://sonarcloud.io/organizations/maikelhendrikx1/projects?view=leak)


<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/MaikelHendrikx1/BingoBlitz">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a>

<h3 align="center">BingoBlitz</h3>

  <p align="center">
    Bingo Blitz is a website where users can play objective-bingo against other users. In objective-bingo, the players are given a bingo card consisting of objectives. These objectives can be in both real life or in specific video games. Objectives can be anything from obtaining a cup of coffee to high-fiving 10 different people. When a player completes an objective, they have to click on the objective to claim the square it sits on. The winning condition can be set by the host before the game starts (for example the full board or 2 lines).
    
  <br />
   <br />
    <a href="https://github.com/MaikelHendrikx1/BingoBlitz"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/MaikelHendrikx1/BingoBlitz">View Demo</a>
    ·
    <a href="https://github.com/MaikelHendrikx1/BingoBlitz/issues">Report Bug</a>
    ·
    <a href="https://github.com/MaikelHendrikx1/BingoBlitz/issues">Request Feature</a>
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

[![BingoBlitz Screen Shot][product-screenshot]](https://example.com)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



### Built With

* [Vue.js][Vue-url]
* [.NET][.NET-url]

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisites

These are the things you will need to run the project
* npm
  ```sh
  npm install npm@latest -g
  ```

* A Cosmos DB instance with a database called "CommunityHub" and a container called "ObjectiveCollection" with a partition key called "/Id". This database can either be hosted on Azure or locally. If you want to host it locally, you can use the [Azure Cosmos DB Emulator](https://learn.microsoft.com/en-us/azure/cosmos-db/how-to-develop-emulator?tabs=windows%2Ccsharp&pivots=api-nosql) to do so. 

If you are using Kubernetes, and want to use the emulator, you need to host the emulator within the same Kubernetes cluster using the Docker image. This can be done by running the following commands:
  ```sh
  kubectl run cosmosdb-emulator --image=mcr.microsoft.com/cosmosdb/linux/azure-cosmos-emulator:latest --port=8081
  kubectl expose pod cosmosdb-emulator --type=LoadBalancer
  ``` 

Alternatively, you can expose the emulator to the internet by using ngrok. This can be done by running the following command in an ngrok terminal:
  ```sh
  ngrok http -region=eu https://localhost:8081
  ```



### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/MaikelHendrikx1/BingoBlitz.git
   ```
2. Install NPM packages (frontend)
   ```sh
   cd BingoBlitz-Frontend
   npm install
   ```

### Configuration

1. Create a file called `.env` in "BingoBlitz-CommunityHub/CommunityHubAPI" and add the following lines:
   ```
   CosmosAccountEndpoint=<your Cosmos DB endpoint>
   CosmosAccountKey=<your Cosmos DB key>
   ```

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

### Running in Docker
Each part of this application can be ran in Docker. Before using Docker, ensure that Docker Desktop is installed and is running on your device. The latest version of Docker Desktop can be installed [here](https://docs.docker.com/get-docker/).

* Running a single, specific service
  ```sh
  cd <path to project you want to containerize>
  docker build -t <a unique name for your image> .
  docker run -dp <location you want to host to, for example 127.0.0.1:3000>:80 --name <what you want the container to be named>  <your chosen image name>
  ```

* Running all services simultaneously using Docker-Compose.
  ```sh
  docker-compose build
  docker-compose up
  ```


### Running in Kubernetes
This application can be ran in Kubernetes. Please refer to [kubernetes.md](kubernetes.md) for more information.


### Observing
This application can be observed and load tested using Prometheus and Grafana. Please refer to [observing.md](observing.md) for more information.


### Load testing
This application can be load tested using k6. Please refer to [loadtesting.md](loadtesting.md) for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>


## Roadmap
The roadmap for this project is in Trello, and can be found [here](https://trello.com/b/kEvqvINf/bingo-blitz)

<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Maikel Hendrikx -  maikel.hendrikx@outlook.com

Project Link: [https://github.com/MaikelHendrikx1/BingoBlitz](https://github.com/MaikelHendrikx1/BingoBlitz)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/MaikelHendrikx1/BingoBlitz.svg?style=for-the-badge
[contributors-url]: https://github.com/MaikelHendrikx1/BingoBlitz/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/MaikelHendrikx1/BingoBlitz.svg?style=for-the-badge
[forks-url]: https://github.com/MaikelHendrikx1/BingoBlitz/network/members
[stars-shield]: https://img.shields.io/github/stars/MaikelHendrikx1/BingoBlitz.svg?style=for-the-badge
[stars-url]: https://github.com/MaikelHendrikx1/BingoBlitz/stargazers
[issues-shield]: https://img.shields.io/github/issues/MaikelHendrikx1/BingoBlitz.svg?style=for-the-badge
[issues-url]: https://github.com/MaikelHendrikx1/BingoBlitz/issues
[license-shield]: https://img.shields.io/badge/license-MIT-green?style=for-the-badge
[license-url]: https://github.com/MaikelHendrikx1/BingoBlitz/blob/main/LICENSE
[product-screenshot]: images/screenshot.png
[Vue-url]: https://vuejs.org/ 
[.NET-url]: https://dotnet.microsoft.com/en-us/
