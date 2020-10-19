# RESTfulWebAPI
Swagger動作確認用リポジトリ  Get/Post/Put/DeleteのAPIを実装

## Framework 
・Swagger(NSwag)

## Development of
・NET Core  
・Postgres  
・EntityFramework  
・Nunit

## procedure
Postgresでデータベース作成  

環境変数にConnStringを設定  
`Host=localhost;Port={ポート番号};User Id={ユーザー名};Password={パスワード};Database={データベース名}`

Migrations実行(.NET Core CLI) 
`dotnet ef database update --startup-project root\RESTfulWebAPI\RESTfulWebAPI\RESTfulWebAPI\RESTfulWebAPI.csproj`  
`dotnet ef migrations add InitialMigrations --project root\RESTfulWebAPI\RESTfulWebAPI\RESTfulWebAPI\RESTfulWebAPI.csproj --startup-project root\RESTfulWebAPI\RESTfulWebAPI\RESTfulWebAPI\RESTfulWebAPI.csproj`

https://localhost:{ポート番号}/swagger/index.html  
にアクセス
