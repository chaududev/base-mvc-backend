# Project Clothes Shop
- DDD(Domain Driven Design) : v
- Onion Architecture (4 layers) :Domain; Infrastructure (interact with database : IRepository, Repository) ; Application (handle business logic : IService, Service); UI (api swagger)
- Entity Framework Core 
- Fluent Api, Automapper, Pagination, JWT
- Generic class : automapper ; Linq

![a1](https://user-images.githubusercontent.com/81465934/223073996-837c6790-b6f9-472a-8f46-9fcc02a7a5d2.JPG)
![a2](https://user-images.githubusercontent.com/81465934/223074015-6180ae37-22ae-4325-b326-3fef1111bda2.JPG)
JWT Post get Token
![a3](https://user-images.githubusercontent.com/81465934/223074031-29022103-0c92-45ac-ad52-e76866319ca8.JPG)
Use Token to get api controller has [Authorize] Role=Admin
![a4](https://user-images.githubusercontent.com/81465934/223074046-a11126a7-a7f9-4f31-b551-65ba699f398f.JPG)
Role != Admin
![a5](https://user-images.githubusercontent.com/81465934/223308180-22b0475f-7f9f-4fa9-a839-05e3d0c47590.JPG)
Not use Token
![a6](https://user-images.githubusercontent.com/81465934/223308201-fb3f88d7-4477-4dc6-b1c3-8bc70c468cde.JPG)
