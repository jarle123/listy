<div id="top"></div>
<!-- Template from https://raw.githubusercontent.com/othneildrew/Best-README-Template/master/BLANK_README.md -->
<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again! Now go create something AMAZING! :D
-->



<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
 


<!-- PROJECT LOGO -->
<br />
<div align="center">
 
<h3 align="center">Listy</h3>
 
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
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project
Personal learning project focusing on React and .Net 


### Built With


* [React.js](https://reactjs.org/)
* [.NET 5.0](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks)



<!-- GETTING STARTED -->
## Getting Started


### Prerequisites

Software required for project
* npm
* .NET 5.0
* EF Core command-line tools 

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/jarle123/listy.git
   ```
2. Install NPM packages (from \listy\listy-frontend)
   ```sh
   npm install
   ```
3. Seed database (from \listy\listy-backend\)
   ```sh
   dotnet ef migrations add InitialSeed
   dotnet ef database update
   ```


<!-- USAGE EXAMPLES -->
## Usage

1. Start backend Visual studio(from \listy\listy-backend\)

2. Start frontend (from \listy\listy-frontend)
   ```sh
   npm start
   ```




<!-- ROADMAP -->
## Roadmap

- [Feature]  Add notifications
- [Feature]  Add boards / pages
- [Feature]  Add login
  [Error] Exception handling for requests




<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

* [](Readme template from https://raw.githubusercontent.com/othneildrew/Best-README-Template/master/BLANK_README.md )

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/github_username/repo_name.svg?style=for-the-badge
[contributors-url]: https://github.com/github_username/repo_name/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/github_username/repo_name.svg?style=for-the-badge
[forks-url]: https://github.com/github_username/repo_name/network/members
[stars-shield]: https://img.shields.io/github/stars/github_username/repo_name.svg?style=for-the-badge
[stars-url]: https://github.com/github_username/repo_name/stargazers
[issues-shield]: https://img.shields.io/github/issues/github_username/repo_name.svg?style=for-the-badge
[issues-url]: https://github.com/github_username/repo_name/issues
[license-shield]: https://img.shields.io/github/license/github_username/repo_name.svg?style=for-the-badge
[license-url]: https://github.com/github_username/repo_name/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/linkedin_username
[product-screenshot]: images/screenshot.png
