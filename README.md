# Arentinc Coding Challenge - Workload Monitoring Solution

Vue.js【フロントエンド】とASP.NET CORE API【バックエンド】で作成するシンプルなシステムです。
企業の従業員のワークロードを監視するためのソリューションです

## 目次

- [概要](#概要)
  - [ワークフロー](#ワークフロー)
  - [スクリーンショット](#スクリーンショット)
  - [リンク](#リンク)
- [構造](#構造)
  - [開発環境・ツール](#開発環境・ツール)
  - [コード構造・開発手順](#コード構造・開発手順)
  - [継続的な開発](#継続的な開発)
- [著者](#著者)
- [Acknowledgments](#acknowledgments)


## 概要

### ワークフロー
[目次](#目次)
<image style="width:300px;height:150px" src="./document/workflow.png" />

### スクリーンショット
[目次](#目次)
<image style="width:300px;height:150px" src="./document/screenshot.png" />


### リンク
[目次](#目次)

- 以下のリンクは、デモンストレーションのために github にアップロードされた [Front End] システムです。
- [Front End]ライブサイト URL: [The System](https://potatoscript.github.io/arentinc-production/)

## 構造
[目次](#目次)
### 開発環境・ツール

- [PostgreSQL](https://www.postgresql.org/) - Database
- [ASP.NET CORE API](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0) - Back End development framework in c#
- [Vue.js](https://vuejs.org/) - Front End development library with [cli](https://cli.vuejs.org/) framework
- [AXIOS](https://axios-http.com/docs/intro) - ブラウザから XMLHttpRequest を作成する
- [Boostrap.js](https://getbootstrap.com/) - css スタイリング ライブラリ


### コード構造・開発手順
[目次](#目次)


-　DB定義
  - [Employeesテーブル](./document/Employees.sql) - 従業員マスターテーブルデータDDL
  - [Jobsテーブル](./document/Jobs.sql) - 業務テーブルデータDDL
  
-　Backend　フォルダ構造
  - [Startup.cs](./arentinc-api/Startup.cs) - Get the connectionString of the database from `appsettings.json`
  - [appsettings.json](./arentinc-api/appsettings.cs) - Set the connectionSgring of the database
  - Controllers<br>
    |- [EmployeeConroller.cs](./arentinc-api/Controllers/EmployeeConroller.cs)<br>
    |- [JobController.cs](./arentinc-api/Controllers/JobConroller.cs)<br>
  - Models<br>
    |- [DBContext.cs](./arentinc-api/Models/DBContext.cs)<br>
    |- [Employee.cs](./arentinc-api/Models/Employee.cs)<br>
    |- [Job.cs](./arentinc-api/Models/Job.cs)<br>
  - Services <br>
    |- [DataBaseServices.cs](./arentinc-api/Services/DataBaseServices.cs)<br>
    |- [EmployeeServices.cs](./arentinc-api/Services/EmployeeServices.cs)<br>
    |- [JobServices.cs](./arentinc-api/Services/JobServices.cs)<br>
	
-　Frontend　フォルダ構造
  - dist
  - assets
     |- js - [url.js](./arentinc-ui/src/assets/js/url.js) - BackendのURLを設定する `API_URL: "https://localhost:44306/api/"`
	 |- [dummy.json](./arentinc-ui/src/assets/dummy.json) - Backendの接続なし時のダミーデータ (デモンストレーション用)
-　Deploy　配備
　　- deploy.sh - FrontendをgitHubに配備する
  ```sh
   #!/usr/bin/env sh

   set -e

   npm run build

   cd dist

   git init
   git add -A
   git commit -m "New Deplyment"
   git push -f git@github.com:potatoscript/arentinc-production.git master:gh-pages

   cd -
  ```  
　　- Dockerfile - BackendをDocker Imageを作成する
　　```bash
   # Get base SDK Image from Microsoft
   FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
   WORKDIR /app

   # Copy the CSPROJ file and restore any dependecies via NUGET
   COPY *.csproj ./
   RUN dotnet restore

   # Copy the project files and build release
   COPY . ./
   RUN dotnet publish -c Release -o out

   # Generate runtime image
   FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
   WORKDIR /app
   EXPOSE 80
   COPY --from=build-env /app/out .
   ENTRYPOINT [ "dotnet", "DockerAPI.dll" ]
  ```

### 継続的な開発
[目次](#目次)

ー　今後検証付きのログインページを作成する
ー　Chart.js を含めて、結果をグラフの形式で作成する


## 著者
[目次](#目次)

- Website - [BRUCE LIM](https://potatoscript.github.io/resume/)
