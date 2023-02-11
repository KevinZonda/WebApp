# Web Demo

This repository contains a simple web service implemented by different language with different
frameworks.

| Framework | Language | Code File |
|-----------|----------|-----------|
| [Spring Boot](SpringBoot) | Java | [src](https://github.com/KevinZonda/WebDemo/tree/master/SpringBoot/webdemo/src) |
| [ASP.NET Core (Minimal API)](AspNetCoreMA) | C# | [code](https://github.com/KevinZonda/WebDemo/blob/master/AspNetCoreMA/KevinZonda.WebDemo/KevinZonda.WebDemo/Program.cs) |
| [Gin](Gin) | Go | [code](https://github.com/KevinZonda/WebDemo/blob/master/Gin/WebDemo/main.go) |
| [Express](Express) | JavaScript | [code](https://github.com/KevinZonda/WebDemo/blob/master/Express/index.js) |


## API Docs

- `[GET] /hello`
  - Status Code: [200]
  - Content: `Hello`
- `[POST] /pushQueue`
  - Status Code: [200]  
    Description: push success
  - Status Code: [409]  
    Content: duplicated  
    Description: Contains duplicated item inside the queue
  - Status Code: [500]  
    Description: Not Valid Request
- `[GET] /getQueue`
  - Status Code: [200]  
    Content: `[...]`  
    Description: Content of Queue
