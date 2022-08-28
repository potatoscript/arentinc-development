# Arentinc Coding Challenge - Workload Monitoring Solution

Vue.js【フロントエンド】とASP.NET CORE API【バックエンド】で作成するシンプルなシステムです。
企業の従業員のワークロードを監視するためのソリューションです

## 目次

- [概要](#概要)
  - [ワークフロー](#ワークフロー)
  - [スクリーンショット](#スクリーンショット)
  - [リンク](#リンク)
- [構造](#構造)
  - [開発環境・ツール](#a-開発環境・ツール)
  - [コード構造・開発手順](#b-コード構造・開発手順)
  - [継続的な開発](#c-継続的な開発)
- [著者](#d-著者)


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
### a 開発環境・ツール

- [PostgreSQL](https://www.postgresql.org/) - Database
- [ASP.NET CORE API](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0) - Back End development framework in c#
- [Vue.js](https://vuejs.org/) - Front End development library with [cli](https://cli.vuejs.org/) framework
- [AXIOS](https://axios-http.com/docs/intro) - ブラウザから XMLHttpRequest を作成する
- [Boostrap.js](https://getbootstrap.com/) - css スタイリング ライブラリ


### b コード構造・開発手順
[目次](#目次)

-　DB定義
  - [Employeesテーブル](./document/Employees.sql) - 従業員マスターテーブルデータDDL
  - [Jobsテーブル](./document/Jobs.sql) - 業務テーブルデータDDL
  
-　Backend　フォルダ構造
  - [Startup.cs](./arentinc-api/Startup.cs) - Get the connectionString of the database from `appsettings.json`
  - [appsettings.json](./arentinc-api/appsettings.cs) - Set the connectionSgring of the database
  - Controllers - Frontendの入口 <br>
    |- [EmployeeConroller.cs](./arentinc-api/Controllers/EmployeeConroller.cs) - 従業員マスターデータhttp リクエスト→EmployeeServices.cs <br>
    |- [JobController.cs](./arentinc-api/Controllers/JobConroller.cs) - 業務データhttp リクエスト→JobServices.cs <br>
  - Models<br>
    |- [DBContext.cs](./arentinc-api/Models/DBContext.cs) -　データベーステーブル名定義 <br>
    |- [Employee.cs](./arentinc-api/Models/Employee.cs) - 従業員データベーステーブル項目定義 <br> 
    |- [Job.cs](./arentinc-api/Models/Job.cs) - 業務データベーステーブル項目定義 <br>
  - Services <br>
    |- [DataBaseServices.cs](./arentinc-api/Services/DataBaseServices.cs) - データベース接続設定クラス <br>
    |- [EmployeeServices.cs](./arentinc-api/Services/EmployeeServices.cs) - 従業員ＳＱＬクエリ作成クラス <br>
    |- [JobServices.cs](./arentinc-api/Services/JobServices.cs) - 業務ＳＱＬクエリ作成クラス <br>
	
-　Frontend　フォルダ構造
  - dist<br>
  - assets<br>
     |- js - [url.js](./arentinc-ui/src/assets/js/url.js) - BackendのURLを設定する `API_URL: "https://localhost:44306/api/"` <br>
	 |- [dummy.json](./arentinc-ui/src/assets/dummy.json) - Backendの接続なし時のダミーデータ (デモンストレーション用) <br>
  - locales<br>
	 |- [ja.json](./arentinc-ui/src/locales/ja.json) - 各漢字変数設定 <br>
  - router<br>
     |- [index.js](./arentinc-ui/src/router/index.js) - タブールート設定<br>
  - views<br>
     |- [EmployeeView.vue](./arentinc-ui/src/views/EmployeeView.vue) - 従業員マスター表示画面 <br>
     |- [JobView.vue](./arentinc-ui/src/views/JobView.vue) - 業務一覧表示画面 <br>	 
	 |- [InputModalView.vue](./arentinc-ui/src/views/InputModalView.vue) - 共通データ登録表示画面 <br>	 
  - [App.vue](./arentinc-ui/src/App.vue) - Main画面 <br>  
  - [main.js](./arentinc-ui/src/main.js) - 共通library設定箇所 

  
-　Deploy　配備
[目次](#目次)

　　- FrontendをgitHubに配備する設定箇所：
    - [deploy.sh](./arentinc-ui/src/deploy.sh) 
    - [package.json](./arentinc-ui/src/package.json) - `"deploy": "sh deploy.sh"`
	- [vue.config.js](./arentinc-ui/src/package.json) - `publicPath : '/arentinc-production/'`
 
　　- BackendをDocker Imageを作成する設定箇所：
    - [Dockerfile](./arentinc-api/Dockerfile) 
	- Image名称定義 : `<Ddocker Hub ID>/<Project Name>:<Version>` => `docker build -t potatoscript/arentinc-api .`
　　
### c 継続的な開発
[目次](#目次)

ー　今後検証付きのログインページを作成する
ー　Chart.js を含めて、結果をグラフの形式で作成する


## d 著者
[目次](#目次)

- Website - [BRUCE LIM](https://potatoscript.github.io/resume/)
